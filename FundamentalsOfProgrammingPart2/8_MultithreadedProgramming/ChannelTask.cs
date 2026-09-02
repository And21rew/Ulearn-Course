namespace UlearnCourse.FundamentalsOfProgrammingPart2._8_MultithreadedProgramming
{
    public class Channel<T> where T : class
    {
        private readonly List<T> values = new();
        /// <summary>
        /// Возвращает элемент по индексу или null, если такого элемента нет.
        /// При присвоении удаляет все элементы после.
        /// Если индекс в точности равен размеру коллекции, работает как Append.
        /// </summary>
        public T this[int index]
        {
            get
            {
                lock (values)
                {
                    return index >= Count ? null : values[index];
                }
            }
            set
            {
                lock (values)
                {
                    if (index == Count)
                    {
                        values.Add(value);
                    }
                    else if (index < Count)
                    {
                        values[index] = value;
                        values.RemoveRange(index + 1, Count - index - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает последний элемент или null, если такого элемента нет
        /// </summary>
        public T LastItem()
        {
            lock (values)
            {
                return Count > 0 ? values[^1] : null;
            }
        }

        /// <summary>
        /// Добавляет item в конец только если lastItem является последним элементом
        /// </summary>
        public void AppendIfLastItemIsUnchanged(T item, T knownLastItem)
        {
            lock (values)
            {
                if (LastItem() == knownLastItem)
                    values.Add(item);
            }
        }

        /// <summary>
        /// Возвращает количество элементов в коллекции
        /// </summary>
        public int Count
        {
            get
            {
                lock (values)
                {
                    return values.Count;
                }
            }
        }
    }
}