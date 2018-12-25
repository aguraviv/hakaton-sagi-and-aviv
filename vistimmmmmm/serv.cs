using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

public class serv
{
    public static List<DateTime> list_of_hacked = new List<DateTime>();


    public static void add_to_list_and_check_her(String sir1)
    {
        list_of_hacked.Add(DateTime.Now);
        Console.WriteLine("number of hacked is..." + list_of_hacked.Count);
        if (list_of_hacked.Count >= 10)
        {
            
            if((list_of_hacked[2] - list_of_hacked[0]).Seconds <1)
            {
                Console.WriteLine("you hacked me " + sir1);

            }
            else
            {
                list_of_hacked.RemoveAt(0);
            }
        }
    }
    public static void Main()
    {
        
        string pasword = "1234567";
        while (true)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                String sir = "";
                for (int i = 0; i < k; i++)
                    sir = sir + Convert.ToChar(b[i]);
                if (sir == pasword)
                {
                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("access granted"));
                    //Console.WriteLine("\nSent Acknowledgement");
                    byte[] b1 = new byte[100];
                    int k1 = s.Receive(b1);
                    Console.WriteLine("Recieved...");
                    String sir1 = "";
                    for (int i = 0; i < k1; i++)
                        sir1 = sir1 + Convert.ToChar(b1[i]);
                    add_to_list_and_check_her(sir1);
                }
                else
                {
                    Console.WriteLine(sir);


                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("The string was recieved by the server."));
                    Console.WriteLine("\nSent Acknowledgement");
                }
                /* clean up */
                s.Close();
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }

}