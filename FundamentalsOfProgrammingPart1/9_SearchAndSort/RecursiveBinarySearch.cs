namespace UlearnCourse.FundamentalsOfProgrammingPart1.SearchAndSort
{
    internal class RecursiveBinarySearch
    {
        public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
        {
            if (left == right - 1) return left;
            var m = (left + right) / 2;
            if (array[m] < value)
                return BinSearchLeftBorder(array, value, m, right);
            return BinSearchLeftBorder(array, value, left, m);
        }
    }
}