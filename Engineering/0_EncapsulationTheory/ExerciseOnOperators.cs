namespace UlearnCourse.Engineering.EncapsulationTheory
{
    public class A
    {
        public static int operator +(A a, A aa) => 0;

        public static int operator *(A a, string str) => 0;

        public static implicit operator int(A a) => 0;
    }
}