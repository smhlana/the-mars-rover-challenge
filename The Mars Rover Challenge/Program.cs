using System;

namespace MarsRover
{
	class Program
	{
		static void Main(string[] args)
		{
			Rover.UpperRightCoordinates = "12 12";
			Console.WriteLine("Upper right coord: " + Rover.UpperRightCoordinates);

			Rover rover = new Rover("5 1 N");
			Console.WriteLine("Position: " + rover.Position);

			rover.Explore("R");
		}
	}
}
