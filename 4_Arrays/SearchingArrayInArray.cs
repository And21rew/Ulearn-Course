namespace UlearnCourse.Arrays
{
    internal class SearchingArrayInArray
    {
        private static bool ContainsAtIndex(int[] array, int[] subArray, int startIndexInArray)
        {
            for (int i = 0; i < subArray.Length; i++)
                if (subArray[i] != array[i + startIndexInArray])
                    return false;

            return true;
        }
    }
}