using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {4, 8, 2, 5, 8};
            BubbleSorter bubbleSorter = new BubbleSorter(array);

            Console.WriteLine("source array");
            PrintArray(array);

            Console.WriteLine("Asc array");
            PrintArray(bubbleSorter.GetSortedArray(SortingOrder.Ascenging));

            Console.WriteLine("Desc array");
            PrintArray(bubbleSorter.GetSortedArray(SortingOrder.Descending));

            Console.ReadLine();
        }

        private static void PrintArray(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
