using System.Text;

namespace TextFileCreator
{
    public static class TxtHelper
    {

        public static void CreateFile(int fileNum)
        {
            try
            {
                string path = $"{ProjectSettings.TaskDirectory}\\txt\\{fileNum}.txt";
                StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8);
                streamWriter.WriteLine(AddText());

                streamWriter.Close();
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
