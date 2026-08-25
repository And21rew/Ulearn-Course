namespace UlearnCourse.FundamentalsOfProgrammingPart2.GraphsAndTraversals
{
    internal class FindingCycleInUndirectedGraph
    {
        public static bool HasCycle(List<Node> graph)
        {
            var visited = new HashSet<Node>();
            var finished = new HashSet<Node>();
            var stack = new Stack<Node>();
            visited.Add(graph.First());
            stack.Push(graph.First());

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var nextNode in node.IncidentNodes)
                {
                    if (finished.Contains(nextNode))
                        continue;
                    else if (visited.Contains(nextNode))
                        return true;

                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
                finished.Add(node);
            }

            return false;
        }
    }
}