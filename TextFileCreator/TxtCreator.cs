using System.Text;

namespace TextFileCreator
{
    public class TxtCreator : IFilesFactory
    {
        private TxtCreator() { }

        private readonly static string currentDirectory = ProjectSettings.TaskDirectory + "\\txt\\";
        
        public static IFilesFactory GetCreator() => new TxtCreator();

        public void CreateFiles()
        {
            DirectoryManager.CreateAndClearDirectory(currentDirectory);

            for (int i = 0; i < ProjectSettings.NumberOfFiles; i++)
            {
                CreateFile(i);
            }
        }

        public void CreateFile(int fileNum)
        {
            try
            {
                string path = $"{currentDirectory}{fileNum}.txt";
                StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8);
                streamWriter.WriteLine(RussianWordsDictionary.TakeWords());

                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка -> ${e.Message}");
                throw;
            }
        }

    }
}
