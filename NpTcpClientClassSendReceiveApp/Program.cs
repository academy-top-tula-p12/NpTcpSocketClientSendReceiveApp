// TcpClient

using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress address = IPAddress.Loopback;
int port = 5000;

using TcpClient client = new();

await client.ConnectAsync(address, port);
Console.WriteLine($"Client {client.Client.LocalEndPoint} connect to server {client.Client.RemoteEndPoint}");

byte[] buffer = new byte[1024];

using Stream stream = client.GetStream();

int byeCount = await stream.ReadAsync(buffer);

Console.WriteLine($"Server {client.Client.RemoteEndPoint}: {Encoding.UTF8.GetString(buffer)}");

Console.Write("Input message: ");
string message = Console.ReadLine();
buffer = Encoding.UTF8.GetBytes(message);

await stream.WriteAsync(buffer);