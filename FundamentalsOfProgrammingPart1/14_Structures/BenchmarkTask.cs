namespace UlearnCourse.FundamentalsOfProgrammingPart1.Structures
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    public class Benchmark : IBenchmark
    {
        public double MeasureDurationInMs(ITask task, int repetitionCount)
        {
            task.Run();

            var watch = new Stopwatch();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            watch.Start();

            for (int i = 0; i < repetitionCount; i++)
                task.Run();

            watch.Stop();

            return (double)watch.ElapsedMilliseconds / repetitionCount;
        }
    }

    [TestFixture]
    public class RealBenchmarkUsageSample
    {
        [Test]
        public void StringConstructorFasterThanStringBuilder()
        {
            var benchmark = new Benchmark();
            var repetitionCount = 10000;

            var constructorTime = benchmark.MeasureDurationInMs(new StringConstructorMakeString(), repetitionCount);
            var builderTime = benchmark.MeasureDurationInMs(new StringBuilderMakeString(), repetitionCount);

            ClassicAssert.Less(constructorTime, builderTime);
        }
    }

    public class StringConstructorMakeString() : ITask
    {
        public void Run()
        {
            new string('a', 10000);
        }
    }

    public class StringBuilderMakeString() : ITask
    {
        public void Run()
        {
            var strBuilder = new StringBuilder();

            for (int i = 0; i < 10000; i++)
                strBuilder.Append('a');

            strBuilder.ToString();
        }
    }
}