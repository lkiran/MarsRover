using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MarsRover.Utils;

namespace MarsRover
{
    public static class RoverInputHandler
    {
        public static void Execute(Rover rover, char command)
        {
            var parameters = new object[] { };
            var method = typeof(Rover)
                .GetMethods()
                .FirstOrDefault(m =>
                    m.GetCustomAttributes(typeof(CommandAttribute), false)
                        .Any(a => ((CommandAttribute) a).Command == command));

            if (method != null)
                method.Invoke(rover, parameters);
        }

        public static void Execute(Rover rover, string command)
        {
            command.ToList().ForEach(c => Execute(rover, c));
        }
    }
}