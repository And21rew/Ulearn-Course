namespace UlearnCourse.Cycles
{
    internal class Chessboard
    {
        public void Main()
        {
            WriteBoard(8);
            WriteBoard(1);
            WriteBoard(2);
            WriteBoard(3);
            WriteBoard(10);
        }

        private static void WriteBoard(int size)
        {
            for (int i = 0; i < size; i++)
            {
                var line = new System.Text.StringBuilder(size);

                for (int j = 0; j < size; j++)
                {
                    line.Append((i + j) % 2 == 0 ? '#' : '.');
                }

                Console.WriteLine(line);
            }

            Console.WriteLine();
        }
    }
}