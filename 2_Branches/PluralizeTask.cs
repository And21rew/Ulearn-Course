namespace UlearnCourse.Branches
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            var lastDigit = count % 10;
            var twoLastDigits = count % 100;

            if (twoLastDigits >= 11 && twoLastDigits <= 14)
                return "рублей";
            else if (lastDigit == 1)
                return "рубль";
            else if (lastDigit >= 2 && lastDigit <= 4)
                return "рубля";

            return "рублей";
        }
    }
}