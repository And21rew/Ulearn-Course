using System.Collections.Generic;
using System.Linq;

namespace UlearnCourse.CollectionsStringsFiles
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            var phraseWords = phraseBeginning.Split(' ').ToList();

            for (int i = 0; i < wordsCount; i++)
            {
                var secondToLastWord = GetWordFromEnd(phraseWords, 2);
                var lastWord = GetWordFromEnd(phraseWords, 1);

                if (nextWords.TryGetValue(CompleteNextWordsKey(secondToLastWord, lastWord), out string? nextWordTwoKey))
                {
                    phraseWords.Add(nextWordTwoKey);
                }
                else
                {
                    if (nextWords.TryGetValue(lastWord, out string? nextWordOneKey))
                    {
                        phraseWords.Add(nextWordOneKey);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return string.Join(" ", phraseWords);
        }

        private static string GetWordFromEnd(List<string> phrase, int numberFromEnd) =>
            phrase.Count >= numberFromEnd ? phrase[^numberFromEnd] : string.Empty;

        private static string CompleteNextWordsKey(string secondToLastWord, string lastWord) => $"{secondToLastWord} {lastWord}".Trim();
    }
}
