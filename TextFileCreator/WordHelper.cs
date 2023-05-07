using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace TextFileCreator
{
    public class WordHelper
    {
        private WordHelper() { }

        public static void CreateFile(ref Word.Application wordApp, int fileNum)
        {
            try
            {
                Word.Document document = wordApp.Documents.Add();
                Word.Paragraph paragraph;
                paragraph = document.Paragraphs.Add();
                paragraph.Range.Text = AddText();

                document.SaveAs2($"{ProjectSettings.TaskDirectory}\\docx\\{fileNum}.docx");
                document.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка -> ${e.Message}");
                throw;
            }
        }

        private static string AddText() => RussianWordsDictionary.TakeWords();
    }
}
