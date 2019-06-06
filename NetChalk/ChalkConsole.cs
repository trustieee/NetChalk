using System;

namespace NetChalk
{
    public class ChalkConsole
    {
        private const ConsoleColor DefaultForegroundColor = ConsoleColor.Gray;
        private const ConsoleColor DefaultBackgroundColor = ConsoleColor.Black;

        private bool _resetAfterWrite = true;

        public ConsoleColor CurrentForegroundColor { get; private set; }
        public ConsoleColor CurrentBackgroundColor { get; private set; }

        public ChalkConsole SetForegroundColor(ConsoleColor color, bool resetAfterWrite = false)
        {
            Console.ForegroundColor = CurrentForegroundColor = color;
            _resetAfterWrite = resetAfterWrite;
            return this;
        }

        public ChalkConsole SetBackgroundColor(ConsoleColor color, bool resetAfterWrite = false)
        {
            Console.BackgroundColor = CurrentBackgroundColor = color;
            _resetAfterWrite = resetAfterWrite;
            return this;
        }

        public ChalkConsole ResetColors()
        {
            Console.ForegroundColor = CurrentForegroundColor = DefaultForegroundColor;
            Console.BackgroundColor = CurrentBackgroundColor = DefaultBackgroundColor;
            _resetAfterWrite = true;
            return this;
        }

        private ChalkConsole InternalWrite(string value)
        {
            Console.Write(value);
            if (_resetAfterWrite)
            {
                ResetColors();
            }
            else
            {
                _resetAfterWrite = true;
            }

            return this;
        }

        private ChalkConsole InternalWriteLine(string value)
        {
            Console.WriteLine(value);
            if (_resetAfterWrite)
            {
                ResetColors();
            }
            else
            {
                _resetAfterWrite = true;
            }

            return this;
        }

        public ChalkConsole Write(string value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            if (foregroundColor != null)
            {
                SetForegroundColor(foregroundColor.Value, true);
            }

            if (backgroundColor != null)
            {
                SetBackgroundColor(backgroundColor.Value, true);
            }

            return InternalWrite(value);
        }

        public ChalkConsole WriteLine(string value, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null) =>
            Write(value + Environment.NewLine, foregroundColor, backgroundColor);

        public ChalkConsoleTextBuilder Text(string text) => new ChalkConsoleTextBuilder(text);
    }
}