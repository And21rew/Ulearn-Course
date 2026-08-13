namespace UlearnCourse.FundamentalsOfProgrammingPart2.QueuesStacksGenerics
{
    public class LimitedSizeStack<T>
    {
        private LinkedList<T> stack;
        private int limit;

        public LimitedSizeStack(int undoLimit)
        {
            stack = new LinkedList<T>();
            limit = undoLimit;
        }

        public void Push(T item)
        {
            if (limit == 0)
                return;

            if (Count == limit)
                stack.RemoveFirst();

            stack.AddLast(item);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var lastObj = stack.Last.Value;
            stack.RemoveLast();

            return lastObj;
        }

        public int Count => stack.Count;
    }
}