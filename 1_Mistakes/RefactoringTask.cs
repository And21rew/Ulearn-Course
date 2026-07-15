using System;

namespace UlearnCourse.Mistakes
{
    class Drawer
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialize(IGraphics newGraphics)
        {
            graphics = newGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float SquareSideLength = 0.375f;
        private const float SquareSideWidth = 0.04f;

        private static Pen pen;
        private static float sideLength;
        private static float sideWidth;

        public static void Draw(int width, int height, double angleRotation, IGraphics graphics)
        {
            Drawer.Initialize(graphics);
            Initialize(Math.Min(width, height));
            SetCenterToDrawer(width, height);

            DrawAndRotate(0);
            DrawAndRotate(-Math.PI / 2);
            DrawAndRotate(Math.PI);
            DrawAndRotate(Math.PI / 2);
        }

        private static void Initialize(int size)
        {
            pen = new Pen(Brushes.Yellow);
            sideLength = size * SquareSideLength;
            sideWidth = size * SquareSideWidth;
        }

        private static void SetCenterToDrawer(int width, int height)
        {
            var diagonalLength = Math.Sqrt(2) * (sideLength + sideWidth) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);
        }

        private static void DrawAndRotate(double angle)
        {
            DrawSide(angle);
            RotateSide(angle);
        }

        private static void DrawSide(double angle)
        {
            Drawer.MakeIt(pen, sideLength, angle);
            Drawer.MakeIt(pen, sideWidth * Math.Sqrt(2), angle + Math.PI / 4);
            Drawer.MakeIt(pen, sideLength, angle + Math.PI);
            Drawer.MakeIt(pen, sideLength - sideWidth, angle + Math.PI / 2);
        }

        private static void RotateSide(double angle)
        {
            Drawer.Change(sideWidth, angle - Math.PI);
            Drawer.Change(sideWidth * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}