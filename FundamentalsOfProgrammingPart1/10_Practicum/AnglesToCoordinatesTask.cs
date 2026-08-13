using Avalonia;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Drawing;
using static Manipulation.Manipulator;

namespace UlearnCourse.FundamentalsOfProgrammingPart1.Practicum
{
    public static class AnglesToCoordinatesTask
    {
        public static Point[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbowPos = new Point(UpperArm * Math.Cos(shoulder), UpperArm * Math.Sin(shoulder));
            var wristPos = elbowPos - new Point(Forearm * Math.Cos(shoulder + elbow), Forearm * Math.Sin(shoulder + elbow));
            var palmEndPos = wristPos + new Point(Palm * Math.Cos(elbow + shoulder + wrist), Palm * Math.Sin(elbow + shoulder + wrist));

            return
            [
                elbowPos,
            wristPos,
            palmEndPos
            ];
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Forearm + Palm, UpperArm)]
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI / 2, Forearm, UpperArm - Palm)]
        [TestCase(Math.PI / 2, 3 * Math.PI / 2, 3 * Math.PI / 2, -Forearm, UpperArm - Palm)]
        [TestCase(Math.PI / 2, Math.PI, 3 * Math.PI, Math.PI * 0, Forearm + UpperArm + Palm)]

        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            ClassicAssert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            ClassicAssert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
        }
    }
}