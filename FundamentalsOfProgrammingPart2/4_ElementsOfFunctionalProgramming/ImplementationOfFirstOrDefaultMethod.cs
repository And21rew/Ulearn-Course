namespace UlearnCourse.FundamentalsOfProgrammingPart2.ElementsOfFunctionalProgramming
{
    internal class ImplementationOfFirstOrDefaultMethod
    {
        private static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            foreach (var element in source)
                if (filter(element))
                    return element;

            return default(T);
        }
    }
}