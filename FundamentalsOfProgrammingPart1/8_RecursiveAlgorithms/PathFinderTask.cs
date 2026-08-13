using System.Drawing;

namespace UlearnCourse.FundamentalsOfProgrammingPart1.RecursiveAlgorithms
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var size = checkpoints.Length;
            var shortestPathValue = double.MaxValue;
            var shortestPath = new int[size];

            MakeTrivialPermutation(new int[size], shortestPath, 1, 0, ref shortestPathValue, checkpoints);

            return shortestPath;
        }

        private static void MakeTrivialPermutation(
            int[] permutation,
            int[] bestPermutation,
            int position,
            double currentPathValue,
            ref double shortestPathValue,
            Point[] checkpoints)
        {
            if (currentPathValue >= shortestPathValue)
                return;

            if (position == permutation.Length)
            {
                permutation.CopyTo(bestPermutation, 0);
                shortestPathValue = currentPathValue;
                return;
            }

            for (int i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);

                if (index == -1)
                {
                    permutation[position] = i;
                    MakeTrivialPermutation(
                        permutation,
                        bestPermutation,
                        position + 1,
                        currentPathValue + PointExtensions.DistanceTo(checkpoints[permutation[position]], checkpoints[permutation[position - 1]]),
                        ref shortestPathValue,
                        checkpoints);
                }
            }
        }
    }
}