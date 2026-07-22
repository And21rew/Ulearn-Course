namespace UlearnCourse.Arrays
{
    internal class TicTacToe
    {
        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            var crossHasWinSequence = HasWinSequence(field, Mark.Cross);
            var circleHasWinSequence = HasWinSequence(field, Mark.Circle);

            if (crossHasWinSequence == circleHasWinSequence)
                return GameResult.Draw;

            return crossHasWinSequence ? GameResult.CrossWin : GameResult.CircleWin;
        }

        private static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            for (int i = 0; i < 3; i++)
            {
                if (HasWinTrio(field[i, 0], field[i, 1], field[i, 2], mark)) return true;
                if (HasWinTrio(field[0, i], field[1, i], field[2, i], mark)) return true;
                if (HasWinTrio(field[0, 0], field[1, 1], field[2, 2], mark)) return true;
                if (HasWinTrio(field[2, 0], field[1, 1], field[0, 2], mark)) return true;
            }

            return false;
        }

        private static bool HasWinTrio(Mark mark1, Mark mark2, Mark mark3, Mark mark)
        {
            return (mark1 == mark2) && (mark1 == mark3) && (mark1 == mark);
        }
    }
}