using System;
using System.Text;

namespace NetChalk
{
    public class ChalkConsoleTextBuilder
    {
        private const string UnderlineOn = "\x1B[4m";
        private const string UnderlineOff = "\x1b[24m";

        private readonly string _text;
        private ConsoleColor _foregroundColor = ConsoleColor.Gray;
        private bool _isUnderline;
        private string _modifyString;

        internal ChalkConsoleTextBuilder(string text) => _text = _modifyString = text;

        public void Write()
        {
            Console.ForegroundColor = _foregroundColor;
            Console.Write(_modifyString);
            Console.ResetColor();
        }

        public void WriteLine()
        {
            Console.ForegroundColor = _foregroundColor;
            Console.WriteLine(_modifyString);
            Console.ResetColor();
        }

        public ChalkConsoleTextBuilder ApplyColor(ConsoleColor color)
        {
            _foregroundColor = color;
            return this;
        }

        public ChalkConsoleTextBuilder Reverse()
        {
            var cleanString = _modifyString.Replace(UnderlineOn, "").Replace(UnderlineOff, "");
            var sb = new StringBuilder(cleanString.Length);
            for (var i = cleanString.Length - 1; i >= 0; i--)
            {
                sb.Append(cleanString[i]);
            }

            _modifyString = _isUnderline ? UnderlineOn + cleanString + UnderlineOff : sb.ToString();
            return this;
        }

        public ChalkConsoleTextBuilder Underline()
        {
            _isUnderline = true;
            _modifyString = UnderlineOn + _modifyString + UnderlineOff;
            return this;
        }
    }
}