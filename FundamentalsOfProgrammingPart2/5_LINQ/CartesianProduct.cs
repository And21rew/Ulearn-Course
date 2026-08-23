using System.Drawing;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class CartesianProduct
    {
        public static IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 };
            return d
                .SelectMany(dx => d.Select(dy => new Point(p.X + dx, p.Y + dy))) 
                .Where(neighbour => !neighbour.Equals(p));
        }
    }
}