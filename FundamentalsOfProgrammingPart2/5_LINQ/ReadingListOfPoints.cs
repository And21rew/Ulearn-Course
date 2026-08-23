namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class ReadingListOfPoints
    {
        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                .Select(line => line.Split())
                .Select(parts => new Point(int.Parse(parts[0]), int.Parse(parts[1])))
                .ToList();
        }
    }
}