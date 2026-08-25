namespace UlearnCourse.FundamentalsOfProgrammingPart2.GraphsAndTraversals
{
    public class BfsTask
    {
        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Chest[] chests)
        {
            var chestLocations = new HashSet<Point>(chests.Select(c => c.Location));
            var visited = new HashSet<Point>();
            var queue = new Queue<SinglyLinkedList<Point>>();
            var startPath = new SinglyLinkedList<Point>(start);

            queue.Enqueue(startPath);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                var currentPoint = currentPath.Value;

                if (chestLocations.Contains(currentPoint))
                    yield return currentPath;

                foreach (var offset in Walker.PossibleDirections)
                {
                    var nextPoint = currentPoint + offset;

                    if (map.InBounds(nextPoint) && map.Dungeon[nextPoint.X, nextPoint.Y] == MapCell.Empty && !visited.Contains(nextPoint))
                    {
                        visited.Add(nextPoint);

                        var newPath = new SinglyLinkedList<Point>(nextPoint, currentPath);
                        queue.Enqueue(newPath);
                    }
                }
            }
        }
    }
}