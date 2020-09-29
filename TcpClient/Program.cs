using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаем локальную конечную точку
			IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
			IPEndPoint endPoint = new IPEndPoint(ipAddr, 8888);

			System.Net.Sockets.TcpClient newClient = new System.Net.Sockets.TcpClient(){};

			// Для создания соединения с сервером надо вызвать connect()
			newClient.Connect(endPoint);

			var stream = newClient.GetStream();
			byte[] sendBytes = Encoding.UTF8.GetBytes("gettabs");
			stream.Write(sendBytes, 0, sendBytes.Length);
			Task.Factory.StartNew(() =>
			{
				// Server Reply
				if (stream.CanRead)
				{
					// Buffer to store the response bytes.
					byte[] readBuffer = new byte[newClient.ReceiveBufferSize];

					// String that will contain full server reply
					StringBuilder fullServerReply = new StringBuilder();

					int numberOfBytesRead = 0;

					do
					{
						numberOfBytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
						fullServerReply.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, numberOfBytesRead));
						Console.WriteLine(fullServerReply.ToString());
					} while (stream.DataAvailable);
				}
			});
			newClient.Close();

			Console.ReadLine();
		}
	}
}
