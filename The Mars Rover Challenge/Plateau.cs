using MarsRover;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Text;

namespace MarsRoverPlateau
{
	class Plateau
	{
		public void Draw(List<Rover> list, string upperRightCoordinates)
		{
			List<Rover> listOfRovers = new List<Rover>(list);
			var upperRightCoordinatesArray = upperRightCoordinates.Split(' ');
			var x = int.Parse(upperRightCoordinatesArray[0]);
			var y = int.Parse(upperRightCoordinatesArray[1]);
			var bounds = new Point(x, y);
			
			for (int yCoordinate = bounds.Y; yCoordinate >= 0; yCoordinate--)
			{
				for (int xCoordinate = 0; xCoordinate <= bounds.X; xCoordinate++)
				{
					Console.Write(GetObjectPointOnGrid(listOfRovers, new Point(xCoordinate, yCoordinate)));
					if (xCoordinate < bounds.X) Console.Write("-----");
				}
				Console.WriteLine();
			}
		}

		private string GetObjectPointOnGrid(List<Rover> listOfRovers, Point point)
		{
			var numberOfSpaces = GetLengthOfLongestId(listOfRovers) + 4;
			var pointOnGrid = SetEmptyPoint(numberOfSpaces);
			for (int i = 0; i < listOfRovers.Count; i++)
			{
				var position = listOfRovers[i].Position;
				var positionArray = position.Split(' ');
				var x = int.Parse(positionArray[0]);
				var y = int.Parse(positionArray[1]);

				var roverPoint = new Point(x, y);
				if (roverPoint == point)
				{
					var roverInfo = $"{(i + 1)} {(positionArray[2])}";
					pointOnGrid = SetPoint(roverInfo);
				}
			}

			return pointOnGrid;
		}

		private int GetLengthOfLongestId(List<Rover> listOfRovers)
		{
			int length = 1;
			for (int i = 0; i <listOfRovers.Count; i++)
			{
				var idLength = i.ToString().Length;
				if (idLength > length) length = idLength;
			}

			return length;
		}

		private string SetEmptyPoint(int numberOfSpaces)
		{
			var point = new StringBuilder();
			var spacesToFill = numberOfSpaces - 2;
			var halfway = (spacesToFill / 2) + 1;
			point.Append("[");
			for (int i = 0; i < spacesToFill; i++)
			{
				if (i + 1 == halfway) point.Append("+");
				else point.Append(" ");
			}
			point.Append("]");

			return point.ToString();
		}

		private string SetPoint(string roverInfo)
		{
			return $"({roverInfo})";
		}
	}
}
