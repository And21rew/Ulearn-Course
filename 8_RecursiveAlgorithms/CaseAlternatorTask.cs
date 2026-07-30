namespace UlearnCourse.RecursiveAlgorithms
{
    public class CaseAlternatorTask
    {
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            result = result.Distinct().ToList();

            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
            }
            else
            {
                var symbol = word[startIndex];

                if (char.IsLetter(symbol))
                {
                    word[startIndex] = char.ToLower(symbol);
                    AlternateCharCases(word, startIndex + 1, result);
                    word[startIndex] = char.ToUpper(symbol);
                    AlternateCharCases(word, startIndex + 1, result);
                }
                else
                {
                    word[startIndex] = symbol;
                    AlternateCharCases(word, startIndex + 1, result);
                }
            }
        }
    }
}