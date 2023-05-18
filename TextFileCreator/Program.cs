namespace TextFileCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Initialize();
        }

        private static void Initialize()
        {
            Console.WriteLine("Напишите ниже формат файлов, который вы бы хотели создать (txt | docx)");
            string? inputvalue = Console.ReadLine()?.Trim().ToLower();
            IFilesFactory factory;
            switch (inputvalue)
            {
                case nameof(FileExtensions.docx):
                    factory = DocxCreator.GetCreator();
                    break;
                case nameof(FileExtensions.txt):
                    factory = TxtCreator.GetCreator();
                    break;
                default:
                    Console.WriteLine("С таким форматом данных на данный момент программа не работает\nХотите выбрать другой формат? y/n");
                    RepeatChooseOrNot();
                    return;
            }
            factory.CreateFiles();
            Console.WriteLine("Файлы успешно созданы");
        }

        private static void RepeatChooseOrNot()
        {
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (answer == 'y')
            {
                Initialize();
            }

            return;
        }
    }
}