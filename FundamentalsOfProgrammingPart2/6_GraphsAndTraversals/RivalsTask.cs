namespace UlearnCourse.FundamentalsOfProgrammingPart2.GraphsAndTraversals
{
    public class RivalsTask
    {
        private readonly static List<Point> incidentPoints = new() { new(0, 1), new(0, -1), new(1, 0), new(-1, 0) };

        public static IEnumerable<OwnedLocation> AssignOwners(Map map)
        {
            var chests = new HashSet<Point>(map.Chests);
            var visited = new HashSet<Point>();
            var queue = new Queue<(Point point, int owner, int distance)>();

            for (var i = 0; i < map.Players.Length; i++)
            {
                var start = map.Players[i];

                if (map.InBounds(start) && map.Maze[start.X, start.Y] != MapCell.Wall)
                {
                    if (visited.Add(start))
                    {
                        queue.Enqueue((start, i, 0));
                        yield return new OwnedLocation(i, start, 0);
                    }
                }
            }

            while (queue.Count > 0)
            {
                var (currentPoint, owner, distance) = queue.Dequeue();

                if (chests.Contains(currentPoint))
                    continue;

                foreach (var direction in incidentPoints)
                {
                    var nextPoint = new Point(currentPoint.X + direction.X, currentPoint.Y + direction.Y);

                    if (map.InBounds(nextPoint) && map.Maze[nextPoint.X, nextPoint.Y] != MapCell.Wall && visited.Add(nextPoint))
                    {
                        var newDistance = distance + 1;
                        queue.Enqueue((nextPoint, owner, newDistance));
                        yield return new OwnedLocation(owner, nextPoint, newDistance);
                    }
                }
            }
        }
    }
}