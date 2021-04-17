using System;

namespace MarsRover
{
	class Program
	{
		static void Main(string[] args)
		{
			Rover.UpperRightCoordinates = Console.ReadLine();
			Console.WriteLine(Rover.UpperRightCoordinates);

			Rover rover = new Rover();
			rover.Position = Console.ReadLine();
			Console.WriteLine(rover.Position);
		}
	}
}
