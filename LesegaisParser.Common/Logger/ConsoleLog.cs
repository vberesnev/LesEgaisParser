using System;
using System.Collections.Generic;

namespace LesegaisParser.Common.Logger
{
    class ConsoleLog : ILogger
    {
        internal ConsoleLog(){}
        
        private static readonly Dictionary<LogType, ConsoleColor> ConsoleColorDict = new()
        {
            {LogType.Debug, ConsoleColor.White},
            {LogType.Success, ConsoleColor.Green},
            {LogType.Error, ConsoleColor.Red}
        };

        public void Print(LogType type, string message)
        {
            Console.ForegroundColor = ConsoleColorDict[type];
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} | {message}");
            Console.ResetColor();
        }
    }
}