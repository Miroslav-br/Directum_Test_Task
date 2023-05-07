using Word = Microsoft.Office.Interop.Word;

namespace TextFileCreator
{
    public class DocxCreator : IFilesFactory
    {
        private DocxCreator() { }

        public static IFilesFactory GetCreator() => new DocxCreator();

        public void CreateFiles()
        {
            CreateAndClearDirectory();

            Word.Application wordApp = new Word.Application();
            for (int i = 0; i < ProjectSettings.NumberOfFiles; i++)
            {
                WordHelper.CreateFile(ref wordApp,i);
            }
            wordApp.Quit();
        }

        private static void CreateAndClearDirectory()
        {
            string path = $"{ProjectSettings.TaskDirectory}\\docx";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] files = directoryInfo.GetFiles();
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
