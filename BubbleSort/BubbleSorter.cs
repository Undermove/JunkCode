using System;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class BubbleSorter
    {
        private readonly int[] array;
        private int[] ascArray;
        private int[] descArray;

        public BubbleSorter(int[] array)
        {
            this.array = array;
        }

        private void Swap(int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        private void BubbleSort(SortingOrder order)
        {
            if (order == SortingOrder.Ascenging)
            {
                ascArray = array;
                bool isSwapped = true;
                while (isSwapped)
                {
                    isSwapped = false;
                    for (int i = 0; i < ascArray.Length - 1; i++)
                    {
                        if (ascArray[i + 1] >= ascArray[i])
                        {
                            continue;
                        }
                        Swap(i + 1, i);
                        isSwapped = true;
                    }
                }
            }
            else
            {
                descArray = array;
                bool isSwapped = true;
                while (isSwapped)
                {
                    isSwapped = false;
                    for (int i = 0; i < descArray.Length - 1; i++)
                    {
                        if (descArray[i + 1] <= descArray[i])
                        {
                            continue;
                        }
                        Swap(i + 1, i);
                        isSwapped = true;
                    }
                }
            }
        }

        public int[] GetSortedArray(SortingOrder sortingOrder)
        {
            switch (sortingOrder)
            {
                case SortingOrder.Ascenging:
                    if (ascArray != null)
                    {
                        return ascArray;
                    }
                    BubbleSort(SortingOrder.Ascenging);
                    return ascArray;
                case SortingOrder.Descending:
                    if (descArray != null)
                    {
                        return descArray;
                    }
                    BubbleSort(SortingOrder.Descending);
                    return descArray;
            }

            throw new Exception("Strange behavior");
        }
    }
}