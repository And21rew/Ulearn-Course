using System.Net.Sockets;
using System.Reflection.Emit;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.ElementsOfFunctionalProgramming
{
    public class LevelsTask
    {
        private static readonly Physics standardPhysics = new();
        private static readonly Rocket standardRocket = new(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);
        private static readonly Vector standardTarget = new(600, 200);

        private static readonly Func<Vector, Vector> calculateWhiteHoleGravity = (v) =>
        {
            var delta = v - standardTarget;
            return 140 * delta / (delta.Length * delta.Length + 1);
        };

        private static readonly Func<Vector, Vector> calculateBlackHoleGravity = (v) =>
        {
            var delta = (standardTarget + standardRocket.Location) / 2 - v;
            return 300 * delta / (delta.Length * delta.Length + 1);
        };

        public static IEnumerable<Level> CreateLevels()
        {
            yield return CreateZeroLevel();
            yield return CreateHeavyLevel();
            yield return CreateUpLevel();
            yield return CreateWhiteHoleLevel();
            yield return CreateBlackHoleLevel();
            yield return CreateBlackAndWhiteLevel();
        }

        private static Level CreateZeroLevel()
        {
            return new Level("Zero",
                standardRocket,
                standardTarget,
                (size, v) => Vector.Zero,
                standardPhysics
            );
        }

        private static Level CreateHeavyLevel()
        {
            return new Level("Heavy",
                standardRocket,
                standardTarget,
                (size, v) => new Vector(0, 0.9),
                standardPhysics
            );
        }

        private static Level CreateUpLevel()
        {
            return new Level("Up",
                standardRocket,
                new Vector(700, 500),
                (size, v) => new Vector(0, -300 / (size.Y - v.Y + 300.0)),
                standardPhysics
            );
        }

        private static Level CreateWhiteHoleLevel()
        {
            return new Level("WhiteHole",
                standardRocket,
                standardTarget,
                (size, v) => calculateWhiteHoleGravity(v),
                standardPhysics
            );
        }

        private static Level CreateBlackHoleLevel()
        {
            return new Level("BlackHole",
                standardRocket,
                standardTarget,
                (size, v) => calculateBlackHoleGravity(v),
                standardPhysics
            );
        }

        private static Level CreateBlackAndWhiteLevel()
        {
            return new Level("BlackAndWhite",
                standardRocket,
                standardTarget,
                (size, v) => (calculateBlackHoleGravity(v) + calculateWhiteHoleGravity(v)) / 2,
                standardPhysics
            );
        }
    }
}