using System.Diagnostics;

namespace CallConsoleCommandFromCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = "calc.exe";

            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            proc.Arguments = @"/k start notepad.exe";

            Process.Start(proc);
        }
    }
}
