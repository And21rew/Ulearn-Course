namespace UlearnCourse.FundamentalsOfProgrammingPart1.Mistakes
{
    internal class MinimumFunction
    {
        private static string GetMinX(int a, int b, int c)
        {
            if (a > 0 || (a == 0 && b == 0))
                return (-b / (2.0 * a)).ToString();
            else
                return "Impossible";
        }
    }
}