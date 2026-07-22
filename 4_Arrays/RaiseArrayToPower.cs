namespace UlearnCourse.Arrays
{
    internal class RaiseArrayToPower
    {
        public void Main()
        {
            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Метод PrintArray уже написан за вас
            PrintArray(GetPoweredArray(arrayToPower, 1));

            // если вы будете менять исходный массив, то следующие два теста сработают неверно:
            PrintArray(GetPoweredArray(arrayToPower, 2));
            PrintArray(GetPoweredArray(arrayToPower, 3));

            // не забывайте про частные случаи:
            PrintArray(GetPoweredArray(new int[0], 1));
            PrintArray(GetPoweredArray(new[] { 42 }, 0));
        }

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