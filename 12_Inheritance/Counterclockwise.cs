namespace UlearnCourse.Inheritance
{
    public class ClockwiseComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return Math.Atan2(-p1.Y, -p1.X).CompareTo(Math.Atan2(-p2.Y, -p2.X));
        }
    }
}