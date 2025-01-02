

using System.Net.Sockets;
using System.Net;

IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 2000);
UdpClient newsock = new UdpClient(ipep);

Console.WriteLine("Waiting for a client...");

IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);


while (true)
{
    byte[] data = newsock.Receive(ref sender);
    Console.WriteLine($"Bytes {data.Length}:", Convert.ToHexString(data));
}


