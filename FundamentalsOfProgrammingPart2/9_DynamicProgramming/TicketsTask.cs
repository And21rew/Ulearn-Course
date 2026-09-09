using System.Numerics;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.DynamicProgramming
{
    public class TicketsTask
    {
        public static BigInteger Solve(int halfLen, int totalSum)
        {
            if (totalSum % 2 != 0)
                return BigInteger.Zero;

            var targetSum = totalSum / 2;

            var dp = new BigInteger[targetSum + 1];

            for (int i = 0; i <= targetSum; i++)
                dp[i] = BigInteger.Zero;

            dp[0] = BigInteger.One;

            for (int digit = 0; digit < halfLen; digit++)
            {
                var next = new BigInteger[targetSum + 1];

                for (int i = 0; i <= targetSum; i++)
                    next[i] = BigInteger.Zero;

                for (int s = 0; s <= targetSum; s++)
                {
                    if (dp[s] == 0) continue;

                    for (int d = 0; d <= 9 && s + d <= targetSum; d++)
                        next[s + d] += dp[s];
                }

                dp = next;
            }

            var ways = dp[targetSum];

            return ways * ways;
        }
    }
}