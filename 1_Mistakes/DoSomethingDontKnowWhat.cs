namespace UlearnCourse.Mistakes
{
    internal class DoSomethingDontKnowWhat
    {
        private static int Decode(string number)
        {
            return int.Parse(number.Replace(".", "")) % 1024;
        }
    }
}