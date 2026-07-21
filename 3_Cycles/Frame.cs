namespace UlearnCourse.Cycles
{
    internal class Frame
    {
        public void Main()
        {
            WriteTextWithBorder("Menu:");
            WriteTextWithBorder("");
            WriteTextWithBorder(" ");
            WriteTextWithBorder("Game Over!");
            WriteTextWithBorder("Select level:");
        }

        private static void WriteTextWithBorder(string text)
        {
            var upDownLines = "+" + new string('-', text.Length + 2) + "+";
            var middleLine = $"| {text} |";

            Console.WriteLine($"{upDownLines}\n{middleLine}\n{upDownLines}");
        }
    }
}