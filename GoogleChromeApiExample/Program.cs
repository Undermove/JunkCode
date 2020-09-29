using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MasterDevs.ChromeDevTools;
using MasterDevs.ChromeDevTools.Protocol.Chrome.DOM;
using MasterDevs.ChromeDevTools.Protocol.Chrome.Page;
using EnableCommand = MasterDevs.ChromeDevTools.Protocol.Chrome.Page.EnableCommand;

namespace GoogleChromeApiExample
{
	class Program
    {
		const int ViewPortWidth = 1440;
		const int ViewPortHeight = 900;
		private static void Main(string[] args)
		{
			Task.Run(async () =>
			{
				// synchronization
				var screenshotDone = new ManualResetEventSlim();

				// STEP 1 - Run Chrome
				var chromeProcessFactory = new ChromeProcessFactory(new StubbornDirectoryCleaner());
				using (var chromeProcess = chromeProcessFactory.Create(9222, true))
				{
					// STEP 2 - Create a debugging session
					var sessionInfo = (await chromeProcess.GetSessionInfo()).LastOrDefault();
					var chromeSessionFactory = new ChromeSessionFactory();
					var chromeSession = chromeSessionFactory.Create(sessionInfo.WebSocketDebuggerUrl);

					chromeSession.Subscribe<DomContentEventFiredEvent>(domContentEvent =>
					{
						System.Console.WriteLine("DomContentEvent: " + domContentEvent.Timestamp);
					});

					chromeSession.SendAsync(new NavigateCommand
					{
						Url = "http://www.google.com"
					}).Wait();
				}
			}).Wait();
		}
	}
}
