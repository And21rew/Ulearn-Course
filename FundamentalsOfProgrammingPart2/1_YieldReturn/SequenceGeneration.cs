namespace UlearnCourse.FundamentalsOfProgrammingPart2.YieldReturn
{
    internal class SequenceGeneration
    {
        public static IEnumerable<int> GenerateCycle(int maxValue)
        {
            var value = 0;

            while (true)
            {
                yield return value;
                value = (value + 1) % maxValue;
            }
        }
    }
}