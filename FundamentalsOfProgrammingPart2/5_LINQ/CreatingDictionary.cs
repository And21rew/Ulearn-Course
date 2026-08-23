using System.Text.RegularExpressions;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class CreatingDictionary
    {
        public static string[] GetSortedWords(params string[] textLines)
        {
            return textLines
                .Where(line => !string.IsNullOrEmpty(line))
                .SelectMany(line => Regex.Split(line, @"\W+"))
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(word => word.ToLower())
                .Distinct()
                .OrderBy(word => word, StringComparer.Ordinal)
                .ToArray();
        }
    }
}