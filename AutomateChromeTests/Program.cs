using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDevs.ChromeDevTools;
using MasterDevs.ChromeDevTools.Protocol.Chrome.DOM;
using MasterDevs.ChromeDevTools.Protocol.Chrome.Page;
using EnableCommand = MasterDevs.ChromeDevTools.Protocol.Chrome.Page.EnableCommand;

namespace AutomateChromeTests
{
	internal class Program
	{
		const int ViewPortWidth = 1440;
		const int ViewPortHeight = 900;
		private static void Main(string[] args)
		{
			//var chromeProcessFactory = new ChromeProcessFactory(new StubbornDirectoryCleaner());
			//var chromeProcess = chromeProcessFactory.Create(9222, true);

			//var sessionInfo = chromeProcess.GetSessionInfo().Result.LastOrDefault();
			//var chromeSessionFactory = new ChromeSessionFactory();
			//var chromeSession = chromeSessionFactory.Create(sessionInfo.WebSocketDebuggerUrl);


			var chromeSessionFactory = new ChromeSessionFactory();

			var chromeSession = chromeSessionFactory.Create("ws://localhost:9222/devtools/page/4291E3A0809C17B129D49A08B7063BF1");

			chromeSession.Subscribe<DomContentEventFiredEvent>(domContentEvent =>
			{
				Console.WriteLine("DomContentEvent: " + domContentEvent.Timestamp);
			});

			chromeSession.SendAsync(new NavigateCommand
			{
				Url = "http://www.google.com"
			}).Wait();
		}
	}
}
