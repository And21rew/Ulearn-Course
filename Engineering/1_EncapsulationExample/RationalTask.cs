namespace UlearnCourse.Engineering.EncapsulationExample
{
    public class Rational
    {
        public readonly bool IsNan;
        public readonly int Numerator;
        public readonly int Denominator;

        public Rational(int numerator, int denominator = 1)
        {
            if (denominator == 0)
            {
                Numerator = numerator;
                Denominator = denominator;
                IsNan = true;
                return;
            }

            if (numerator == 0)
            {
                Numerator = numerator;
                Denominator = 1;
                IsNan = false;
                return;
            }

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            var gcd = GetGCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
            IsNan = false;
        }

        private int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            if (r1.IsNan || r2.IsNan)
                return new Rational(1, 0);

            var num = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            var den = r1.Denominator * r2.Denominator;

            return new Rational(num, den);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            if (r1.IsNan || r2.IsNan)
                return new Rational(1, 0);

            var num = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
            var den = r1.Denominator * r2.Denominator;

            return new Rational(num, den);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            if (r1.IsNan || r2.IsNan)
                return new Rational(1, 0);

            var num = r1.Numerator * r2.Numerator;
            var den = r1.Denominator * r2.Denominator;

            return new Rational(num, den);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            if (r1.IsNan || r2.IsNan || r2.Numerator == 0)
                return new Rational(1, 0);

            var num = r1.Numerator * r2.Denominator;
            var den = r1.Denominator * r2.Numerator;

            return new Rational(num, den);
        }

        public static implicit operator double(Rational r) => r.IsNan ? double.NaN : (double)r.Numerator / r.Denominator;

        public static implicit operator Rational(int number) => new Rational(number, 1);

        public static explicit operator int(Rational r)
        {
            if (r.IsNan || r.Numerator % r.Denominator != 0)
                throw new InvalidCastException();

            return r.Numerator / r.Denominator;
        }
    }
}