namespace UlearnCourse.FundamentalsOfProgrammingPart1.Arrays
{
    internal class MaximumIndex
    {
        public static int MaxIndex(double[] array)
        {
            var maxIndex = -1;
            var maxValue = double.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxIndex = i;
                    maxValue = array[i];
                }
            }

            return maxIndex;
        }
    }
}