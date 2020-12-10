using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Advanced_Calculator
{
    public class TextConvertor : ITextConvertor
    {
        public bool CheckCharacters(string input)
        {
            var availableCharacters = new string("1234567890+-*/., ");

            foreach (var currentChar in input)
            {
                if (!availableCharacters.Contains(currentChar))
                    return false;
            }

            return true;
        }

        public bool CheckSequence(string input)
        {
            var rx = new Regex(
                @"(([+-]?[\ ]*[1-9]+([,.]?[\ ]*[0-9]+)?[\ ]*[+\-*\/][\ ]*)+([+-]?[\ ]*[0-9]+)([,.]?[\ ]*[0-9]+)?)+");
            var matches = rx.Matches((input));

            if (matches.Count != 0)
            {
                if (matches[0].Length != input.Length)
                    return false;
                return true;
            }

            return false;
        }

        public string RemoveWhiteSpaces(string input)
        {
            input = input.Replace(" ", "");

            return input;
        }
    }
}
