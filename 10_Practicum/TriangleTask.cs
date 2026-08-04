using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UlearnCourse.Practicum
{
    public class TriangleTask
    {
        public static double GetABAngle(double a, double b, double c)
        {
            if (a > b + c || b > a + c || c > a + b)
                return double.NaN;

            return Math.Acos((a * a + b * b - c * c) / (2 * a * b));
        }
    }

    [TestFixture]
    public class TriangleTask_Tests
    {
        [TestCase(3, 4, 5, Math.PI / 2)]
        [TestCase(1, 1, 1, Math.PI / 3)]
        [TestCase(150, 120, 60, 0.3897607327974747)]
        [TestCase(60, 120, 150, 1.8886200307227774)]
        [TestCase(1, 1, 2, Math.PI)]
        [TestCase(2, 1, 1, 0)]
        [TestCase(1, 2, 1, 0)]
        [TestCase(1, 1, 2.001, double.NaN)]
        [TestCase(1, 2.001, 1, double.NaN)]
        [TestCase(2.001, 1, 1, double.NaN)]
        [TestCase(0, 5, 5, double.NaN)]
        [TestCase(5, 0, 5, double.NaN)]
        [TestCase(5, 5, 0, 0)]
        [TestCase(-3, -2, -4, double.NaN)]
        public void TestGetABAngle(double a, double b, double c, double expectedAngle)
        {
            var angle = TriangleTask.GetABAngle(a, b, c);
            ClassicAssert.AreEqual(expectedAngle, angle, 1e-4);
        }
    }
}