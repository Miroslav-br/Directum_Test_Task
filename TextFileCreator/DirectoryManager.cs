using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileCreator
{
    public static class DirectoryManager
    {
        public static void CreateAndClearDirectory(string path)
        {
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
