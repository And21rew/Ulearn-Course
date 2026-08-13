namespace UlearnCourse.FundamentalsOfProgrammingPart1.Inheritance
{
    using Avalonia.Input;
    using Digger.Architecture;

    namespace Digger;

    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y) => new();

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player;

        public int GetDrawingPriority() => 2;

        public string GetImageFileName() => "Terrain.png";
    }

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand();

            switch (Game.KeyPressed)
            {
                case Key.Up:
                    if (y - 1 >= 0)
                        command.DeltaY = -1;
                    break;
                case Key.Down:
                    if (y + 1 < Game.MapHeight)
                        command.DeltaY = 1;
                    break;
                case Key.Left:
                    if (0 <= x - 1)
                        command.DeltaX = -1;
                    break;
                case Key.Right:
                    if (x + 1 < Game.MapWidth)
                        command.DeltaX = 1;
                    break;
                default:
                    break;
            }

            if (Game.Map[x + command.DeltaX, y + command.DeltaY] is Sack)
                (command.DeltaX, command.DeltaY) = (0, 0);

            return command;
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack || conflictedObject is Monster;

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => "Digger.png";
    }

    public class Sack : ICreature
    {
        public int FlightTime;

        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand { DeltaX = 0, DeltaY = 1, TransformTo = this };

            if (CanFallTo(x + command.DeltaX, y + command.DeltaY))
            {
                FlightTime++;
            }
            else
            {
                if (FlightTime > 1)
                    command.TransformTo = new Gold();

                FlightTime = 0;
                command.DeltaY = 0;
            }

            return command;
        }

        public bool CanFallTo(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight)
                return false;

            var cell = Game.Map.GetValue(x, y);

            return cell == null || (cell is Monster || cell is Player) && FlightTime > 0;
        }

        public bool DeadInConflict(ICreature conflictedObject) => false;

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => "Sack.png";
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y) => new();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.Scores += 10;

            return true;
        }

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => "Gold.png";
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            var command = new CreatureCommand();

            if (IsPlayerInSection(0, 0, x, Game.MapHeight) && CanGoTo(x - 1, y))
                command.DeltaX = -1;
            else if (IsPlayerInSection(x + 1, 0, Game.MapWidth, Game.MapHeight) && CanGoTo(x + 1, y))
                command.DeltaX = 1;
            else if (IsPlayerInSection(0, 0, Game.MapWidth, y) && CanGoTo(x, y - 1))
                command.DeltaY = -1;
            else if (IsPlayerInSection(0, y + 1, Game.MapWidth, Game.MapHeight) && CanGoTo(x, y + 1))
                command.DeltaY = 1;

            return command;
        }

        private bool IsPlayerInSection(int x0, int y0, int x1, int y1)
        {
            for (var x = x0; x < x1; x++)
                for (var y = y0; y < y1; y++)
                    if (Game.Map.GetValue(x, y) is Player)
                        return true;

            return false;
        }

        private bool CanGoTo(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight)
                return false;

            var cell = Game.Map.GetValue(x, y);

            return cell == null || !(cell is Sack || cell is Monster || cell is Terrain);
        }

        public bool DeadInConflict(ICreature conflictedObject) =>
            conflictedObject is Monster || conflictedObject is Sack sack && sack.FlightTime > 0;

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Monster.png";
    }
}