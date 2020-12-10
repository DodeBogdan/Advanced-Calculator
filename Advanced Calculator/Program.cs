using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advanced_Calculator
{
    internal class Program
    {
        public static void Main()
        {
           Calculator calculator = new Calculator(new TextConvertor());
           var result = calculator.Calculate("../../../../CalculatorInput.txt", new FileService());

           Console.WriteLine(result);

           Console.Read();
        }
    }
}
