using System;
using MarsRoverController;

namespace MarsRover
{
	class Program
	{
		static void Main(string[] args)
		{
			var rover = new RoverController();
			Console.Write("Enter the upper right coordinates: ");
			rover.UpperRightCoordinates = Console.ReadLine();

			Console.Write($"Enter the number of rovers you want to deploy on the plateau (Max = {rover.MaxNumberOfRovers}): ");
			rover.NumberOfRovers = int.Parse(Console.ReadLine());

			Console.WriteLine("Position format: X Y O");
			Console.WriteLine("Please take note of the Rover Id#\n");

			for (int i = 0; i < rover.NumberOfRovers; i++)
			{
				Console.Write($"Enter the position for Rover Id# {i + 1}: ");
				var position = Console.ReadLine();
				rover.Deploy(position);
			}

			while (true)
			{
				Console.Clear();
				Console.WriteLine();
				rover.Plateau.Draw(rover.ListOfRovers, rover.UpperRightCoordinates);
				Console.WriteLine();
				DisplayControlInstructions();

				var command = Console.ReadLine().ToUpper();
				if (command == "Q")
				{
					break;
				}

				var spaceIndex = command.IndexOf(" ");
				var roverId = int.Parse(command.Substring(0, spaceIndex));
				if (roverId < 1 || roverId > rover.ListOfRovers.Count)
				{
					Console.WriteLine($"Invalid Rover Id#. Should be between 1 and {rover.ListOfRovers.Count}.\n");
					continue;
				}

				var instructions = command.Substring(spaceIndex + 1);
				rover.ListOfRovers[roverId - 1].Explore(instructions);

				for (int i = 0; i < rover.ListOfRovers.Count; i++)
				{
					Console.WriteLine($"Rover Id#{i + 1}: {rover.ListOfRovers[i].Position}");
				}
			}

			Console.Clear();
			for (int i = 0; i < rover.ListOfRovers.Count; i++)
			{
				Console.WriteLine($"Rover Id#{i + 1}: {rover.ListOfRovers[i].Position}");
			}
			Console.WriteLine();
			rover.Plateau.Draw(rover.ListOfRovers, rover.UpperRightCoordinates);
		}

		private static void DisplayControlInstructions()
		{
			Console.WriteLine("\nTo control the rovers enter the Rover Id# folowed by a space and then a series of instructions.");
			Console.WriteLine("E.g. 1 LMLMRMRRM");
			Console.WriteLine("To quit enter Q or q.\n");
		}
	}
}
