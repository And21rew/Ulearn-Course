namespace UlearnCourse.FirstIntroductionToCSharp
{
    internal class MethodsAreBeingSought
    {
        private static string GetLastHalf(string text)
        {
            return text.Substring(text.Length / 2).Replace(" ", "");
        }
    }
}