using System.Net.Sockets;
using System.Net;
using System.Text;

using Socket client = new(AddressFamily.InterNetwork, 
                            SocketType.Stream, 
                            ProtocolType.Tcp);
IPAddress address = IPAddress.Loopback;
int port = 5000;

//Console.Write("Input data string: ");
////string name = Console.ReadLine();
//string? dataString = Console.ReadLine();

try
{
    // connect to server
    await client.ConnectAsync(address, port);

    // unstrategy send data to server
    //byte[] nameBuffer = Encoding.UTF8.GetBytes(name);
    //await client.SendAsync(nameBuffer);
    //Console.WriteLine($"We send name {name} to server");


    // send data with size of data
    //byte[] dataBuffer = Encoding.UTF8.GetBytes(dataString);
    ////await client.SendAsync(BitConverter.GetBytes(dataBuffer.Length));
    //await client.SendAsync(dataBuffer);

    //Console.WriteLine($"We send to server {dataBuffer.Length} bytes : {dataString}");

    // receive data from server
    //byte[] buffer = new byte[1024];
    //int bites = await client.ReceiveAsync(buffer);
    //Console.WriteLine($"Server answer in {Encoding.UTF8.GetString(buffer)}");
    byte[] buffer;

    while (true)
    {
        Console.Write("Input data string: ");
        string? dataString = Console.ReadLine() + '\n';

        if (dataString == "\n") break;
        
        buffer = Encoding.UTF8.GetBytes(dataString);
        await client.SendAsync(buffer);
    }

    buffer = Encoding.UTF8.GetBytes("<END>");
    await client.SendAsync(buffer);
    
}
catch(Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}