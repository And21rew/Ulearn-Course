namespace UlearnCourse.CollectionsStringsFiles
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var ngrams = new Dictionary<string, Dictionary<string, int>>();

            AddNgrams(text, ngrams, 2);
            AddNgrams(text, ngrams, 3);

            foreach (var item in ngrams)
                result[item.Key] = GetMostFrequentWord(item.Value);

            return result;
        }

        private static void AddNgrams(List<List<string>> text, Dictionary<string, Dictionary<string, int>> ngrams, int n)
        {
            foreach (var sentence in text)
            {
                if (sentence.Count < n)
                    continue;

                for (int i = 0; i <= sentence.Count - n; i++)
                {
                    var prefix = GetPrefix(sentence, i, n);
                    var nextWord = sentence[i + n - 1];


                    if (!ngrams.ContainsKey(prefix))
                        ngrams[prefix] = new Dictionary<string, int>();

                    if (!ngrams[prefix].ContainsKey(nextWord))
                        ngrams[prefix][nextWord] = 0;

                    ngrams[prefix][nextWord]++;
                }
            }
        }

        private static string GetPrefix(List<string> sentence, int start, int n)
        {
            if (n == 2)
                return sentence[start];

            return $"{sentence[start]} {sentence[start + 1]}";
        }


        private static string GetMostFrequentWord(Dictionary<string, int> words)
        {
            var result = string.Empty;
            var maxCount = -1;

            foreach (var word in words)
            {
                if (word.Value > maxCount)
                {
                    result = word.Key;
                    maxCount = word.Value;
                }
                else if (word.Value == maxCount)
                {
                    if (string.CompareOrdinal(word.Key, result) < 0)
                        result = word.Key;
                }
            }

            return result;
        }
    }
}