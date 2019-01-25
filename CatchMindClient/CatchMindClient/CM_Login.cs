using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;

namespace CatchMindClient
{
    public partial class CM_Login : Form
    {
        public CM_Login()
        {
            InitializeComponent();
        }

        public TcpClient client;
        
        private bool Success = false;
        
        private void btn_Log_Click(object sender, EventArgs e)
        {
            
            //--로그인 성공여부//
            string Path = "SELECT * FROM CM_User";
            
            try
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand sqlComm = new SqlCommand();
                string connectingsql =
                    "Server = 172.30.1.60,1433; database = CM_data ; uid = qornwh ; pwd = qweasd12";
                conn.ConnectionString = connectingsql;
                conn.Open();

                sqlComm.CommandText = Path;
                sqlComm.Connection = conn;
                SqlDataReader sd = sqlComm.ExecuteReader();
                while (sd.Read())
                {
                    if (sd["CM_id"].ToString() == textBox1.Text && sd["CM_pw"].ToString() == textBox2.Text)
                    {
                        Success = true; break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("오류발생");
            }
            finally
            {
                if (Success == true)
                {
                    string ip = "172.30.1.60";
                    client = new TcpClient();
                    client.Connect(ip, 9876);
                    Stream stream = new NetworkStream(client.Client);
                    byte[] bytes = new byte[1024 * 4];
                    Login login = new Login();
                    login.type = (int)CM_All.닉네임;
                    login.id = textBox1.Text;
                    login.pw = textBox2.Text;
                    bytes = CM_Library.Serialize(login);
                    stream = client.GetStream();
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    CM_Ready ready = new CM_Ready(client, login.id);
                    this.Hide();
                    ready.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("로그인 실패^^");
                }
            }
        }

        private void btn_member_Click(object sender, EventArgs e)
        {

        }
    }
}
