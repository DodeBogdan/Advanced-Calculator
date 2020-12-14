using System.IO;

namespace Advanced_Calculator
{
    public class FileService : IFileService
    {
        public string GetInputFromFile(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException();

            var text = File.ReadAllText(path);

            return text;
        }
    }
}
