using System.Net.Sockets;
using System.Net;
using bx.profinet.opentcp;

namespace bx.profinet.test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("IP: ");
            string ip = Console.ReadLine();

            bx.profinet.opentcp.S7Client plc = new opentcp.S7Client();
            plc.SetConnectionType(1);
            int con = plc.ConnectTo(ip, 0, 1);
            Console.WriteLine("Connected: " + con);
            byte[] temp = new byte[50];

            while (true)
            {
                //read 1 byte from DB6.DBW2
                plc.DBRead(6, 2, 1, temp);

                //read 2 bytes from I100
                plc.IRead(100, 2, temp);

                //read DINT from DB20.DBD5
                plc.DBRead(20, 5, 4, temp); //read the 4 bytes we need
                S7.GetDIntAt(temp, 0); //convert to int

                plc.ReadBits(S7Consts.S7AreaM, 0, 10, 2, temp);
            }

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
