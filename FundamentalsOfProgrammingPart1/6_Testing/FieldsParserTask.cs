using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UlearnCourse.FundamentalsOfProgrammingPart1.Testing
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        [TestCase("", new string[0])]
        [TestCase("\'\"\'", new[] { "\"" })]
        [TestCase("\"\"", new[] { "" })]
        [TestCase("ab", new[] { "ab" })]
        [TestCase("a b", new[] { "a", "b" })]
        [TestCase("a  b", new[] { "a", "b" })]
        [TestCase(" a b ", new[] { "a", "b" })]
        [TestCase("a 'b'", new[] { "a", "b" })]
        [TestCase("'b' a", new[] { "b", "a" })]
        [TestCase("b \"a", new[] { "b", "a" })]
        [TestCase("\'a ", new[] { "a " })]
        [TestCase("\"\'b\'\" c", new[] { "'b'", "c" })]
        [TestCase("\'\"a\"\' b", new[] { "\"a\"", "b" })]
        [TestCase(@"'a''b'", new[] { "a", "b" })]
        [TestCase(@"'a\\'", new[] { @"a\" })]
        [TestCase(@"'\'a'", new[] { @"'a" })]
        [TestCase(@"""\""a""", new[] { @"""a" })]
        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }

        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            ClassicAssert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                ClassicAssert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }
    }

    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            var result = new List<Token>();
            var index = 0;

            while (true)
            {
                index = SkipSpaces(line, index);

                if (index >= line.Length)
                    break;

                var token = line[index] == '"' || line[index] == '\'' ? ReadQuotedField(line, index) : ReadField(line, index);
                result.Add(token);
                index = token.GetIndexNextToToken();
            }

            return result;
        }

        private static int SkipSpaces(string line, int index)
        {
            while (index < line.Length && line[index] == ' ')
                index++;

            return index;
        }

        private static Token ReadField(string line, int startIndex)
        {
            var length = 0;

            while (startIndex + length < line.Length && line[startIndex + length] != ' ' && line[startIndex + length] != '"' && line[startIndex + length] != '\'')
                length++;

            return new Token(line.Substring(startIndex, length), startIndex, length);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}
