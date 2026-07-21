namespace UlearnCourse.Cycles
{
    internal class InSearchOfPowerOfTwo
    {
        public void Main()
        {
            Console.WriteLine(GetMinPowerOfTwoLargerThan(2)); // => 4
            Console.WriteLine(GetMinPowerOfTwoLargerThan(15)); // => 16
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-2)); // => 1
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-100));
            Console.WriteLine(GetMinPowerOfTwoLargerThan(100));

        }

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