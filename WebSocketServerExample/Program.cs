using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServerExample
{
	public class Laputa : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs e)
		{
			var msg = e.Data == "BALUS"
				? "I've been balused already..."
				: "I'm not available now.";
			Console.WriteLine(msg);
			Send(msg);
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			var wssv = new WebSocketServer("ws://127.0.0.1:1337");
			wssv.AddWebSocketService<Laputa>("/Laputa");
			wssv.Start();
			Console.ReadKey(true);
			wssv.Stop();
		}
	}
}
