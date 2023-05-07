namespace TextFileCreator
{
    public class TxtCreator : IFilesFactory
    {
        private TxtCreator() { }
        public static IFilesFactory GetCreator() => new TxtCreator();

        public void CreateFiles()
        {
            CreateAndClearDirectory();

            for (int i = 0; i < ProjectSettings.NumberOfFiles; i++)
            {
                TxtHelper.CreateFile(i);
            }
        }

        private static void CreateAndClearDirectory()
        {
            string path = $"{ProjectSettings.TaskDirectory}\\txt";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo [] files = directoryInfo.GetFiles();
                if (files.Length != 0)
                {
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Ошибка -> ${e.Message}");
                throw;
            }
        }
    }
}
