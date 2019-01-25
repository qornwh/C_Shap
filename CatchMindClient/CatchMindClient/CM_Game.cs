using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Library;

namespace CatchMindClient
{
    public partial class CM_Game : Form
    {
        private Point point = new Point();
        private Graphics gh;
        private Pen pen = new Pen(Color.Black);
        private Thread threadGame;
        private TcpClient client;
        private int timerPoint; 
        private bool on_off = false;
        private string myNick;
        private string turnNick;
        private string[] Allname = new string[4];   //모든 닉네임
        private int j = 0;        // 턴넘기는 번호
        private int pen_num;      //펜 번호
        private Dictionary<string, int> User_Point = new Dictionary<string, int>();

        public CM_Game(TcpClient client, string Nick, string[] All)
        {
            InitializeComponent();
            this.client = client;
            this.myNick = Nick;
            this.Text = myNick;
            this.txt_Mul.Text = "";
            timer1.Start();
            timerPoint = 0;
            Allname = All;
            for (int i = 0; i < Allname.Length; i++) User_Point.Add(Allname[i], 0);
            rB_1Pic.Checked = true;
        }

        private void CM_Game_Load(object sender, EventArgs e)
        {
            threadGame = new Thread(new ThreadStart(Request));
            threadGame.IsBackground = true;
            threadGame.Start();
        }

        //-------------스트림(타입에 따른)을 받아오는 쓰레드 핸들러 Request 구현 해야한다네 (메시지, 좌표, 턴, 정답 등)------------------------------//
        private void Request()
        {
            SendMyTurn();
            while (true)
            {
                byte[] bytes = new byte[1024 * 4];
                Stream stream = new NetworkStream(client.Client);
                int len = stream.Read(bytes, 0, bytes.Length);
                CM_Library Two = (CM_Library)CM_Library.Deserialize(bytes);
                this.txt_Mul.Invoke(new MethodInvoker(delegate () {
                    txt_Mul.Text += Two.type.ToString() + "\r\n";
                }));
                stream.Flush();
                switch (Two.type)
                {
                    case (int)CM_All.메시지:
                        {
                            Library.Message message = (Library.Message)CM_Library.Deserialize(bytes);
                            //메시지 출력 구현해야함
                            this.txt_Mul.Invoke(new MethodInvoker(delegate() {
                                txt_Mul.Text += message.MMS + "\r\n";
                            }));
                            Set_byte(bytes);
                            break;
                        }
                    case (int)CM_All.좌표:
                        {
                            GPoint gPoint = (GPoint)CM_Library.Deserialize(bytes);
                            //좌표찍는거 구현해야함
                            gh = pictureBox1.CreateGraphics();
                            //sel_Color(pen, gPoint.gColor);
                            //pen.Width = gPoint.gWidth;
                            gh.DrawLine(pen, point.X, point.Y, gPoint.X, gPoint.Y);
                            point.X = gPoint.X; point.Y = gPoint.Y;
                            Set_byte(bytes);
                            break;
                        }
                    case (int)CM_All.문제:
                        {
                            Problem problem = (Problem)CM_Library.Deserialize(bytes);
                            //문제받기
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                txt_problem.Text = problem.problem;
                            }));
                            if (this.CM_My.InvokeRequired)
                            {
                                this.CM_My.Invoke(new MethodInvoker(delegate ()
                                {
                                    CM_My.Text = "MY TURN";
                                    CM_My.BackColor = Color.Lime;
                                }));
                            }
                            else
                            {
                                CM_My.Text = "MY TURN";
                                CM_My.BackColor = Color.Lime;
                            }
                            Set_byte(bytes);
                            break;
                        }
                    case (int)CM_All.점수:
                        {
                            Upoint upoint = (Upoint)CM_Library.Deserialize(bytes);
                            User_Point[upoint.Nic] = upoint.point;
                            Set_byte(bytes);
                            if(j == 4) Ranking();
                            break;
                        }
                    case (int)CM_All.처음좌표:
                        {
                            GPoint gPoint = (GPoint)CM_Library.Deserialize(bytes);
                            //좌표찍는거 구현해야함
                            gh = pictureBox1.CreateGraphics();
                            sel_Color(pen, gPoint.gColor);
                            pen.Width = gPoint.gWidth;
                            point.X = gPoint.X; point.Y = gPoint.Y;
                            Set_byte(bytes);
                            break;
                        }
                    case (int)CM_All.그림초기화:
                        {
                            pictureBox1.Image = null;
                            Set_byte(bytes);
                            break;
                        }
                }
            }
        }

        private void Set_byte(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++) bytes[i] = 0;
        }//바이트배열 초기화
        
        private void txt_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btn_MSend_Click(sender, e);
        }

        private void btn_MSend_Click(object sender, EventArgs e)
        {
            byte[] bytes = new byte[1024 * 4];
            Library.Message message = new Library.Message();
            message.type = (int)CM_All.메시지;
            message.MMS = myNick+" : "+this.txt_Chat.Text;
            bytes = CM_Library.Serialize(message);                      
            Stream stream = new NetworkStream(client.Client);
            stream.Write(bytes, 0, bytes.Length);
            this.txt_Chat.Text = "";
            stream.Flush();
            Set_byte(bytes); 
        }//메시지를 보내는거 구현

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = timerPoint + "초";
            if (timerPoint >= 10 && timerPoint < 17)
            {
                if(timerPoint < 13)
                {
                    on_off = false;
                    txt_problem.Text = "";
                    CM_My.Text = "Another_Turn";
                    CM_My.BackColor = Color.Silver;
                    groupBox1.Enabled = false;
                }
            }
            else if(timerPoint >= 17)
            {
                SendMyAnswer();
                pictureBox1.Image = null;
                ++j;
                if (j < 4)
                {
                    turnNick = Allname[j];
                    SendMyTurn();
                    timerPoint = -1;
                    pen.Color = Color.Black;
                    pen.Width = 1;
                }
                else
                {
                    //Ranking();
                    btn_Final.Enabled = true;
                    textBox1.Text = "종료됬습니다.";
                    timer1.Enabled = false;
                }
            }
            ++timerPoint;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (on_off == true && e.Button == MouseButtons.Left)
            {
                point.X = e.X; point.Y = e.Y;
                byte[] bytes = new byte[1024 * 4];
                GPoint gPoint = new GPoint();
                gPoint.type = (int)CM_All.처음좌표;
                gPoint.X = e.X;gPoint.Y = e.Y;
                gPoint.gColor = pen_num;
                gPoint.gWidth = (int)pen.Width;
                bytes = CM_Library.Serialize(gPoint);
                Stream stream = new NetworkStream(client.Client);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                Set_byte(bytes);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (on_off == true && e.Button == MouseButtons.Left)
            {
                byte[] bytes = new byte[1024 * 4];
                gh = pictureBox1.CreateGraphics();
                gh.DrawLine(pen, point, new Point(e.X - 1, e.Y - 1));

                GPoint gPoint = new GPoint();
                gPoint.type = (int)CM_All.좌표;
                gPoint.X = point.X;
                gPoint.Y = point.Y;
                //gPoint.gColor = pen_num;
                //gPoint.gWidth = (int)pen.Width;
                bytes = CM_Library.Serialize(gPoint);
                Stream stream = new NetworkStream(client.Client);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                Set_byte(bytes);

                point.X = e.X; point.Y = e.Y;
            }
        }
        
        private void SendMyTurn()
        {
            if (myNick == Allname[j])
            {
                byte[] bytes = new byte[1024 * 4];
                on_off = true;
                Stream stream = new NetworkStream(client.Client);
                Turn turn = new Turn();
                turn.type = (int)CM_All.턴;
                bytes = CM_Library.Serialize(turn);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                groupBox1.Enabled = true;
            }
        }

        private void SendMyAnswer()
        {
            if (myNick != Allname[j])
            {
                byte[] bytes = new byte[1024 * 4];
                Answer answer = new Answer();
                Stream stream = new NetworkStream(client.Client);
                answer.type = (int)CM_All.정답;
                if(txt_Answer.InvokeRequired)
                txt_Answer.Invoke(new MethodInvoker(delegate ()
                {
                    answer.txtAnswer = txt_Answer.Text;
                }));
                else
                    answer.txtAnswer = txt_Answer.Text;
                answer.Nicname = myNick;
                bytes = CM_Library.Serialize(answer);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                txt_Answer.Text = "";
            }
        }

        private void txt_Mul_TextChanged(object sender, EventArgs e)
        {
            this.txt_Answer.SelectionStart = this.txt_Answer.Text.Length;
            this.txt_Answer.ScrollToCaret();
        }

        private void lb_White_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White; pen_num = 4; pen.Width = 5; this.rB_5Pic.Checked = true; trackBar1.Value = 5;
        }

        private void lb_Red_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red; pen_num = 1;
        }

        private void lb_Blue_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue; pen_num = 2;
        }

        private void lb_Grean_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green; pen_num = 3;
        }

        private void lb_Black_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black; pen_num = 0;
        }
        
        private void label6_Click(object sender, EventArgs e)
        {
            if (on_off == true)
            {
                this.pictureBox1.Image = null;
                byte[] bytes = new byte[1024 * 4];
                resetImage resetimage = new resetImage();
                resetimage.type = (int)CM_All.그림초기화;
                bytes = CM_Library.Serialize(resetimage);
                Stream stream_rs = new NetworkStream(client.Client);
                stream_rs.Write(bytes, 0, bytes.Length);
                stream_rs.Flush();
            }
        }

        private void sel_Color(Pen pen, int num)
        {
            switch (num)
            {
                case 0:
                    {
                        pen.Color = Color.Black;
                        break;
                    }
                case 1:
                    {
                        pen.Color = Color.Red;
                        break;
                    }
                case 2:
                    {
                        pen.Color = Color.Blue;
                        break;
                    }
                case 3:
                    {
                        pen.Color = Color.Green;
                        break;
                    }
                case 4:
                    {
                        pen.Color = Color.White;
                        break;
                    }
            }
        }

        private void btn_Final_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ranking()
        {
            List<Rank_User> ranks = new List<Rank_User>();
            List<Label> labels = new List<Label>();
            labels.Add(label1); labels.Add(label2); labels.Add(label3); labels.Add(label4);

            for (int i =0; i<Allname.Length; i++)
                ranks.Add(new Rank_User(User_Point[Allname[i]], Allname[i]));
            
            var ranking = from ra in ranks
                          orderby ra.score
                          select ra;

            int k = Allname.Length-1;
            foreach(var Users in ranking)
            {
                labels[k].Text = String.Format(Users.user + ":" + Users.score.ToString()); k--;
            }
        }

        private void rank_image(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        pictureBox2.Load(@"ImageBox/one.png");
                        break;
                    }
                case 1:
                    {
                        pictureBox3.Load(@"ImageBox/two.png");
                        break;
                    }
                case 2:
                    {
                        pictureBox4.Load(@"ImageBox/three.png");
                        break;
                    }
                case 3:
                    {
                        pictureBox5.Load(@"ImageBox/four.png");
                        break;
                    }
                default:
                    {
                        pictureBox5.Load(@"ImageBox/four.png");
                        break;
                    }
            }
        }

        private void rB_1Pic_CheckedChanged(object sender, EventArgs e)
        {
            this.pen.Width = 1; this.trackBar1.Value = 1;
        }

        private void rB_3Pic_CheckedChanged(object sender, EventArgs e)
        {
            this.pen.Width = 3; this.trackBar1.Value = 3;
        }

        private void rB_5Pic_CheckedChanged(object sender, EventArgs e)
        {
            this.pen.Width = 5; this.trackBar1.Value = 5;
        }

        private void rB_10Pic_CheckedChanged(object sender, EventArgs e)
        {
            this.pen.Width = 10; this.trackBar1.Value = 10;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)
            {
                case 1:
                    {
                        this.pen.Width = 1;
                        rB_1Pic.Checked = true;
                        break;
                    }
                case 3:
                    {
                        this.pen.Width = 3;
                        rB_3Pic.Checked = true;
                        break;
                    }
                case 5:
                    {
                        this.pen.Width = 5;
                        rB_5Pic.Checked = true;
                        break;
                    }
                case 10:
                    {
                        this.pen.Width = 1;
                        rB_10Pic.Checked = true;
                        break;
                    }
                default:
                    {
                        this.pen.Width = trackBar1.Value;
                        Pic_Over.Checked = true;
                        break;
                    }
            }
        }
    }

    class Rank_User
    {
        public int score
        {
            get;set;
        }
        public string user
        {
            get;set;
        }

        public Rank_User(int score, string user)
        {
            this.score = score;
            this.user = user;
        }
    }
}
