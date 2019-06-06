using System;

namespace NetChalk.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chalk = new ChalkConsole();
            chalk.WriteLine("default writeline string");
            chalk.WriteLine("blue string", ConsoleColor.Blue);
            chalk.WriteLine("default writeline string");
            chalk.WriteLine("cyan background string", backgroundColor: ConsoleColor.Cyan);
            chalk.SetForegroundColor(ConsoleColor.Red);
            chalk.Write("write string");
            chalk.Write("write string");
            chalk.ResetColors();
            chalk.WriteLine("default writeline string");
            chalk.Text("builder string").WriteLine();
            chalk.Text("red builder string").ApplyColor(ConsoleColor.Red).WriteLine();
            chalk.Text("green reversed builder string").Reverse().ApplyColor(ConsoleColor.Green).WriteLine();
            chalk.Text("underlined builder string").Underline().WriteLine();
            chalk.Text("magenta underlined reversed builder string").Underline().Reverse().ApplyColor(ConsoleColor.DarkMagenta).WriteLine();
            chalk.Text("normal string").WriteLine();
        }
    }
}