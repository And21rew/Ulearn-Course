namespace UlearnCourse.FundamentalsOfProgrammingPart1.Cycles
{
    internal class Frame
    {
        private static void WriteTextWithBorder(string text)
        {
            var upDownLines = "+" + new string('-', text.Length + 2) + "+";
            var middleLine = $"| {text} |";

            Console.WriteLine($"{upDownLines}\n{middleLine}\n{upDownLines}");
        }
    }
}