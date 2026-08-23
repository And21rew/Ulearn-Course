namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    public class ParsingTask
    {
        private static readonly char separator = ';';

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
        /// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
        /// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
        public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines) =>
          lines?.Skip(1)
                .Select(line => line.Split(separator))
                .Select(TryParseSlide)
                .Where(slide => slide != null)
                .ToDictionary(slide => slide.SlideId);

        private static SlideRecord TryParseSlide(string[] parts)
        {
            if ((parts.Length != 3) ||
                (!int.TryParse(parts[0], out int slideId)) ||
                (!Enum.TryParse(parts[1], true, out SlideType type)))
                return null;

            return new SlideRecord(slideId, type, parts[2]);
        }

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка — заголовочная.</param>
        /// <param name="slides">Словарь информации о слайдах по идентификатору слайда. 
        /// Такой словарь можно получить методом ParseSlideRecords</param>
        /// <returns>Список информации о посещениях</returns>
        /// <exception cref="FormatException">Если среди строк есть некорректные</exception>
        public static IEnumerable<VisitRecord> ParseVisitRecords(IEnumerable<string> lines, IDictionary<int, SlideRecord> slides) =>
            lines?.Skip(1)
                  .Select(line => TryParseVisit(line, slides));

        private static VisitRecord TryParseVisit(string line, IDictionary<int, SlideRecord> slides)
        {
            var parts = line.Split(separator);

            if (parts.Length != 4 ||
                !int.TryParse(parts[0], out var id) ||
                !int.TryParse(parts[1], out var slideId) ||
                !DateTime.TryParse(parts[2], out var date) ||
                !DateTime.TryParse(parts[3], out var time) ||
                !slides.TryGetValue(slideId, out var slide))
                throw new FormatException($"Wrong line [{line}]");

            return new VisitRecord(id, slideId, date.Add(time.TimeOfDay), slide.SlideType);
        }
    }
}