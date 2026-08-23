using System.Text.RegularExpressions;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class CreatingFrequencyDictionary
    {
        public static (string, int)[] GetMostFrequentWords(string text, int count)
        {
            return Regex.Split(text, @"\W+")
                .Where(word => word != "")
                .Select(word => word.ToLower())
                .GroupBy(word => word)
                .Select(g => (Word: g.Key, Count: g.Count()))
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Word)
                .Take(count)
                .ToArray();
        }
    }
}