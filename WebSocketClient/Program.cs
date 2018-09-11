using System;
using WebSocketSharp;

namespace WebSocketClient
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ws = new WebSocket("ws://localhost:9999"))
			{
				ws.OnMessage += (sender, e) =>
					Console.WriteLine("Laputa says: " + e.Data);

				ws.Connect();
				ws.Send("BALUS");
				Console.ReadKey(true);
			}
		}
	}
}