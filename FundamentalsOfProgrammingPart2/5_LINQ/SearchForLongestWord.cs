namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class SearchForLongestWord
    {
        public static string GetLongest(IEnumerable<string> words)
        {
            return words.MinBy(w => (-w.Length, w));
        }
    }
}