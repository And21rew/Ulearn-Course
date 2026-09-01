namespace UlearnCourse.FundamentalsOfProgrammingPart2.GreedyAlgorithms
{
    public class NotGreedyPathFinder : IPathFinder
    {
        private readonly Dictionary<Point, Dictionary<Point, PathWithCost>> paths = new();
        private List<Point> bestPath = new();
        private int maxChests = -1;

        public List<Point> FindPathToCompleteGoal(State state)
        {
            if (state.Chests.Count == 0)
                return new List<Point>();

            var pathFinder = new DijkstraPathFinder();
            var allPoints = new List<Point>(state.Chests) { state.Position };

            foreach (var startPoint in allPoints)
            {
                if (!paths.ContainsKey(startPoint))
                    paths[startPoint] = new Dictionary<Point, PathWithCost>();

                foreach (var path in pathFinder.GetPathsByDijkstra(state, startPoint, state.Chests))
                {
                    if (!path.Start.Equals(path.End))
                        paths[startPoint][path.End] = path;
                }
            }

            if (!paths[state.Position].Any())
                return new List<Point>();

            var startChests = new HashSet<Point>(state.Chests);
            FindPath(state.Energy, state.Position, startChests, 0, new List<Point> { state.Position });

            if (maxChests == -1)
                return new List<Point>();

            var resultPath = new List<Point>();

            for (int i = 0; i < bestPath.Count - 1; i++)
                resultPath.AddRange(paths[bestPath[i]][bestPath[i + 1]].Path.Skip(1));

            return resultPath;
        }

        private void FindPath(int currentEnergy, Point currentPosition, HashSet<Point> leftoverChests, int takenChests, List<Point> points)
        {
            leftoverChests.Remove(currentPosition);
            var foundAny = false;

            foreach (var chest in leftoverChests.ToList())
            {
                if (!paths[currentPosition].ContainsKey(chest))
                    continue;

                var pathCost = paths[currentPosition][chest].Cost;

                if (pathCost > currentEnergy)
                    continue;

                foundAny = true;
                var newPath = new List<Point>(points) { chest };
                var newLeftover = new HashSet<Point>(leftoverChests);
                newLeftover.Remove(chest);

                FindPath(currentEnergy - pathCost, chest, newLeftover, takenChests + 1, newPath);
            }

            if (!foundAny || leftoverChests.Count == 0)
            {
                if (takenChests > maxChests)
                {
                    maxChests = takenChests;
                    bestPath = new List<Point>(points);
                }
            }
        }
    }
}