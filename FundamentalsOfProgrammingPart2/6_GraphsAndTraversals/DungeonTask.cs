namespace UlearnCourse.FundamentalsOfProgrammingPart2.GraphsAndTraversals
{
    public class DungeonTask
    {
        public static MoveDirection[] FindShortestPath(Map map)
        {
            var pathsFromStart = BfsFromPoint(map, map.InitialPosition);
            var pathsFromExit = BfsFromPoint(map, map.Exit);

            Chest bestChest = null;
            int minTotalDistance = int.MaxValue;
            byte maxValue = 0;

            foreach (var chest in map.Chests)
            {
                var location = chest.Location;

                if (pathsFromStart.TryGetValue(location, out var pathFromStart) && pathsFromExit.TryGetValue(location, out var pathFromExit))
                {
                    var totalDistance = pathFromStart.Length + pathFromExit.Length;

                    if (totalDistance < minTotalDistance || (totalDistance == minTotalDistance && chest.Value > maxValue))
                    {
                        minTotalDistance = totalDistance;
                        maxValue = chest.Value;
                        bestChest = chest;
                    }
                }
            }

            if (bestChest != null)
            {
                var pointsToChest = RestorePoints(pathsFromStart[bestChest.Location]);
                pointsToChest.Reverse();

                var pointsFromChest = RestorePoints(pathsFromExit[bestChest.Location]);

                if (pointsFromChest.Count > 0)
                    pointsFromChest.RemoveAt(0);

                var fullPath = pointsToChest.Concat(pointsFromChest).ToList();
                return ConvertToDirections(fullPath);
            }

            if (pathsFromStart.ContainsKey(map.Exit))
            {
                var directPath = RestorePoints(pathsFromStart[map.Exit]);
                directPath.Reverse();
                return ConvertToDirections(directPath);
            }

            return new MoveDirection[0];
        }

        private static Dictionary<Point, SinglyLinkedList<Point>> BfsFromPoint(Map map, Point start)
        {
            var paths = new Dictionary<Point, SinglyLinkedList<Point>>();
            var queue = new Queue<SinglyLinkedList<Point>>();
            var startPath = new SinglyLinkedList<Point>(start);

            paths[start] = startPath;
            queue.Enqueue(startPath);

            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                var currentPoint = currentPath.Value;

                foreach (var offset in Walker.PossibleDirections)
                {
                    var nextPoint = currentPoint + offset;

                    if (map.InBounds(nextPoint) && map.Dungeon[nextPoint.X, nextPoint.Y] == MapCell.Empty && !paths.ContainsKey(nextPoint))
                    {
                        var newPath = new SinglyLinkedList<Point>(nextPoint, currentPath);
                        paths[nextPoint] = newPath;
                        queue.Enqueue(newPath);
                    }
                }
            }

            return paths;
        }

        private static List<Point> RestorePoints(SinglyLinkedList<Point> path)
        {
            var points = new List<Point>();
            var current = path;

            while (current != null)
            {
                points.Add(current.Value);
                current = current.Previous;
            }

            return points;
        }

        private static MoveDirection[] ConvertToDirections(List<Point> points)
        {
            if (points.Count < 2)
                return new MoveDirection[0];

            var directions = new MoveDirection[points.Count - 1];

            for (int i = 0; i < points.Count - 1; i++)
            {
                var offset = points[i + 1] - points[i];
                directions[i] = Walker.ConvertOffsetToDirection(offset);
            }

            return directions;
        }
    }
}