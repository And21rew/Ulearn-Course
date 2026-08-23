namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    public static class ExtensionsTask
    {
        /// <summary>
        /// Медиана списка из нечетного количества элементов — это серединный элемент списка после сортировки.
        /// Медиана списка из четного количества элементов — это среднее арифметическое 
        /// двух серединных элементов списка после сортировки.
        /// </summary>
        /// <exception cref="InvalidOperationException">Если последовательность не содержит элементов</exception>
        public static double Median(this IEnumerable<double> items)
        {
            var sorted = items.OrderBy(x => x).ToArray();

            if (sorted.Length == 0)
                throw new InvalidOperationException();

            var mid = sorted.Length / 2;

            return sorted.Length % 2 != 0 ? sorted[mid] : (sorted[mid - 1] + sorted[mid]) / 2.0;
        }

        /// <returns>
        /// Возвращает последовательность, состоящую из пар соседних элементов.
        /// Например, по последовательности {1,2,3} метод должен вернуть две пары: (1,2) и (2,3).
        /// </returns>
        public static IEnumerable<(T First, T Second)> Bigrams<T>(this IEnumerable<T> items)
        {
            var previousItem = default(T);
            var isFirstIteration = true;

            foreach (var item in items)
            {
                if (isFirstIteration) isFirstIteration = false;
                else yield return (previousItem, item);
                previousItem = item;
            }
        }
    }
}