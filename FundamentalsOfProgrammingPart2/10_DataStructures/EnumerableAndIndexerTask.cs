namespace UlearnCourse.FundamentalsOfProgrammingPart2.DataStructures
{
    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public int Size;

        public Node(T value)
        {
            Value = value;
            Size = 1;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        private Node<T> root;

        public void Add(T value)
        {
            root = AddRecursive(root, value);
        }

        public bool Contains(T value)
        {
            var pointer = root;

            while (pointer != null)
            {
                if (value.CompareTo(pointer.Value) == 0)
                    return true;

                pointer = value.CompareTo(pointer.Value) < 0 ? pointer.Left : pointer.Right;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return EnumerateElements(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T this[int i]
        {
            get
            {
                if (root == null || i < 0 || i >= root.Size)
                    throw new ArgumentOutOfRangeException();

                return GetByIndex(root, i);
            }
        }

        private Node<T> AddRecursive(Node<T> node, T value)
        {
            if (node == null)
                return new Node<T>(value);

            if (value.CompareTo(node.Value) < 0)
                node.Left = AddRecursive(node.Left, value);
            else
                node.Right = AddRecursive(node.Right, value);

            node.Size = 1 + (node.Left?.Size ?? 0) + (node.Right?.Size ?? 0);

            return node;
        }

        private IEnumerable<T> EnumerateElements(Node<T> node)
        {
            if (node == null)
                yield break;

            foreach (var item in EnumerateElements(node.Left))
                yield return item;

            yield return node.Value;

            foreach (var item in EnumerateElements(node.Right))
                yield return item;
        }

        private T GetByIndex(Node<T> node, int index)
        {
            var leftSize = node.Left?.Size ?? 0;

            if (index < leftSize)
            {
                return GetByIndex(node.Left, index);
            }
            else if (index == leftSize)
            {
                return node.Value;
            }
            else
            {
                return GetByIndex(node.Right, index - leftSize - 1);
            }
        }
    }
}