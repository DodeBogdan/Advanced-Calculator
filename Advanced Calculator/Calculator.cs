using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Advanced_Calculator
{
    public class Calculator
    {
        private readonly ITextConvertor textConvertor;

        public Calculator(ITextConvertor textConvertor)
        {
            this.textConvertor = textConvertor;
        }
        public double Calculate(string path, IFileService fileService)
        {
            var input = fileService.GetInputFromFile(path);
            //input = input.Replace(" ", "");
            input = textConvertor.RemoveWhiteSpaces(input);

            if (!textConvertor.CheckCharacters(input))
            {
                throw new InvalidCastException("The input is invalid.");
            }

            if (!textConvertor.CheckSequence(input))
            {
                throw new InvalidDataException("Invalid Sequence!");
            }

            if (input[0] == '+')
                input = input.Remove(0, 1);

            var operators = new Stack<char>();
            var variables = new Stack<double>();
            var rx = new Regex("[0-9]+([,.]?[0-9]+)?");
            var matches = rx.Matches((input));

            var number = double.Parse(matches[0].ToString());

            if (input[0] == '-')
            {
                number = -number;
            }

            variables.Push(number);
            input = input.Remove(input.IndexOf(matches[0].ToString()[0]), matches[0].Length);

            while (input.Length != 0)
            {
                matches = rx.Matches((input));

                number = double.Parse(matches[0].ToString());
                input = input.Remove(input.IndexOf(matches[0].ToString()[0]), matches[0].Length);
                variables.Push(number);

                operators.Push(input[0]);
                input = input.Remove(0, 1);


                if (operators.Peek() == '*' || operators.Peek() == '/')
                {
                    var op = operators.Pop();
                    var number1 = variables.Pop();
                    var number2 = variables.Pop();
                    if (op == '*')
                        variables.Push(number1 * number2);
                    else variables.Push(number1 / number2);
                }

                matches = rx.Matches((input));
            }

            while (operators.Count != 0)
            {
                var number1 = variables.Pop();
                var number2 = variables.Pop();
                var op = operators.Pop();

                if (op == '+')
                {
                    variables.Push(number1 + number2);
                }
                else
                {
                    variables.Push(number1 - number2);
                }
            }

            return variables.Peek();

        }
    }
}
