namespace UlearnCourse.FundamentalsOfProgrammingPart2.YieldReturn
{
    public static class MovingMaxTask
    {
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var deque = new LinkedList<(double value, int index)>();
            var position = 0;

            foreach (var point in data)
            {
                var value = point.OriginalY;

                while (deque.Count > 0 && deque.First.Value.index < position - windowWidth + 1)
                    deque.RemoveFirst();

                while (deque.Count > 0 && deque.Last.Value.value <= value)
                    deque.RemoveLast();

                deque.AddLast((value, position));

                yield return point.WithMaxY(deque.First.Value.value);
                position++;
            }
        }
    }
}