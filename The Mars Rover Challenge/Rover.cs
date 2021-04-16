using System.Drawing;

namespace MarsRover
{
	class Rover
	{
		public enum Control
		{
			L = 0,	// Letf
			R = 1,	// Right
			M = 2	// Move
		}

		public Position Position { get; set; }

		public static Point UpperRightCoordinates { get; set; }
	}
}
