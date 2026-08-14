namespace UlearnCourse.FundamentalsOfProgrammingPart2.YieldReturn
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var prevPointExpSmoothedY = double.NaN;

            foreach (var point in data)
            {
                if (double.IsNaN(prevPointExpSmoothedY))
                    prevPointExpSmoothedY = point.OriginalY;

                var yExp = alpha * point.OriginalY + (1 - alpha) * prevPointExpSmoothedY;
                yield return point.WithExpSmoothedY(yExp);
                prevPointExpSmoothedY = yExp;
            }
        }
    }
}