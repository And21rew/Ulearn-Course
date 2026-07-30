using System.Text;

namespace UlearnCourse.CollectionsStringsFiles
{
    static class SentencesParserTask
    {
        private static readonly char[] SentenceSeparators = ['.', '!', '?', ';', ':', '(', ')'];

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentenses = text.Split(SentenceSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var sentence in sentenses)
            {
                var words = ParseWords(sentence);

                if (words.Count > 0)
                    sentencesList.Add(words);
            }

            return sentencesList;
        }

        private static List<string> ParseWords(string sentence)
        {
            var wordsList = new List<string>();
            var word = new StringBuilder();

            foreach (var symbol in sentence)
            {
                if (char.IsLetter(symbol) || symbol == '\'')
                {
                    word.Append(symbol);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        wordsList.Add(word.ToString().ToLower());
                        word.Clear();
                    }
                }
            }

            if (word.Length > 0)
                wordsList.Add(word.ToString().ToLower());

            return wordsList;
        }
    }
}