using System;

namespace UlearnCourse.Mistakes
{
    internal class ProcentsTask
    {
        public static double Calculate(string userInput)
        {
            var inputParts = userInput.Split(' ');
            var money = double.Parse(inputParts[0]);
            var mounthProcent = double.Parse(inputParts[1]) / 12 / 100;
            var time = int.Parse(inputParts[2]);

            return money * Math.Pow(1 + mounthProcent, time);
        }
    }
}