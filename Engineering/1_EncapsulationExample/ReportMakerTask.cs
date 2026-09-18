namespace UlearnCourse.Engineering.EncapsulationExample
{
    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            var deadline = new DateTime(year, month, day);
            var failuresArray = new Failure[failureTypes.Length];
            var devicesArray = new Device[devices.Count];

            for (int i = 0; i < failureTypes.Length; i++)
            {
                var time = times[i].Select(t => (int)t).ToArray();
                failuresArray[i] = new Failure(deviceId[i], new DateTime(time[2], time[1], time[0]), (FailureType)failureTypes[i]);
            }

            for (int i = 0; i < devices.Count; i++)
            {
                var dict = devices[i];
                devicesArray[i] = new Device((int)dict["DeviceId"], (string)dict["Name"]);
            }

            return FindDevicesFailedBeforeDate(deadline, failuresArray, devicesArray);
        }

        private static List<string> FindDevicesFailedBeforeDate(DateTime deadline, Failure[] failures, Device[] devices)
        {
            var problematicDevices = new HashSet<int>(failures.Where(f => f.IsSerious && f.Time < deadline).Select(f => f.DeviceId));
            var result = devices.Where(d => problematicDevices.Contains(d.Id)).Select(d => d.Name).ToList();

            return result;
        }
    }

    public enum FailureType
    {
        UnexpectedShutdown,
        ShortNonResponding,
        HardwareFailures,
        ConnectionProblems
    }

    public class Device
    {
        public readonly int Id;
        public readonly string Name;

        public Device(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Failure
    {
        public readonly int DeviceId;
        public readonly DateTime Time;
        public readonly FailureType Type;

        public Failure(int deviceId, DateTime time, FailureType type)
        {
            DeviceId = deviceId;
            Time = time;
            Type = type;
        }

        public bool IsSerious => (int)Type % 2 == 0;
    }
}