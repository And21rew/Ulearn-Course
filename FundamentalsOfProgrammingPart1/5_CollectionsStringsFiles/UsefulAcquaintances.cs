namespace UlearnCourse.FundamentalsOfProgrammingPart1.CollectionsStringsFiles
{
    internal class UsefulAcquaintances
    {
        private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var separator = ':';
            var nameLength = 2;

            var dictionary = new Dictionary<string, List<string>>();

            foreach (var contact in contacts)
            {
                var nameStr = contact.Split(separator)[0];
                var name = nameStr.Length >= nameLength ? nameStr.Substring(0, nameLength) : nameStr;

                if (!dictionary.ContainsKey(name))
                    dictionary[name] = new List<string>();

                dictionary[name].Add(contact);
            }

            return dictionary;
        }
    }
}