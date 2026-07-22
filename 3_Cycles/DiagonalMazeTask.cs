namespace UlearnCourse.Cycles
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var isWide = width > height;

            var largeSide = isWide ? width : height;
            var smallSide = isWide ? height : width;

            var largeDirection = isWide ? Direction.Right : Direction.Down;
            var smallDirection = isWide ? Direction.Down : Direction.Right;

            MoveOut(robot, largeSide, smallSide, largeDirection, smallDirection);
        }

        private static void MoveOut(Robot robot, int largeSide, int smallSide, Direction largeDirection, Direction smallDirection)
        {
            var largeStep = CalculateLargeStep(largeSide, smallSide);

            while (!robot.Finished)
            {
                Move(robot, largeStep, largeDirection);

                if (!robot.Finished)
                    Move(robot, 1, smallDirection);
            }
        }

        private static int CalculateLargeStep(int largeSide, int smallSide) =>
            (int)Math.Round((double)largeSide / smallSide, MidpointRounding.AwayFromZero);

        private static void Move(Robot robot, int stepCount, Direction direction)
        {
            for (int i = 0; i < stepCount; i++)
                robot.MoveTo(direction);
        }
    }
}