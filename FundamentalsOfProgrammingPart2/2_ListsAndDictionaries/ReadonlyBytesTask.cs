using System.Collections;

namespace UlearnCourse.FundamentalsOfProgrammingPart2.ListsAndDictionaries
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        private readonly byte[] bytes;
        private readonly int cachedHashCode;

        public int Length => bytes.Length;

        public ReadonlyBytes(params byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException();

            this.bytes = bytes.ToArray();

            unchecked
            {
                const int fnvPrime = 16777619;
                const int fnvOffsetBasis = unchecked((int)2166136261);

                int hash = fnvOffsetBasis;
                for (int i = 0; i < bytes.Length; i++)
                {
                    hash ^= bytes[i];
                    hash *= fnvPrime;
                }
                cachedHashCode = hash;
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();

                return bytes[index];
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(ReadonlyBytes))
                return false;

            var objReadonlyBytes = (ReadonlyBytes)obj;

            if (Length != objReadonlyBytes.Length)
                return false;

            if (ReferenceEquals(this, objReadonlyBytes))
                return true;

            for (int i = 0; i < Length; i++)
                if (bytes[i] != objReadonlyBytes.bytes[i])
                    return false;

            return true;
        }

        public override int GetHashCode() => cachedHashCode;

        public override string ToString() => $"[{string.Join(", ", bytes)}]";


        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return bytes[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}