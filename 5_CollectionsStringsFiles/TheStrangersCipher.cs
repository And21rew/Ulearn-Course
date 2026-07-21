using System.Collections.Generic;

namespace UlearnCourse.CollectionsStringsFiles
{
    internal class TheStrangersCipher
    {
        private static string DecodeMessage(string[] lines)
        {
            var uppercaseWords = new List<string>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var words = line.Split(' ');

                foreach (var word in words)
                {
                    if (char.IsUpper(word[0]))
                        uppercaseWords.Add(word);
                }
            }

            uppercaseWords.Reverse();

            return string.Join(" ", uppercaseWords);
        }
    }
}