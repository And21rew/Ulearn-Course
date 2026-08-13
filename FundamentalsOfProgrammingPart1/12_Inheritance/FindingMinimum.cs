namespace UlearnCourse.FundamentalsOfProgrammingPart1.Inheritance
{
    internal class FindingMinimum
    {
        static object Min(Array args)
        {
            Array.Sort(args);

            return args.GetValue(0);
        }
    }
}