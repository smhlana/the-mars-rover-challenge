using System;
using System.Collections.Generic;

namespace MarsRover
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the upper right coordinates: ");
			Rover.UpperRightCoordinates = Console.ReadLine();

			Console.Write($"Enter the number of rovers you want to deploy on the plateau (Max = {Rover.MaxNumberOfRovers}): ");
			var numberOfRovers = int.Parse(Console.ReadLine());
			if (numberOfRovers < 1 || numberOfRovers > Rover.MaxNumberOfRovers)
			{
				throw new ArgumentException($"Number of rovers should be between 0 and {Rover.MaxNumberOfRovers}.");
			}

			var listOfRovers = new List<Rover>();
			Console.WriteLine("Position format: X Y O");
			Console.WriteLine("Please take note of the Rover Id#\n");
			for (int i = 0; i < numberOfRovers; i++)
			{
				Console.Write($"Enter the position for Rover Id# {i + 1}: ");
				var position = Console.ReadLine();
				listOfRovers.Add(new Rover(position));
			}

			Console.WriteLine("To control the rovers enter the Rover Id# folowed by a space and then a series of instructions.");
			Console.WriteLine("E.g. 1 LMLMRMRRM");
			Console.WriteLine("To quit enter Q or q.");
			while (true)
			{
				var command = Console.ReadLine().ToUpper();
				if (command == "Q")
				{
					break;
				}

				var spaceIndex = command.IndexOf(" ");
				var roverId = int.Parse(command.Substring(0, spaceIndex));
				if (roverId < 1 || roverId > listOfRovers.Count)
				{
					Console.WriteLine($"Invalid Rover Id#. Should be between 1 and {listOfRovers.Count}.");
					continue;
				}

				var instructions = command.Substring(spaceIndex + 1);
				listOfRovers[roverId - 1].Explore(instructions);

				foreach (var rover in listOfRovers)
				{
					Console.WriteLine(rover.Position);
				}
			}

			foreach(var rover in listOfRovers)
			{
				Console.WriteLine(rover.Position);
			}

			//Console.WriteLine("Upper right coord: " + Rover.UpperRightCoordinates);

			//Rover rover = new Rover("5 1 N");
			//Console.WriteLine("Position: " + rover.Position);

			//rover.Explore("R");
		}
	}
}
