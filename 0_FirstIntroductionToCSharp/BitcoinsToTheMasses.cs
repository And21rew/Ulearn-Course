namespace UlearnCourse.FirstIntroductionToCSharp
{
    internal class BitcoinsToTheMasses
    {
        public void Main()
        {
            double amount = 1.11;
            int peopleCount = 60;
            int totalMoney = (int)Math.Round(amount * peopleCount);
            Console.WriteLine(totalMoney);
        }
    }
}