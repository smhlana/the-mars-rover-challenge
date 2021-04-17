using System;
using System.Drawing;

namespace MarsRover
{
	public class Rover
	{
		private static char[] _charsToTrim = { ' ', ',' };
		public enum Control
		{
			L = 0,	// Letf
			R = 1,	// Right
			M = 2	// Move
		}

		public Position Position { get; set; }

		private static Point _upperRightCoordinates;
		public static string UpperRightCoordinates 
		{
			get
			{
				return new string($"{_upperRightCoordinates.X} {_upperRightCoordinates.Y}");
			}
			set 
			{
				string coordinates = value.Trim(' ');
				int indexOfSeparator = coordinates.IndexOf(' ');

				int x = int.Parse(coordinates.Substring(0, indexOfSeparator));
				int y = int.Parse(coordinates.Substring(indexOfSeparator + 1));

				if (x == 0 || y == 0)
				{
					throw new ArgumentException("X or Y value for upper right coordinates cannot be zero.");
				}

				_upperRightCoordinates = new Point(x, y); 
			} 
		}
	}
}
