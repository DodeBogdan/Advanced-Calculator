using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Calculator
{
    public interface IFileService
    {
        string GetInputFromFile(string path);
    }
}
