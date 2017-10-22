namespace BubbleSort
{
    public interface ISorter
    {
        /// <summary>
        /// Gets sorted list of integers by specified oreder
        /// </summary>
        /// <returns>Sorted array</returns>
        int[] GetSortedArray(SortingOrder sortingOrder);
    }
}