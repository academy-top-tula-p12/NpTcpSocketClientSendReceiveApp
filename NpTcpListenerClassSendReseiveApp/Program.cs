// TcpListener

using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress address = IPAddress.Loopback;
int port = 5000;

IPEndPoint endPoint = new(address, port);

TcpListener listener = new(endPoint);

try
{
    listener.Start();
    Console.WriteLine($"Server {listener.LocalEndpoint} start...");

    using var client = await listener.AcceptTcpClientAsync();
    Console.WriteLine($"Server accept client {client.Client.RemoteEndPoint}");
    var stream = client.GetStream();

    byte[] buffer = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
    await stream.WriteAsync(buffer);
    Console.WriteLine($"Server send time data to client {client.Client.RemoteEndPoint}");

    int byteCount = 0;
    StringBuilder message = new();

    do
    {
        byteCount = await stream.ReadAsync(buffer);
        message.Append(Encoding.UTF8.GetString(buffer));
    } while (byteCount > 0);

    Console.WriteLine($"Client {client.Client.RemoteEndPoint}: {message}");
}
finally
{
    listener.Stop();
}