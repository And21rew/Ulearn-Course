namespace UlearnCourse.FundamentalsOfProgrammingPart1.FirstIntroductionToCSharp
{
    internal class TypeConversionErrors
    {
        public void Main()
        {
            double pi = Math.PI;
            int tenThousand = 10000;
            double tenThousandPi = pi * tenThousand;
            double roundedTenThousandPi = Math.Round(tenThousandPi);
            int integerPartOfTenThousandPi = (int)tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}