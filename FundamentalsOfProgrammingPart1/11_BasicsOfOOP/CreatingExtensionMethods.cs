namespace UlearnCourse.FundamentalsOfProgrammingPart1.BasicsOfOOP
{
    public static class StringExtensions
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
}