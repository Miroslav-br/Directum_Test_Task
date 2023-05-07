using System.Configuration;

namespace TextFileCreator
{
    public static class ProjectSettings
    {
        public static readonly string TaskDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + ConfigurationManager.AppSettings["TaskDirectory"];
        public static readonly int MinWords = Convert.ToInt32(ConfigurationManager.AppSettings["MinWords"]);
        public static readonly int MaxWords = Convert.ToInt32(ConfigurationManager.AppSettings["MaxWords"]);
        public static readonly int NumberOfFiles = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfFiles"]);

    }
}
