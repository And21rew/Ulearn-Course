namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    internal class LambdaSyntax2
    {
        static Func<T1, T3> Combine<T1, T2, T3>(Func<T1, T2> f, Func<T2, T3> g)
        {
            return T1 => g(f(T1));
        }
    }
}