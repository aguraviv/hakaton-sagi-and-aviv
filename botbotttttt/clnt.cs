using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;

public class clnt
{

    public static void Main()
    {
        /*
        try
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");

            tcpclnt.Connect("127.0.0.1", 8001);
            // use the ipaddress as in the server program

            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");

            String str = Console.ReadLine();
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));

            Thread.Sleep(50000);
            tcpclnt.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
        */

        now_we_hack("127.0.0.1", 8001, "1234567", "aviv&sagi the kings");
    }



    public static void now_we_hack(String ip, int port, String pw, String source_server)
    {
        try
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");

            tcpclnt.Connect(ip, port);
            // use the ipaddress as in the server program

            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");

            String str = pw;
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");
            
            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);
            String sir1 = "";
            for (int i = 0; i < k; i++)
                sir1 = sir1 + Convert.ToChar(bb[i]);
            if (sir1 == "access granted")
            {
                Console.WriteLine(sir1);
                String str1 = "you have been hacked by aviv&sagigever";
                Stream stm1 = tcpclnt.GetStream();

                ASCIIEncoding asen1 = new ASCIIEncoding();
                byte[] ba1 = asen1.GetBytes(str1);
                stm1.Write(ba1, 0, ba1.Length);
            }
            

            Thread.Sleep(50000);
            tcpclnt.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }

}