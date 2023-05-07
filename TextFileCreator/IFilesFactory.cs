using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileCreator
{
    public interface IFilesFactory
    {
        abstract static IFilesFactory GetCreator();
        void CreateFiles();
    }
}
