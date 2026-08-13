namespace UlearnCourse.FundamentalsOfProgrammingPart1.Arrays
{
    internal class RaiseArrayToPower
    {
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            var newArr = new int[arr.Length];
            Array.Copy(arr, newArr, arr.Length);

            for (int i = 0; i < newArr.Length; i++)
                newArr[i] = (int)Math.Round(Math.Pow(newArr[i], power));

            return newArr;
        }
    }
}