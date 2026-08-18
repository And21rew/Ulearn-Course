namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    public delegate bool TryGet<T1, T2>(T1 str, Action<T1> action, out T2 number);
}