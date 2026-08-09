namespace UlearnCourse.Inheritance
{
    class Book : IComparable
    {
        public string Title;
        public int Theme;

        public int CompareTo(object obj)
        {
            var anotherBook = (Book)obj;

            return Theme == anotherBook.Theme ? Title.CompareTo(anotherBook.Title) : Theme.CompareTo(anotherBook.Theme);
        }
    }
}