using System.Text.RegularExpressions;

namespace UlearnCourse.FundamentalsOfProgrammingPart2._5_LINQ
{
    internal class SortingTuples
    {
        public static List<string> GetSortedWords(string text)
        {
            return Regex.Split(text, @"\W+")
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => word.ToLower())
                .Distinct()
                .Select(word => (word.Length, word))
                .OrderBy(tuple => tuple)
                .Select(tuple => tuple.word)
                .ToList();
        }
    }
}