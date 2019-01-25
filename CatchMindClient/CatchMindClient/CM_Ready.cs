using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Library;
using System.IO;

namespace CatchMindClient
{
    public partial class CM_Ready : Form
    {
        private TcpClient client = null;
        private string myNickname;
        private List<Label> labels = new List<Label>();
        private string[] All = new string[4]; 
        private bool on_off;
        Thread thread;
        Thread thread1;

        public CM_Ready(TcpClient client, string name)
        {
            InitializeComponent();
            this.client = client;
            on_off = false;
            myNickname = name;
            {
                labels.Add(label1); labels.Add(label2); labels.Add(label3); labels.Add(label4);
            }
        }

        private void CM_Ready_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(Ready_Request));
            thread.IsBackground = true;
            thread.Start();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (on_off == false)
            {
                Ready_Off ready_Off = new Ready_Off();
                byte[] bytes = new byte[1024 * 4];
                ready_Off.On = true;
                ready_Off.type = (int)CM_All.레디;
                Stream stream = new NetworkStream(client.Client); 
                bytes = CM_Library.Serialize(ready_Off);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                on_off = true;
                //ReadyToGame();
                thread1 = new Thread(new ThreadStart(ReadyToGame));
                thread1.Start();
            }
        }

        private void ReadyToGame()
        {
            while (true)
            {
                if(labels[0].BackColor == Color.Blue && labels[1].BackColor == Color.Blue && labels[2].BackColor == Color.Blue && labels[3].BackColor == Color.Blue)
                {
                    for (int i = 0; i < 4; i++) All[i] = labels[i].Text;
                    try
                    {
                        thread.Join(100);
                        thread.Abort();
                        Off_game();
                        break;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
            
        }

        private void Ready_Request()
        {
            while (true)
            {
                byte[] bytes = new byte[1024 * 4];
                Stream stream = new NetworkStream(client.Client);
                int len = stream.Read(bytes, 0, bytes.Length);
                CM_Library Two = (CM_Library)CM_Library.Deserialize(bytes);
                stream.Flush();
                switch (Two.type)
                {
                    case (int)CM_All.클라이언트라벨:
                    {
                           Ready ready = new Ready();
                        ready = (Ready)CM_Library.Deserialize(bytes);
                        for (int i = 0; i < ready.nickNameList.Length; i++)
                        {
                            if(ready.nickNameList[i] != null) this.labels[i].Text = ready.nickNameList[i].ToString();
                        }
                        break;
                    }
                    case (int)CM_All.자기번호:
                    {
                        Ready_On ready_On = new Ready_On();
                        ready_On = (Ready_On)CM_Library.Deserialize(bytes);
                        for (int i = 0; i < 4; i++)
                        {
                            if (ready_On.On[i] == true) labels[i].BackColor = Color.Blue;
                        }
                        break;
                    }
                }
            }
        }
        
        public void Off_game()
        {
            CM_Game game = new CM_Game(client, myNickname, All);
            this.Hide();
            game.ShowDialog(); 
            this.Close();
        }
    }
}
