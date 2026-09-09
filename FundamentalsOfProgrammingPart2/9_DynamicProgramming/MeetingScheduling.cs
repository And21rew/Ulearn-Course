namespace UlearnCourse.FundamentalsOfProgrammingPart2.DynamicProgramming
{
    internal class MeetingScheduling
    {
        public static int GetOptimalScheduleGain(params Event[] events)
        {
            var fakeBorderEvent = new Event { StartTime = int.MinValue, FinishTime = int.MinValue, Price = 0 };
            events = events.Concat(new[] { fakeBorderEvent }).OrderBy(e => e.FinishTime).ToArray();

            var opt = new int[events.Length];
            opt[0] = 0;

            for (var k = 1; k < events.Length; k++)
            {
                for (var e = 0; e < events.Length; e++)
                    if (events[e].FinishTime <= events[k].StartTime)
                        opt[k] = Math.Max(opt[k - 1], opt[e] + events[k].Price);
            }

            return opt.Last();
        }
    }
}