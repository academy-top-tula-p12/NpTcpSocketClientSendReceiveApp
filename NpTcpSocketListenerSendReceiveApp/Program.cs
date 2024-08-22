using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress address = IPAddress.Loopback;
int port = 5000;

IPEndPoint endPoint = new(address, port);

using Socket listener = new(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);

char marker = '$';

try
{
    listener.Bind(endPoint);
    listener.Listen();
    Console.WriteLine($"Server {listener.LocalEndPoint} wait...");

    int count = 3;
    while(count > 0)
    {
        // accept client
        using var client = await listener.AcceptAsync();

        // unstrategy receive data from client
        //byte[] buffer = new byte[1024];
        //int bytes = await client.ReceiveAsync(buffer);
        //Console.WriteLine($"We accept clent {Encoding.UTF8.GetString(buffer)} : {client.RemoteEndPoint}");


        // receive size data and data
        //byte[] sizeBuffer = new byte[4];
        //await client.ReceiveAsync(sizeBuffer);
        //int size = BitConverter.ToInt32(sizeBuffer, 0);

        //byte[] buffer = new byte[size];
        //int bytes = await client.ReceiveAsync(buffer);

        //string message = Encoding.UTF8.GetString(buffer);
        //Console.WriteLine($"Client {client.RemoteEndPoint} send to us {size} bytes: {message}");


        // recieive data with marker
        //List<byte> buffer = new();
        //byte[] byteData = new byte[1];

        //while(true)
        //{
        //    var byteCount = await client.ReceiveAsync(byteData);
        //    if (byteCount == 0 || byteData[0] == marker) break;

        //    buffer.Add(byteData[0]);
        //}

        //string message = Encoding.UTF8.GetString(buffer.ToArray());
        //Console.WriteLine($"Client {client.RemoteEndPoint} send to us {buffer.ToArray().Length} bytes: {message}");


        // send data to client
        //byte[] timeBuffer = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
        //await client.SendAsync(timeBuffer);
        //Console.WriteLine($"Server send time to client {client.RemoteEndPoint}");

        count--;
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

listener.Close();
