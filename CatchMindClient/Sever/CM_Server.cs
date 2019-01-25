using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using Library;
using System.Collections;

namespace Sever
{
    public partial class CM_Server : Form
    {
        private TcpListener server;
        private Dictionary<TcpClient, int> Number_D = new Dictionary<TcpClient, int>();
        //private Dictionary<TcpClient, Login> login_D = new Dictionary<TcpClient, Login>();
        private List<TcpClient> tcpClients = new List<TcpClient>();
        private ArrayList Nick = new ArrayList();
        private Ready_On on = new Ready_On();
        private static int count = 0;
        private int ti_time = -1;
        private SqlConnection conn = new SqlConnection();
        private SqlCommand sqlComm = new SqlCommand();
        private SqlDataReader sd;
        private List<string> Allproblem = new List<string>(); //모든 문제 정답 배열
        private Dictionary<string, int> User_point = new Dictionary<string, int>(); //점수

        public CM_Server()
        {
            InitializeComponent();
            
            AllProblem();

            Thread thread = new Thread(new ThreadStart(Start_Server));
            thread.IsBackground = true;
            thread.Start();
        }

        private void AllProblem()
        {
            string Path = "SELECT * FROM CM_Answer";
            try
            {
                string connectingsql =
                    "Server = 127.0.0.1,1433; database = CM_data ; uid = qornwh ; pwd = qweasd12";
                conn.ConnectionString = connectingsql;
                conn.Open();

                sqlComm.CommandText = Path;
                sqlComm.Connection = conn;
                sd = sqlComm.ExecuteReader();
                while (sd.Read())
                {
                    Allproblem.Add(sd["CM_answer"].ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("오류발생");
            }
        } // 데이터베이스에서 문제 가져오기

        private byte[] Set_byte(byte[] bytes)
        {
            for(int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = 0;
            }
            return bytes;
        }

        private void Start_Server()
        {
            server = new TcpListener(IPAddress.Any, 9876);
            server.Start();
            DisplayText("Server Start !!!");
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    count++;
                    Number_D.Add(client, count-1);
                    tcpClients.Add(client);

                    Handler_Client handler = new Handler_Client();
                    handler.ClientEvent += new Handler_Client.ClientRequestHandler(this.Request); 
                    handler.StartClient(client, Number_D);
                }
                catch (Exception)
                {
                    MessageBox.Show("오류 발생");
                }
            }
        }

        public void Request(int Type, byte[] bytes, TcpClient client) //Type에 따라 달라지는 직렬화
        {
            switch (Type)
            {
                case (int)CM_All.메시지:
                    {
                        Library.Message message = new Library.Message();
                        message = (Library.Message)CM_Library.Deserialize(bytes);
                        DisplayText(message.MMS);
                        //Set_byte(bytes);
                        //bytes = CM_Library.Serialize(message);
                        //모든 클라이언트에 보내주는 메소드 만들어야함
                        for (int i = 0; i < count; i++)
                        {
                            Stream stream4 = new NetworkStream(tcpClients[i].Client);
                            stream4.Write(bytes, 0, bytes.Length);
                            stream4.Flush();
                        }
                        break;
                    }
                case (int)CM_All.레디:
                    {
                        Ready_Off ready_Off = new Ready_Off();
                        ready_Off = (Ready_Off)CM_Library.Deserialize(bytes);
                        on.On[Number_D[client]] = true;
                        on.type = (int)CM_All.자기번호;
                        Set_byte(bytes);
                        bytes = CM_Library.Serialize(on);
                        for(int i = 0; i < count; i++)
                        {
                            Stream stream3 = new NetworkStream(tcpClients[i].Client);
                            stream3.Write(bytes, 0, bytes.Length);
                            stream3.Flush();
                        }
                        break;
                    }
                case (int)CM_All.닉네임:
                    {
                        Login login = new Login();
                        login = (Login)CM_Library.Deserialize(bytes);

                        //login_D.Add(dictionary, login);
                        User_point.Add(login.id, 0);
                        Nick.Add(login.id);
                        Set_byte(bytes);
                        
                        Ready ready = new Ready();
                        ready.type = (int)CM_All.클라이언트라벨;
                        for (int i = 0; i < count; i++)
                        {
                            ready.nickNameList[i] = Nick[i].ToString();
                        }
                        bytes = CM_Library.Serialize(ready);
                        for(int i = 0; i < count; i++)
                        {
                            Stream stream2 = new NetworkStream(tcpClients[i].Client);
                            stream2.Write(bytes, 0, bytes.Length);
                            stream2.Flush();
                        }
                        break;
                    }
                case (int)CM_All.좌표:
                    {
                        //GPoint gPoint = new GPoint();
                        //gPoint = (GPoint)CM_Library.Deserialize(bytes);
                        for (int i = 0; i < count; i++)
                        {
                            if (i != ti_time)
                            {
                                Stream stream1 = new NetworkStream(tcpClients[i].Client);
                                stream1.Write(bytes, 0, bytes.Length);
                                stream1.Flush();
                            }
                        }
                        break;
                    }
                case (int)CM_All.턴:
                    {
                        ++ti_time; 
                        if(ti_time == 0)
                        {
                            Library.Message mms = new Library.Message();
                            mms.type = (int)CM_All.메시지;
                            mms.MMS = "게임시작";
                            byte[] buffer = new byte[1024 * 4];
                            buffer = CM_Library.Serialize(mms);
                            foreach (var cl in tcpClients)
                            {
                                Stream stream_2 = new NetworkStream(cl.Client);
                                stream_2.Write(buffer, 0, buffer.Length);
                                stream_2.Flush();
                            }
                        }
                        Set_byte(bytes);
                        Problem problem = new Problem();
                        problem.type = (int)CM_All.문제;
                        problem.problem = Allproblem[ti_time].ToString();
                        bytes = CM_Library.Serialize(problem);
                        Stream stream0 = new NetworkStream(tcpClients[ti_time].Client);
                        stream0.Write(bytes, 0, bytes.Length);
                        stream0.Flush();
                        break;
                    }
                case (int)CM_All.정답:
                    {
                        /*클라이언트의 답과 제시한 문제의 답과 같을 경우 점수를 주고 마지막 폼4번에서 점수를 출력해준다. <- 만들어야한다*/
                        Answer answer = new Answer();
                        answer = (Answer)CM_Library.Deserialize(bytes);
                        if (Allproblem[ti_time] == answer.txtAnswer)
                        {
                            User_point[answer.Nicname] += 10;
                            DisplayText(answer.Nicname + " : " + User_point[answer.Nicname].ToString());
                        }
                        //모두에게 각자의 점수를 보내준다
                        Upoint upoint = new Upoint();
                        upoint.Nic = answer.Nicname;
                        upoint.point = User_point[answer.Nicname];
                        upoint.type = (int)CM_All.점수;
                        Set_byte(bytes);
                        bytes = CM_Library.Serialize(upoint);
                        for(int i =0; i < count; i++)
                        {
                            Stream stream_1 = new NetworkStream(tcpClients[i].Client);
                            stream_1.Write(bytes, 0, bytes.Length);
                            stream_1.Flush();
                        }
                        break;
                    }
                case (int)CM_All.처음좌표:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            if (i != ti_time)
                            {
                                Stream stream1 = new NetworkStream(tcpClients[i].Client);
                                stream1.Write(bytes, 0, bytes.Length);
                                stream1.Flush();
                            }
                        }
                        break;
                    }
                case (int)CM_All.그림초기화:
                    {
                        for(int i = 0; i < count; i++)
                        {
                            if(i != ti_time)
                            {
                                Stream stream_2 = new NetworkStream(tcpClients[i].Client);
                                stream_2.Write(bytes, 0, bytes.Length);
                                stream_2.Flush();
                            }
                        }
                        break;
                    }
            }
        }

        private void DisplayText(string text)
        {
            this.Invoke(new MethodInvoker(delegate () {
                this.Log_text.AppendText(text + "\r\n");
            }));
        }
    }

    //이벤트 대리자 핸들러 , 입력이 들어올떄마다 클라이언트로 보내준다
    class Handler_Client
    {
        private byte[] readbuffer = new byte[1024 * 4];
        public delegate void ClientRequestHandler(int Type, byte[] bytes, TcpClient client);
        public event ClientRequestHandler ClientEvent;

        private TcpClient client;
        private Dictionary<TcpClient, int> dictionary_num;

        public void StartClient(TcpClient client, Dictionary<TcpClient,int> dictionary_num)
        {
            this.client = client;
            this.dictionary_num = dictionary_num;

            Thread Type_handler = new Thread(new ThreadStart(DoWork));
            Type_handler.IsBackground = true;
            Type_handler.Start();
        }

        void DoWork() //핸들러 쓰레드
        {
            NetworkStream stream = null;
            try
            {
                int cli_num = dictionary_num[client];
                while (true)
                {
                    try
                    {
                        stream = client.GetStream(); 
                        int bytes = stream.Read(readbuffer,0,readbuffer.Length);
                        CM_Library library = (CM_Library)CM_Library.Deserialize(readbuffer); 
                        if (ClientEvent != null)
                             ClientEvent(library.type, readbuffer, client);
                        Set_byte(readbuffer);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private byte[] Set_byte(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = 0;
            }
            return bytes;
        }
    }
}
