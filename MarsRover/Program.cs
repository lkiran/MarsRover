using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> commands = new Queue<string>();

            while (true)
            {
                Console.Write("-> ");
                var input = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(input) || input== "\n")
                    break;
                
                commands.Enqueue(input.ToUpper());
            }
            
            var plateau = PlateauInputExecuter.Create(commands.Dequeue());
            while (commands.Any())
            {
                var rover = PlateauInputExecuter.DeployRover(plateau, commands.Dequeue());
                RoverInputExecuter.Execute(rover, commands.Dequeue());
            }

            plateau.Rovers.ForEach(r => Console.WriteLine(r.Position));
        }
    }
}