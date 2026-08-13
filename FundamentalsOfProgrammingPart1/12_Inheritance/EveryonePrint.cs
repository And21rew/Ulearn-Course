namespace UlearnCourse.FundamentalsOfProgrammingPart1.Inheritance
{
    internal class EveryonePrint
    {
        public static void Print(params object[] arguments)
        {
            for (var i = 0; i < arguments.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(arguments[i]);
            }
            Console.WriteLine();
        }
    }
}