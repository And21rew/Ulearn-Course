namespace UlearnCourse.DataIntegrity
{
    public class Ratio
    {
        public readonly int Numerator;
        public readonly int Denominator;
        public readonly double Value;

        public Ratio(int num, int den)
        {
            if (den <= 0)
                throw new ArgumentException();

            Numerator = num;
            Denominator = den;
            Value = (double)Numerator / Denominator;
        }
    }
}