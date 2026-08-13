namespace UlearnCourse.FundamentalsOfProgrammingPart1.ComplexityOfAlgorithms
{
    public static class GrayscaleTask
    {
        public static double[,] ToGrayscale(Pixel[,] original)
        {
            var sizeX = original.GetLength(0);
            var sizeY = original.GetLength(1);
            var grayscale = new double[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    var pixel = original[i, j];
                    grayscale[i, j] = (0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B) / 255;
                }
            }

            return grayscale;
        }
    }
}