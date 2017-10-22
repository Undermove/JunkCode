using System;
using Microsoft.Win32;

namespace GetOsVersionFriendly
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(FriendlyName());
            Console.ReadLine();
        }

        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);

                if (rk == null)
                {
                    return "";
                }

                return (string) rk.GetValue(key);
            }
            catch
            {
                return "";
            }
        }

        public static string FriendlyName()
        {
            string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");

            if (productName != "")
            {
                return (productName.StartsWith("Microsoft") ? "" : "Microsoft ") + productName +
                       (csdVersion != "" ? " " + csdVersion : "");
            }

            return "";
        }
    }
}
