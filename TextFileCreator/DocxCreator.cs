using Word = Microsoft.Office.Interop.Word;

namespace TextFileCreator
{
    public class DocxCreator : IFilesFactory
    {
        private DocxCreator() { }

        private readonly static string currentDirectory = ProjectSettings.TaskDirectory + "\\docx\\";

        public static IFilesFactory GetCreator() => new DocxCreator();

        public void CreateFiles()
        {
            DirectoryManager.CreateAndClearDirectory(currentDirectory);

            Word.Application wordApp = new Word.Application();
            for (int i = 0; i < ProjectSettings.NumberOfFiles; i++)
            {
                CreateFile(ref wordApp,i);
            }
            wordApp.Quit();
        }

        public void CreateFile(ref Word.Application wordApp, int fileNum)
        {
            try
            {
                Word.Document document = wordApp.Documents.Add();
                Word.Paragraph paragraph;
                paragraph = document.Paragraphs.Add();
                paragraph.Range.Text = RussianWordsDictionary.TakeWords();

                document.SaveAs2($"{currentDirectory}{fileNum}.docx");
                document.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка -> ${e.Message}");
                throw;
            }
        }
    }
}
