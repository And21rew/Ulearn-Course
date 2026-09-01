namespace UlearnCourse.FundamentalsOfProgrammingPart2.GreedyAlgorithms
{
    public class DijkstraData
    {
        public Point Previous;
        public int Price;
    }

    public class DijkstraPathFinder
    {
        public IEnumerable<PathWithCost> GetPathsByDijkstra(State state, Point start, IEnumerable<Point> targets)
        {
            var chests = new HashSet<Point>(targets);
            var notVisitedCells = new HashSet<Point> { start };
            var visitedCells = new HashSet<Point>();
            var track = new Dictionary<Point, DijkstraData> { [start] = new DijkstraData { Previous = new Point(-1, -1), Price = 0 } };

            while (chests.Count > 0)
            {
                var toOpen = GetToOpenWithBestPrice(track, notVisitedCells);

                if (toOpen.Item1 == new Point(-1, -1))
                    yield break;

                FindIncidentsPoint(toOpen.Item1, state, visitedCells, notVisitedCells, track);

                foreach (var item in FindPath(chests, toOpen.Item1, track))
                    yield return item;
            }
        }

        private (Point, double) GetToOpenWithBestPrice(Dictionary<Point, DijkstraData> track, IEnumerable<Point> notVisitedCells)
        {
            var bestPrice = double.PositiveInfinity;
            var toOpen = new Point(-1, -1);

            foreach (var point in notVisitedCells)
            {
                if (track.TryGetValue(point, out var data) && data.Price < bestPrice)
                {
                    bestPrice = data.Price;
                    toOpen = point;
                }
            }

            return (toOpen, bestPrice);
        }

        private void FindIncidentsPoint(Point toOpen, State state, HashSet<Point> visitedCells, HashSet<Point> notVisitedCells, Dictionary<Point, DijkstraData> track)
        {
            var directions = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

            foreach (var (dx, dy) in directions)
            {
                var probablyPoint = new Point(toOpen.X + dx, toOpen.Y + dy);

                if (state.InsideMap(probablyPoint) && !state.IsWallAt(probablyPoint) && probablyPoint != toOpen && !visitedCells.Contains(probablyPoint))
                {
                    notVisitedCells.Add(probablyPoint);
                    var currentPrice = track[toOpen].Price + state.CellCost[probablyPoint.X, probablyPoint.Y];

                    if (!track.ContainsKey(probablyPoint) || track[probablyPoint].Price > currentPrice)
                        track[probablyPoint] = new DijkstraData { Previous = toOpen, Price = currentPrice };
                }
            }

            notVisitedCells.Remove(toOpen);
            visitedCells.Add(toOpen);
        }

        private IEnumerable<PathWithCost> FindPath(HashSet<Point> chests, Point toOpen, Dictionary<Point, DijkstraData> track)
        {
            if (!chests.Contains(toOpen))
                yield break;

            chests.Remove(toOpen);
            var pathToChest = new List<Point>();

            for (var target = toOpen; target != new Point(-1, -1); target = track[target].Previous)
                pathToChest.Add(target);

            pathToChest.Reverse();

            yield return new PathWithCost(track[toOpen].Price, pathToChest.ToArray());
        }
    }
}