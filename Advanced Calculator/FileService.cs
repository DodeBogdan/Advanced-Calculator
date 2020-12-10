using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advanced_Calculator
{
    public class FileService : IFileService
    {
        public string GetInputFromFile(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException();

            var text = System.IO.File.ReadAllText(path);

            return text;
        }
    }
}
