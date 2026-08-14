namespace UlearnCourse.FundamentalsOfProgrammingPart2.YieldReturn
{
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var queue = new Queue<double>();
            var sum = 0.0;

            foreach (var point in data)
            {
                var value = point.OriginalY;
                queue.Enqueue(value);
                sum += value;

                if (queue.Count > windowWidth)
                    sum -= queue.Dequeue();

                yield return point.WithAvgSmoothedY(sum / queue.Count);
            }
        }
    }
}