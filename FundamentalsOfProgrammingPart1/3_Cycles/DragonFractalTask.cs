namespace UlearnCourse.FundamentalsOfProgrammingPart1.Cycles
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var angle45 = 45.0 * Math.PI / 180.0;
            var angle135 = 135.0 * Math.PI / 180.0;
            var sin45 = Math.Sin(angle45);
            var cos45 = Math.Cos(angle45);
            var sin135 = Math.Sin(angle135);
            var cos135 = Math.Cos(angle135);
            var sqrt2 = Math.Sqrt(2);

            var x = 1.0;
            var y = 0.0;
            pixels.SetPixel(x, y);

            var random = new Random(seed);

            for (int i = 0; i < iterationsCount; i++)
            {
                double x1;
                double y1;

                var action = random.Next(2);

                if (action == 0)
                {
                    x1 = (x * cos45 - y * sin45) / sqrt2;
                    y1 = (x * sin45 + y * cos45) / sqrt2;
                }
                else
                {
                    x1 = (x * cos135 - y * sin135) / sqrt2 + 1;
                    y1 = (x * sin135 + y * cos135) / sqrt2;
                }

                pixels.SetPixel(x1, y1);

                x = x1;
                y = y1;
            }
        }
    }
}