namespace UlearnCourse.Cycles
{
    internal class InSearchOfPowerOfTwo
    {
        private static int GetMinPowerOfTwoLargerThan(int number)
        {
            int degree = 0;
            int result = 1;

            while (result <= number)
            {
                degree++;
                result = (int)Math.Pow(2, degree);
            }

            return result;
        }
    }
}