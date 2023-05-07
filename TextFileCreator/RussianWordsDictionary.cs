using System.Text;

namespace TextFileCreator
{
    public static class RussianWordsDictionary
    {
        private static readonly string[] Words = File.ReadAllText($"{Environment.CurrentDirectory}\\RUS.txt").Split("\r\n");
        private static readonly char[] punctuationMarks = { ',', '.' };


        public static string TakeWords()
        {
            Random random = new Random();
            int maxWords = ProjectSettings.MaxWords + 1;
            int minWords = ProjectSettings.MinWords;
            StringBuilder words = new StringBuilder();
            for (int i = random.Next(minWords, maxWords); i < maxWords; i++)
            {
                string word = GenerateWord(ref random);
                words.Append(word);
            }

            return words.ToString();
        }

        private static string GenerateWord(ref Random random)
        {
            string word = $"{Words[random.Next(0, Words.Length + 1)]}";
            string punctuationMark = "";
            if(random.NextDouble() < 0.25)
            {
                punctuationMark += punctuationMarks[random.Next(0,punctuationMarks.Length)];
            }
            return $"{word}{punctuationMark} ";
        }
    }
}
