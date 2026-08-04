using NUnit.Framework;
using NUnit.Framework.Legacy;
using static Manipulation.Manipulator;

namespace UlearnCourse.Practicum
{
    public static class ManipulatorTask
    {
        public static double[] MoveManipulatorTo(double x, double y, double alpha)
        {
            var wristX = x + Palm * Math.Cos(Math.PI - alpha);
            var wristY = y + Palm * Math.Sin(Math.PI - alpha);
            var length = Math.Sqrt(wristX * wristX + wristY * wristY);
            var shoulder = TriangleTask.GetABAngle(UpperArm, length, Forearm) + Math.Atan2(wristY, wristX);
            var elbow = TriangleTask.GetABAngle(UpperArm, Forearm, length);
            var wrist = -alpha - shoulder - elbow;

            return [shoulder, elbow, wrist];
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            var random = new Random();
            for (var i = 0; i < 1000; i++)
            {
                var x = random.NextDouble();
                var y = random.NextDouble();
                var angleAlpha = random.NextDouble() * Math.PI;
                var angle = ManipulatorTask.MoveManipulatorTo(x, y, angleAlpha);
                var joints = AnglesToCoordinatesTask.GetJointPositions(angle[0], angle[1], angle[2]);

                ClassicAssert.AreEqual(joints[2].X, x, 1e-4);
                ClassicAssert.AreEqual(joints[2].Y, y, 1e-4);
            }
        }
    }
}