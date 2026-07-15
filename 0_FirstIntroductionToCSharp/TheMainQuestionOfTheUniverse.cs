using System;

namespace UlearnCourse.FirstIntroductionToCSharp
{
    internal class TheMainQuestionOfTheUniverse
    {
        public void Main()
        {
            Print(GetSquare(42));
        }

        private static int GetSquare(int number)
        {
            return (int)Math.Pow(number, 2);
        }

        private static void Print(int number)
        {
            Console.WriteLine(number);
        }
    }
}