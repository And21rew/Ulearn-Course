namespace UlearnCourse.FundamentalsOfProgrammingPart2.QueuesStacksGenerics
{
    internal class MaximumInArray
    {
        static T Max<T>(T[] source) where T : IComparable
        {
            if (source.Length == 0)
                return default(T);

            var maxValue = source[0];

            for (int i = 1; i < source.Length; i++)
                if (source[i].CompareTo(maxValue) > 0)
                    maxValue = source[i];

            return maxValue;
        }
    }
}