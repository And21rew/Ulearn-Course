namespace UlearnCourse.SearchAndSort
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            while (left < right - 1)
            {
                var m = (left + right) / 2;
                if (phrases[m].CompareTo(prefix) > 0 && !phrases[m].StartsWith(prefix))
                    right = m;
                else
                    left = m;
            }

            return right;
        }
    }
}