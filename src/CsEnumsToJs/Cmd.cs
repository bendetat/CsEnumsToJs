﻿using System;
using System.Reflection;

namespace CsEnumsToJs
{
    public static class Cmd
    {
        public static void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public static void Write(string value)
        {
            Console.Write(value);
        }

        public static void WriteLine(string line, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static void Write(string line, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.Write(line);
            Console.ResetColor();
        }

        public static void WriteLine(string line, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static void Write(string line, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(line);
            Console.ResetColor();
        }

        public static string Prompt()
        {
            Write("> ");
            return Console.ReadLine();
        }

        public static string Prompt(string path)
        {
            Write(string.Format("{0}> ", path));
            return Console.ReadLine();
        }

        public static void WriteInfoLine(string line)
        {
            WriteLine(line, ConsoleColor.Cyan);
        }

        public static void WriteSuccessLine(string line)
        {
            WriteLine(line, ConsoleColor.Green);
        }

        public static void WriteWarningLine(string line)
        {
            WriteLine(line, ConsoleColor.Yellow);
        }

        public static void WriteErrorLine(string line)
        {
            WriteLine(line, ConsoleColor.Red);
        }

        public static void WriteException(Exception exception, bool showFull = false)
        {
            WriteInfoLine(exception.Message);
            if (showFull)
            {
                WriteActualException(exception);
            }
            else
            {
                WriteLine("More info? (n)");
                var showFullException = Prompt();
                if (showFullException.IsRoughly("y", "yes"))
                {
                    WriteActualException(exception);
                }
            }
        }

        private static void WriteActualException(Exception exception)
        {
            WriteLine(exception.ToString());

            var rtle = exception as ReflectionTypeLoadException;
            if (rtle != null)
            {
                WriteLine("RTLE");

                foreach (var e in rtle.LoaderExceptions)
                {
                    WriteActualException(e);
                }
            }
        }
    }
}