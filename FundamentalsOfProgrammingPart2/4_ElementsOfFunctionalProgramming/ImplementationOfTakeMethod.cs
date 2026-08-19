namespace UlearnCourse.FundamentalsOfProgrammingPart2.ElementsOfFunctionalProgramming
{
    internal class ImplementationOfTakeMethod
    {
        private static IEnumerable<T> Take<T>(IEnumerable<T> source, int count)
        {
            if (count <= 0)
                yield break;

            foreach (var item in source)
            {
                yield return item;
                count--;

                if (count == 0)
                    yield break;
            }
        }
    }
}