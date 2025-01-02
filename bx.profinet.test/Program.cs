using System.Net.Sockets;
using System.Net;

namespace bx.profinet.test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("IP: ");
            //string ip = Console.ReadLine();

            //f10.profinet.opentcp.S7Client plc = new opentcp.S7Client();
            //plc.SetConnectionType(1);
            //int con = plc.ConnectTo(ip, 0, 1);
            //Console.WriteLine("Connected: " + con);
            //byte[] temp = new byte[50];

            //while (true)
            //{
            //    plc.EBRead(6, 2, temp);
            //}

            //plc.Disconnect();



            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 2000);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);


            while (true)
            {
                byte[] data = newsock.Receive(ref sender);
                Console.WriteLine($"Bytes {data.Length}:", Convert.ToHexString(data));
            }
        }
    }
}
