using System;
using System.Linq;
using System.Reflection;
using MarsRover.Utils;

namespace MarsRover
{
    public static class PlateauInputExecuter
    {
        public static Plateau Create(string command)
        {
            var commandParts = command.Split(" ");
            if (commandParts.Length != 2)
                throw new TargetParameterCountException(
                    "Plateau size command consists of 'width' and 'height' parameters separated by a single space.");

            if (int.TryParse(commandParts[0], out var width) == false)
                throw new ArgumentException("Plateau width must be a valid integer");

            if (int.TryParse(commandParts[1], out var height) == false)
                throw new ArgumentException("Plateau height must be a valid integer");

            var bottomLeftPoint = new Point(0, 0);
            var topRightPoint = new Point(width, height);
            var plateau = new Plateau(bottomLeftPoint, topRightPoint);

            return plateau;
        }

        public static Rover DeployRover(Plateau plateau, string command)
        {
            var commandParts = command.Split(" ");
            if (commandParts.Length != 3)
                throw new TargetParameterCountException(
                    "Deploy Rover command consists of 'x-coordinate', 'y-coordinate' and 'heading' parameters separated by a single space.");

            if (int.TryParse(commandParts[0], out var x) == false)
                throw new ArgumentException("Rover x-coordinate must be a valid integer");

            if (int.TryParse(commandParts[1], out var y) == false)
                throw new ArgumentException("Rover y-coordinate must be a valid integer");
            var heading = Cardinals.Get(commandParts[2]);
            if (heading == null)
                throw new ArgumentException(
                    $"Rover heading can be one of {string.Join(", ", Cardinals.ToList().Select(c => c.Value))}");

            var position = new Position(new Point(x, y), heading);
            var rover = (Rover)plateau.DeployRover(position);

            return rover;
        }
    }
}