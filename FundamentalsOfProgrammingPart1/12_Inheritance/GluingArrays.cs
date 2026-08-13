namespace UlearnCourse.FundamentalsOfProgrammingPart1.Inheritance
{
    internal class GluingArrays
    {
        public static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0)
                return null;

            var firstElementType = arrays[0].GetType().GetElementType();
            var summaryLength = 0;

            foreach (var array in arrays)
            {
                if (array.GetType().GetElementType() != firstElementType)
                    return null;

                foreach (var element in array) 
                    summaryLength++;
            }
                
            var result = Array.CreateInstance(firstElementType, summaryLength);

            var offset = 0;
            foreach (var arr in arrays)
            {
                arr.CopyTo(result, offset);
                offset += arr.Length;
            }

            return result;
        }
    }
}