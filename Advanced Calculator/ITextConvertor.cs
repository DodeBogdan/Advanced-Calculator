namespace Advanced_Calculator
{
    public interface ITextConvertor
    {
        bool CheckCharacters(string input);
        bool CheckSequence(string input);
        string RemoveWhiteSpaces(string input);
    }
}