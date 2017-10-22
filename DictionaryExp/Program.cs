using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> outerDict = new Dictionary<string, Dictionary<string, int>>();

            string keyOuter = "a";
            string keyInner = "b";

            // Add elements into internal dictionary via TryGetValue
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                //////////////////////////
                Dictionary<string, int> innerDictionary;
                if (outerDict.TryGetValue(keyOuter, out innerDictionary))
                {
                    innerDictionary[keyInner] = 1;
                }
                else
                {
                    outerDict.Add(keyOuter, new Dictionary<string, int>() { { keyInner, 2 } });
                }
                /////////////////////////
            }
            s.Stop();
            Console.WriteLine(s.ElapsedTicks);

            // Add via ContainsKey
            s = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                /////////////////////////
                if (outerDict.ContainsKey(keyOuter))
                {
                    if (outerDict[keyOuter].ContainsKey(keyInner))
                    {
                        outerDict[keyOuter][keyInner] = 5;
                    }
                    else
                    {
                        outerDict[keyOuter].Add(keyInner, 5);
                    }
                }
                else
                {
                    outerDict.Add(keyOuter, new Dictionary<string, int>());
                    outerDict[keyOuter].Add(keyInner, 5);
                }
                /////////////////////////
            }
            s.Stop();
            Console.WriteLine(s.ElapsedTicks);

            Console.ReadLine();
        }
    }
}
