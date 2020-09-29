using System;
using WebSocketSharp;

namespace WebSocketClient
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ws = new WebSocket("ws://127.0.0.1:1337"))
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