namespace UlearnCourse.FundamentalsOfProgrammingPart2.DataStructures
{
    internal class GetMinValue
    {
        public static int GetMinValue(TreeNode root)
        {
            return root.Left == null ? root.Value : GetMinValue(root.Left);
        }
    }
}