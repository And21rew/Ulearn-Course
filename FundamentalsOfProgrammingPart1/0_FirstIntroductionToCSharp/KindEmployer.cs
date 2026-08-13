namespace UlearnCourse.FundamentalsOfProgrammingPart1.FirstIntroductionToCSharp
{
    internal class KindEmployer
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            return $"Hello, {name}, your salary is {Math.Ceiling(salary)}";
        }
    }
}