namespace UlearnCourse.FundamentalsOfProgrammingPart2.DataStructures
{
    public class DiskTreeTask
    {
        private class DirectoryNode
        {
            public string Name { get; set; }
            public SortedDictionary<string, DirectoryNode> Children;

            public DirectoryNode(string name)
            {
                Name = name;
                Children = new SortedDictionary<string, DirectoryNode>(StringComparer.Ordinal);
            }

            public void AddPath(string[] pathComponents)
            {
                var currentNode = this;

                foreach (string component in pathComponents)
                {
                    if (!currentNode.Children.ContainsKey(component))
                        currentNode.Children[component] = new DirectoryNode(component);

                    currentNode = currentNode.Children[component];
                }
            }

            public List<string> Format(int indentLevel, bool isRoot = true)
            {
                var result = new List<string>();

                if (!isRoot)
                    result.Add(new string(' ', indentLevel) + Name);

                foreach (var child in Children.Values)
                    result.AddRange(child.Format(indentLevel + 1, false));

                return result;
            }
        }

        public static List<string> Solve(List<string> input)
        {
            var root = new DirectoryNode("");

            foreach (string path in input)
                root.AddPath(path.Split('\\'));

            return root.Format(-1, true);
        }
    }
}