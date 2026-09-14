namespace UlearnCourse.FundamentalsOfProgrammingPart2.DataStructures
{
    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T value) { Value = value; }
    }

    public class BinaryTree<T> where T : IComparable
    {
        private Node<T> root;

        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (root == null)
            {
                root = newNode;
                return;
            }

            var (parent, isLeft) = FindInsertionPosition(value);

            if (isLeft)
                parent.Left = newNode;
            else
                parent.Right = newNode;
        }

        private (Node<T> parent, bool isLeft) FindInsertionPosition(T value)
        {
            Node<T> parent = null;
            Node<T> current = root;
            var isLeft = false;

            while (current != null)
            {
                parent = current;

                if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                    isLeft = true;
                }
                else
                {
                    current = current.Right;
                    isLeft = false;
                }
            }

            return (parent, isLeft);
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
    }
}