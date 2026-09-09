namespace UlearnCourse.FundamentalsOfProgrammingPart2.DynamicProgramming
{
    public class LevenshteinCalculator
    {
        public List<ComparisonResult> CompareDocumentsPairwise(List<DocumentTokens> documents)
        {
            var result = new List<ComparisonResult>();

            for (int i = 0; i < documents.Count; i++)
                for (int j = i + 1; j < documents.Count; j++)
                    result.Add(new ComparisonResult(documents[i], documents[j], LevenshteinDistance(documents[i], documents[j])));

            return result;
        }

        private double LevenshteinDistance(DocumentTokens first, DocumentTokens second)
        {
            var previousRow = Enumerable.Range(0, second.Count + 1).Select(i => (double)i).ToArray();
            var currentRow = new double[second.Count + 1];

            for (int i = 1; i <= first.Count; i++)
            {
                currentRow[0] = i;

                for (int j = 1; j <= second.Count; j++)
                {
                    var deleteCost = previousRow[j] + 1;
                    var insertCost = currentRow[j - 1] + 1;
                    var replaceCost = previousRow[j - 1] + TokenDistanceCalculator.GetTokenDistance(first[i - 1], second[j - 1]);
                    currentRow[j] = Math.Min(deleteCost, Math.Min(insertCost, replaceCost));
                }

                previousRow = currentRow.ToArray();
            }

            return previousRow[second.Count];
        }
    }
}