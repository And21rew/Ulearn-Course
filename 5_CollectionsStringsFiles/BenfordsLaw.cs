namespace UlearnCourse.CollectionsStringsFiles
{
    internal class BenfordsLaw
    {
        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (char.IsDigit(symbol) && (i == 0 || !char.IsDigit(text[i - 1])))
                {
                    statistics[symbol - '0']++;
                }
            }

            return statistics;
        }
    }
}