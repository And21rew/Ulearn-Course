namespace UlearnCourse.FundamentalsOfProgrammingPart2._8_MultithreadedProgramming
{
    public partial class Bot
    {
        public Rocket GetNextMove(Rocket rocket)
        {
            var tasks = CreateTasks(rocket);
            var results = Task.WhenAll(tasks).GetAwaiter().GetResult();
            var bestResult = results.OrderByDescending(r => r.Score).First();

            return rocket.Move(bestResult.Turn, level);
        }

        public List<Task<(Turn Turn, double Score)>> CreateTasks(Rocket rocket)
        {
            var tasks = new List<Task<(Turn, double)>>();

            int iterationsPerThread = iterationsCount / threadsCount;
            int remainder = iterationsCount % threadsCount;

            for (int i = 0; i < threadsCount; i++)
            {
                var currentIterations = iterationsPerThread;

                if (i < remainder)
                    currentIterations = +1;

                var threadSeed = random.Next();
                var threadRandom = new Random(threadSeed);

                tasks.Add(Task.Run(() => SearchBestMove(rocket, threadRandom, currentIterations)));
            }

            return tasks;
        }
    }
}