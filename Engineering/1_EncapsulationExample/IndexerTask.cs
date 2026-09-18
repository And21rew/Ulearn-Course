namespace UlearnCourse.Engineering.EncapsulationExample
{
    public class Indexer
    {
        private readonly double[] originalArray;
        private readonly int startIndex;
        public int Length { get; }

        public Indexer(double[] range, int start, int length)
        {
            if (start < 0 || length < 0 || start + length > range.Length)
                throw new ArgumentException();

            originalArray = range;
            startIndex = start;
            Length = length;
        }

        public double this[int index]
        {
            get
            {
                if (IsIndexValid(index))
                    throw new IndexOutOfRangeException();

                return originalArray[startIndex + index];
            }
            set
            {
                if (IsIndexValid(index))
                    throw new IndexOutOfRangeException();

                originalArray[startIndex + index] = value;
            }
        }

        private bool IsIndexValid(int index) => index < 0 || index >= Length;
    }
}