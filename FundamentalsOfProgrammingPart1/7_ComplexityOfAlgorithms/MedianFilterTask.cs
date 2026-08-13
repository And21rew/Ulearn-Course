namespace UlearnCourse.FundamentalsOfProgrammingPart1.ComplexityOfAlgorithms
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            var sizeX = original.GetLength(0);
            var sizeY = original.GetLength(1);
            var result = new double[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    var neighbors = GetPixelNeighbors(x, y, sizeX, sizeY, original);
                    result[x, y] = GetMedianFromArray(neighbors);
                }
            }

            return result;
        }

        private static double[] GetPixelNeighbors(int x, int y, int sizeX, int sizeY, double[,] original)
        {
            var neighbors = new List<double>(9);

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    var nx = x + dx;
                    var ny = y + dy;

                    if (IsPixelInArrayBorders(nx, ny, sizeX, sizeY))
                        neighbors.Add(original[nx, ny]);
                }
            }

            neighbors.Sort();

            return neighbors.ToArray();
        }

        private static bool IsPixelInArrayBorders(int x, int y, int sizeX, int sizeY) =>
            x >= 0 && x < sizeX && y >= 0 && y < sizeY;

        private static double GetMedianFromArray(double[] array)
        {
            if (array.Length % 2 == 0)
            {
                var right = array.Length / 2;
                var left = right - 1;

                return (array[right] + array[left]) / 2;
            }

            return array[array.Length / 2];
        }
    }
}