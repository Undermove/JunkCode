using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class InsertionSorter : ISorter
    {
        private int[] array;

        public InsertionSorter(int[] array)
        {
            this.array = array;
        }

        public int[] GetSortedArray(SortingOrder sortingOrder)
        {
            
        }

        private void InsertionSort()
        {
            int currentSorted = 0;
            while (currentSorted < array.Length)
            {
                for (int i = currentSorted; i < array.Length; i++)
                {
                    if (array[currentSorted] < array[i])
                    {
                        FindIndexAndInsert();
                        currentSorted = i;
                        break;
                    }
                }
            }
            
        }

        private void FindIndexAndInsert()
        {
            throw new NotImplementedException();
        }
    }
}
