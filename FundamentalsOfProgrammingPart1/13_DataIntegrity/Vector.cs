namespace UlearnCourse.FundamentalsOfProgrammingPart1.DataIntegrity
{
    public class Vector
    {
        public double X;
        public double Y;
        public double Length { get { return Math.Sqrt(X * X + Y * Y); } }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
        }
    }
}