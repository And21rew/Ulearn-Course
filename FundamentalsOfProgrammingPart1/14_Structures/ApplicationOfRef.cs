namespace UlearnCourse.FundamentalsOfProgrammingPart1.Structures
{
    internal class ApplicationOfRef
    {
        public static void WriteAllNumbersFromText(string text)
        {
            var pos = 0;

            while (true)
            {
                SkipSpaces(text, ref pos);
                var num = ReadNumber(text, ref pos);

                if (num == "") 
                    break;

                Console.Write(num + " ");
            }

            Console.WriteLine();
        }
    }
}