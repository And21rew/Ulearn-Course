namespace UlearnCourse.FundamentalsOfProgrammingPart1.Arrays
{
    internal class EvenArray
    {
        public static int[] GetFirstEvenNumbers(int count)
        {
            var result = new int[count];

            for (int i = 0; i < result.Length; i++)
                result[i] = 2 * (i + 1);

            return result;
        }
    }
}