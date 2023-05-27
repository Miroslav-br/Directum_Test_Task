namespace TextFileCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите ниже формат файлов, который вы бы хотели создать (txt | docx)");
            IFilesFactory factory;
            while (true)
            {   string? inputvalue = Console.ReadLine()?.Trim().ToLower();
                switch (inputvalue)
                {
                    case nameof(FileExtensions.docx):
                        factory = DocxCreator.GetCreator();
                        break;
                    case nameof(FileExtensions.txt):
                        factory = TxtCreator.GetCreator();
                        break;
                    default:
                        Console.WriteLine("С таким форматом данных на данный момент программа не работает\nПоробуйте снова");
                        continue;
                }
                if(factory != null)
                {
                    factory.CreateFiles();
                    Console.WriteLine("Файлы успешно созданы");
                    break;
                }
            }
        }
    }
}