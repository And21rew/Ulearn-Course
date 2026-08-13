namespace UlearnCourse.FundamentalsOfProgrammingPart1.BasicsOfOOP
{
    internal class ListOfDirectories
    {
        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            var directories = new HashSet<string>();

            foreach (var file in files) 
            { 
                var extension = file.Extension;

                if (extension == ".mp3" || extension == ".wav")
                    directories.Add(file.Directory.FullName);
            }

            var result = new List<DirectoryInfo>();

            foreach (var directory in directories) 
                result.Add(new DirectoryInfo(directory));

            return result;
        }
    }
}