namespace UlearnCourse.Arrays
{
    internal class SearchingArrayInArray
    {
        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }

        private static bool ContainsAtIndex(int[] array, int[] subArray, int startIndexInArray)
        {
            for (int i = 0; i < subArray.Length; i++)
                if (subArray[i] != array[i + startIndexInArray])
                    return false;

            return true;
        }
    }
}