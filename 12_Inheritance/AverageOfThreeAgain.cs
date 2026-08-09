namespace UlearnCourse.Inheritance
{
    internal class AverageOfThreeAgain
    {
        static IComparable MiddleOfThree(IComparable a, IComparable b, IComparable c)
        {
            var array = new[] { a, b, c };
            Array.Sort(array);

            return array[1];
        }
    }
}