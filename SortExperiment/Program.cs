using System;
using System.Collections.Generic;

namespace SortExperiment
{
    class Program
    {
        static void Main()
        { 
            List<MajorMarkets> list = new List<MajorMarkets>();

            list.Sort(Comparison);
        }

        private static int Comparison<T>(T x, T y)
        {
            if (x > y)
        }
    }

    public class Comparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            throw new NotImplementedException();
        }
    }

    public enum MajorMarkets
    {
        Unknown = 0,
        USMARKET = 1,
        MICEX = 2,
        RTS = 3,
        UX = 4,
        VIRTUAL = 5,
        OPRA = 6,
        CME = 7,
        EUREX = 8,
        BTCE = 9,
        FOREX = 10
    }
}
