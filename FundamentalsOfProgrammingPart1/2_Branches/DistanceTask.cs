namespace UlearnCourse.FundamentalsOfProgrammingPart1.Branches
{
    public static class DistanceTask
    {
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            var abX = bx - ax;
            var abY = by - ay;
            var apX = x - ax;
            var apY = y - ay;


            if (abX == 0 && abY == 0)
                return Math.Sqrt(apX * apX + apY * apY);


            var projectionCoefficient = (apX * abX + apY * abY) / (abX * abX + abY * abY);

            if (projectionCoefficient < 0)
                return Math.Sqrt(apX * apX + apY * apY);


            if (projectionCoefficient > 1)
            {
                var bpX = x - bx;
                var bpY = y - by;

                return Math.Sqrt(bpX * bpX + bpY * bpY);
            }


            return Math.Abs(abX * apY - abY * apX) / Math.Sqrt(abX * abX + abY * abY);
        }
    }
}