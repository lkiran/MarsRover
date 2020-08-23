using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MarsRover.Utils;

namespace MarsRover
{
    public static class RoverInputExecuter
    {
        private static readonly Dictionary<char, MethodInfo?> MethodCache = new Dictionary<char, MethodInfo?>();

        private static MethodInfo? GetCommandMethod(char command)
        {
            if (MethodCache.ContainsKey(command)) 
                return MethodCache[command];
            
            var method = typeof(Rover)
                .GetMethods()
                .FirstOrDefault(m =>
                    m.GetCustomAttributes(typeof(CommandAttribute), false)
                        .Any(a => ((CommandAttribute) a).Command == command));
            MethodCache.Add(command, method);

            return MethodCache[command];
        }

        public static void Execute(Rover rover, char command)
        {
            var parameters = new object[] { };
            var method = GetCommandMethod(command);
            if (method != null)
                method.Invoke(rover, parameters);
        }

        public static void Execute(Rover rover, string command)
        {
            command.ToList().ForEach(c => Execute(rover, c));
        }
    }
}