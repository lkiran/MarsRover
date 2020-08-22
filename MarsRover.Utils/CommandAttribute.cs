using System;

namespace MarsRover.Utils
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CommandAttribute: Attribute
    {
        public char Command { get; set; }

        public CommandAttribute(char command) {
            Command = command;
        }
        
    }
}