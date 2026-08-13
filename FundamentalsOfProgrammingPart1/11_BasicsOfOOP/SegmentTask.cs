namespace UlearnCourse.FundamentalsOfProgrammingPart1.BasicsOfOOP
{
    namespace Geometry;

    public class Vector
    {
        public double X;
        public double Y;
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector a, Vector b)
        {
            return new Vector
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }

        public static double GetLength(Segment segment)
        {
            var a = segment.Begin;
            var b = segment.End;
            var dx = b.X - a.X;
            var dy = b.Y - a.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var segment1 = new Segment
            {
                Begin = segment.Begin,
                End = vector
            };

            var segment2 = new Segment
            {
                Begin = vector,
                End = segment.End
            };

            var sum = GetLength(segment1) + GetLength(segment2);

            return sum == GetLength(segment);
        }
    }
}