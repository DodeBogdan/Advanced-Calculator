using System;

namespace Advanced_Calculator
{
    internal class Program
    {
        public static void Main()
        {
            Calculator calculator = new Calculator(new TextConvertor());
            try
            {
                var result = calculator.Calculate("../../../../CalculatorInput.txt", new FileService());

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.Read();
        }
    }
}
