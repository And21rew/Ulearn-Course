using Microsoft.VisualBasic;

namespace UlearnCourse.FundamentalsOfProgrammingPart1.Structures
{
    public class Experiments
    {
        public static ChartData BuildChartDataForArrayCreation(IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartData(new ArrayCreationFactory(), benchmark, repetitionsCount, "Create array");
        }

        public static ChartData BuildChartDataForMethodCall(IBenchmark benchmark, int repetitionsCount)
        {
            return BuildChartData(new MethodCallFactory(), benchmark, repetitionsCount, "Call method with argument");
        }

        private static ChartData BuildChartData(ICreationFactory factory, IBenchmark benchmark, int repetitionsCount, string title)
        {
            var fieldCounts = Constants.FieldCounts;

            var classesTimes = new List<ExperimentResult>();
            var structuresTimes = new List<ExperimentResult>();

            foreach (var fieldCount in fieldCounts)
            {
                var durationInMs = benchmark.MeasureDurationInMs(factory.GetClassCreation(fieldCount), repetitionsCount);
                classesTimes.Add(new ExperimentResult(fieldCount, durationInMs));
            }

            foreach (var fieldCount in fieldCounts)
            {
                var durationInMs = benchmark.MeasureDurationInMs(factory.GetStructCreation(fieldCount), repetitionsCount);
                structuresTimes.Add(new ExperimentResult(fieldCount, durationInMs));
            }

            return new ChartData
            {
                Title = title,
                ClassPoints = classesTimes,
                StructPoints = structuresTimes,
            };
        }
    }

    public interface ICreationFactory
    {
        public ITask GetClassCreation(int i);

        public ITask GetStructCreation(int i);
    }

    public class ArrayCreationFactory() : ICreationFactory
    {
        public ITask GetClassCreation(int i) => new ClassArrayCreationTask(i);

        public ITask GetStructCreation(int i) => new StructArrayCreationTask(i);
    }

    public class MethodCallFactory() : ICreationFactory
    {
        public ITask GetClassCreation(int i) => new MethodCallWithClassArgumentTask(i);

        public ITask GetStructCreation(int i) => new MethodCallWithStructArgumentTask(i);
    }
}