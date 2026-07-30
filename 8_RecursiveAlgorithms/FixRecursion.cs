namespace UlearnCourse.RecursiveAlgorithms
{
    internal class FixRecursion
    {
        public static void WriteReversed(char[] items, int startIndex = 0)
        {
            if (startIndex >= items.Length)
                return;

            WriteReversed(items, startIndex + 1);
            Console.Write(items[startIndex]);
        }
    }
}