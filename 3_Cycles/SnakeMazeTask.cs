namespace UlearnCourse.Cycles
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            var horizontalStepCount = width - 3;
            var verticalStepCount = 2;

            while (!robot.Finished)
            {
                MoveHorizontal(robot, horizontalStepCount, Direction.Right);
                MoveDown(robot, verticalStepCount);
                MoveHorizontal(robot, horizontalStepCount, Direction.Left);

                if (!robot.Finished)
                    MoveDown(robot, verticalStepCount);
            }
        }

        private static void MoveHorizontal(Robot robot, int stepCount, Direction direction)
        {
            if (direction == Direction.Right || direction == Direction.Left)
            {
                for (int i = 0; i < stepCount; i++)
                    robot.MoveTo(direction);
            }
        }

        private static void MoveDown(Robot robot, int stepCount)
        {
            for (int i = 0; i < stepCount; i++)
                robot.MoveTo(Direction.Down);
        }
    }
}