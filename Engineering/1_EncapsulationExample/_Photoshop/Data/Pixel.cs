namespace MyPhotoshop
{
    public struct Pixel
    {
        public double R { get; }
        public double G { get; }
        public double B { get; }

        public Pixel(double r, double g, double b)
        {
            R = CheckValue(r);
            G = CheckValue(g);
            B = CheckValue(b);
        }

        private double CheckValue(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("The value must be between 0 and 1");

            return value;
        }

        public static double Trim(double value) => (value < 0) ? 0 : (value > 1) ? 1 : value;

        public static Pixel operator *(Pixel pixel, double number)
        {
            return new Pixel(Trim(pixel.R * number), Trim(pixel.G * number), Trim(pixel.B * number));
        }

        public static Pixel operator *(double number, Pixel pixel)
        {
            return pixel * number;
        }
    }
}
