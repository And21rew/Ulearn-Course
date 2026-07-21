using System.Text;

namespace UlearnCourse.CollectionsStringsFiles
{
    internal class StrangerAgain
    {
        private static string ApplyCommands(string[] commands)
        {
            var decryptedString = new StringBuilder();

            foreach (var command in commands)
            {
                var firstSpaceIndex = command.IndexOf(' ');

                if (firstSpaceIndex == -1)
                    continue;

                var operation = command.Substring(0, firstSpaceIndex);
                var operationStr = command.Substring(firstSpaceIndex + 1);

                if (operation == "push")
                {
                    decryptedString.Append(operationStr);
                }
                else
                {
                    var deleteSymbolCount = int.Parse(operationStr);
                    decryptedString.Remove(decryptedString.Length - deleteSymbolCount, deleteSymbolCount);
                }
            }

            return decryptedString.ToString();
        }
    }
}