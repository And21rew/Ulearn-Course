namespace UlearnCourse.FundamentalsOfProgrammingPart2._DataStructures
{
    internal class ImplementationOfBinaryTree
    {
        public static TreeNode Search(TreeNode root, int element)
        {
            if (root == null) return null;
            if (element == root.Value) return root;
            return Search(element < root.Value ? root.Left : root.Right, element);
        }
    }
}