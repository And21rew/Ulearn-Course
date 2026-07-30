namespace UlearnCourse.Arrays
{
    internal class NullOrNotNull
    {
        public static bool CheckFirstElement(int[] array)
        {
            return array != null && array.Length != 0 && array[0] == 0;
        }
    }
}