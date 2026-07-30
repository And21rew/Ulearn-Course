using System.Drawing;

namespace UlearnCourse.Branches
{
    public static class RectanglesTask
    {
        public static bool AreIntersected(Rectangle r1, Rectangle r2) =>
            !(r1.Right < r2.Left || r2.Right < r1.Left || r1.Bottom < r2.Top || r2.Bottom < r1.Top);

        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (!AreIntersected(r1, r2))
                return 0;

            var width = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
            var height = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);

            return width * height;
        }

        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            var r1InsideR2 = r1.Left >= r2.Left && r1.Top >= r2.Top && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom;

            if (r1InsideR2)
                return 0;

            var r2InsideR1 = r2.Left >= r1.Left && r2.Top >= r1.Top && r2.Right <= r1.Right && r2.Bottom <= r1.Bottom;

            if (r2InsideR1)
                return 1;

            return -1;
        }
    }
}