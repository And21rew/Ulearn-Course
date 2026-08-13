namespace UlearnCourse.FundamentalsOfProgrammingPart1.Arrays
{
    internal static class HistogramTask
    {
        private const int DayCountInMouth = 31;

        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var labelX = new string[DayCountInMouth];
            for (int i = 0; i < labelX.Length; i++)
                labelX[i] = $"{i + 1}";

            var nameCountInAllNames = new double[DayCountInMouth];

            foreach (var nameData in names)
            {
                var birthDay = nameData.BirthDate.Day;

                if (birthDay == 1)
                    continue;

                if (nameData.Name == name)
                    nameCountInAllNames[birthDay - 1]++;
            }

            return new HistogramData(
                $"Рождаемость людей с именем '{name}'",
                labelX,
                nameCountInAllNames);
        }
    }
}