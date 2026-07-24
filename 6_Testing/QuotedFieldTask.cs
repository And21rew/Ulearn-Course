using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Text;

namespace UlearnCourse.Testing
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("'hello world'", 0, "hello world", 13)]
        [TestCase("'a\"b'", 0, "a\"b", 5)]
        [TestCase("\"a\\\"b\"", 0, "a\"b", 6)]
        [TestCase("'abc", 0, "abc", 4)]
        [TestCase("abc 'xyz'", 4, "xyz", 5)]
        [TestCase("\"\"", 0, "", 2)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            ClassicAssert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var tokenBuilder = new StringBuilder();
            var startQuote = line[startIndex];
            var tokenLength = 1;

            for (int i = startIndex + 1; i < line.Length; i++)
            {
                tokenLength++;
                var symbol = line[i];

                if (symbol == '\\')
                {
                    if (i + 1 < line.Length)
                    {
                        tokenBuilder.Append(line[i + 1]);
                        tokenLength++;
                        i++;
                    }
                    else
                    {
                        tokenBuilder.Append('\\');
                    }

                    continue;
                }

                if (symbol == startQuote)
                {
                    break;
                }

                tokenBuilder.Append(symbol);
            }

            return new Token(tokenBuilder.ToString(), startIndex, tokenLength);
        }
    }
}