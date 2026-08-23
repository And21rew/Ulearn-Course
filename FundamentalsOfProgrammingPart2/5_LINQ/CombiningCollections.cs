namespace UlearnCourse.FundamentalsOfProgrammingPart2.LINQ
{
    internal class CombiningCollections
    {
        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes
                .SelectMany(x => x.Students)
                .ToArray();
        }
    }
}