namespace UlearnCourse.FundamentalsOfProgrammingPart1.CollectionsStringsFiles
{
    internal class SplitAndJoin
    {
        public static string ReplaceIncorrectSeparators(string text)
        {
            return string.Join("\t", text.Split(new char[] { ' ', ';', ':', '-', ',' }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}