using System.Text;

namespace UlearnCourse.Engineering.EncapsulationTheory
{
    class MyFile
    {
        public static string Decode(string textWithWrongEncoding, Encoding rightEncoding = null, Encoding wrongEncoding = null)
        {
            rightEncoding ??= Encoding.UTF8;
            wrongEncoding ??= Encoding.GetEncoding(437);

            return rightEncoding.GetString(wrongEncoding.GetBytes(textWithWrongEncoding));
        }
    }
}