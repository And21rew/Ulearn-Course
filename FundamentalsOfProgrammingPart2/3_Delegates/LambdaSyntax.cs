namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    internal class LambdaSyntax
    {
        private static readonly Func<int> zero = () => 0;
        private static readonly Func<object, string> toString = (obj) => obj?.ToString();
        private static readonly Func<double, double, double> add = (x, y) => x + y;
        private static readonly Action<object> print = (obj) => Console.WriteLine(toString(obj));
    }
}