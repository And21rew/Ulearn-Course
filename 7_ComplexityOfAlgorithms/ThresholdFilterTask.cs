namespace UlearnCourse.ComplexityOfAlgorithms
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var sizeX = original.GetLength(0);
            var sizeY = original.GetLength(1);

            var pixels = new List<double>();

            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    pixels.Add(original[x, y]);

            pixels.Sort();

            var result = new double[sizeX, sizeY];
            var whiteCount = (int)(pixels.Count * whitePixelsFraction);

            if (whiteCount == 0)
                return result;

            var threshold = pixels[^whiteCount];

            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    result[x, y] = original[x, y] >= threshold ? 1.0 : 0.0;

            return result;
        }
    }
}