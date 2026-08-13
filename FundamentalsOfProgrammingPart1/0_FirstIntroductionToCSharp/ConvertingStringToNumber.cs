namespace UlearnCourse.FundamentalsOfProgrammingPart1.FirstIntroductionToCSharp
{
    internal class ConvertingStringToNumber
    {
        public void Main()
        {
            string doubleNumber = "894376.243643";
            double number = double.Parse(doubleNumber);
            Console.WriteLine(number + 1);
        }
    }
}