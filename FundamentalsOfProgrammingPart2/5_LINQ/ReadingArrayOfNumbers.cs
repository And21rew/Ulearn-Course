namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class ReadingArrayOfNumbers
    {
        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(int.Parse)
                .ToArray();
        }
    }
}