using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class CreatingReverseIndex
    {
        public static ILookup<string, int> BuildInvertedIndex(Document[] documents)
        {
            return documents
                .SelectMany(doc => Regex.Split(doc.Text.ToLower(), @"\W+")
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Distinct()
                    .Select(word => (Word: word, Id: doc.Id)))
                .ToLookup(pair => pair.Word, pair => pair.Id);
        }
    }
}