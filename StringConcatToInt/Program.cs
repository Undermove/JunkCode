using System;

namespace StringConcatToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "56";
            string s2 = "44";

            Console.WriteLine(Convert.ToInt32(s1+s2));
            Console.ReadLine();
        }
    }
}
