using System;
using System.Drawing;

namespace MarsRover
{
	class Rover
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
				var coocrdinates = value.Replace(" ", "");
				int x = int.Parse(coocrdinates.Substring(0, 1));
				int y = int.Parse(coocrdinates.Substring(1, 1));
				_upperRightCoordinates = new Point(x, y); 
			} 
		}
	}
}
