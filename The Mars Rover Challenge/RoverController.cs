using MarsRover;
using MarsRoverPlateau;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverController
{
	public class RoverController
	{
		public RoverController()
		{
			Initialize();
		}

		private void Initialize()
		{
			Plateau = new Plateau();
			ListOfRovers = new List<Rover>();
		}

		public List<Rover> ListOfRovers { get; set; }
		public Plateau Plateau { get; set; }
		private long _numberOfRovers;
		public long NumberOfRovers 
		{ 
			get
			{
				return _numberOfRovers;
			}
			set
			{
				if (value < 1 || value > MaxNumberOfRovers)
				{
					throw new ArgumentException($"Number of rovers should be between 0 and {MaxNumberOfRovers}.");
				}
				_numberOfRovers = value;
			} 
		}
		public long MaxNumberOfRovers
		{
			get
			{
				return _upperRightCoordinates.X * _upperRightCoordinates.Y;
			}
		}
		private Point _upperRightCoordinates;
		public string UpperRightCoordinates
		{
			get
			{
				return new string($"{_upperRightCoordinates.X} {_upperRightCoordinates.Y}");
			}
			set
			{
				var coordinates = value.Trim(' ');
				var coordinatesArray = coordinates.Split(' ');
				if (coordinatesArray.Length != 2)
				{
					throw new ArgumentException("Invalid number of arguments. Supply X and Y values in the form 'X Y'.");
				}

				var x = int.Parse(coordinatesArray[0]);
				var y = int.Parse(coordinatesArray[1]);

				if (x < 1 || x >20 || y < 1 || y > 30)
				{
					throw new ArgumentOutOfRangeException("Invalid upper right coordinates. X value cannot be less than 1 or greater than 30, Y value cannot be less than 1 or greater than 30.");
				}

				_upperRightCoordinates = new Point(x, y);
			}
		}

		public void Deploy(string position)
		{
			ListOfRovers.Add(new Rover(position, UpperRightCoordinates));
		}
	}
}
