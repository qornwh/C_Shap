using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Library
{
    public enum CM_All
    {
        메시지 = 0,
        닉네임,
        로그인,
        턴,
        게임상태,
        정답,
        점수,
        레디, //Ready_Off
        자기번호, //Ready_On
        클라이언트라벨, //Ready
        좌표,
        문제,
        처음좌표,
        그림초기화
    }

    [Serializable]
    public class CM_Library
    {
        public int length;
        public int type;

        public CM_Library()
        {
            length = 0;
            type = 0;
        }

        public static byte[] Serialize(object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            byte[] bytes = ms.ToArray();
            ms.Flush();
            return bytes;
        }//End Serialize 

        public static object Deserialize(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            foreach(byte by in bytes)
            {
                ms.WriteByte(by);
            }
            ms.Position = 0;
            Object o = bf.Deserialize(ms);
            ms.Close();
            return o;
        }//End Deserialize
    }

    [Serializable]
    public class Login : CM_Library
    {
        public string id;
        public string pw;

        public Login()
        {
            id = "";
            pw = "";
        }
    }//End Login 

    [Serializable]
    public class Ready : CM_Library
    {
        public int clinetNumber;
        public int client_sum;  //클라이언트 수
        public string[] nickNameList;
        public Ready()
        {
            client_sum = 0;
            clinetNumber = 0;
            nickNameList = new string[4];
        }
    }//클라이언트라벨

    [Serializable]
    public class Ready_On : CM_Library
    {
        public bool[] On;
        public Ready_On()
        {
            On = new bool[4];
        }
    }//자기번호

    [Serializable]
    public class Ready_Off : CM_Library
    {
        public bool On;
        public Ready_Off()
        {
            On = false;
        }
    }//레디

    [Serializable]
    public class Message : CM_Library
    {
        public string MMS;
        public Message()
        {
            MMS = "";
        }
    }//메세지

    [Serializable]
    public class GPoint : CM_Library
    {
        public int X;
        public int Y;
        public int gColor;
        public int gWidth;
        public GPoint()
        {
            X = 0;
            Y = 0;
            gColor = 0;
            gColor = 1;
        }
    }//좌표

    [Serializable]
    public class Turn : CM_Library
    {
        public bool Nic;
        public Turn()
        {
            Nic = false;
        }
    }

    [Serializable]
    public class Answer : CM_Library
    {
        public string txtAnswer;
        public string Nicname;
        public Answer()
        {
            txtAnswer = "";
            Nicname = "";
        }
    }//내가 쓴답

    [Serializable]
    public class Problem : CM_Library
    {
        public string problem;
        public Problem()
        {
            problem = "";
        }
    }//문제 내주기

    [Serializable]
    public class Upoint : CM_Library
    {
        public string Nic;
        public int point;
        public Upoint()
        {
            Nic = "";
            point = 0;
        }
    }//유저의 점수 받기

    [Serializable]
    public class resetImage: CM_Library
    {
        public bool rsImage;
        public resetImage()
        {
            rsImage = false;
        }
    }
}
