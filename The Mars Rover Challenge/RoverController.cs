using MarsRover;
using MarsRoverPlateau;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverController
{
	class RoverController
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

				if (x < 1 || y < 1)
				{
					throw new ArgumentOutOfRangeException("X or Y value for upper right coordinates cannot be less than 1.");
				}

				_upperRightCoordinates = new Point(x, y);
			}
		}

		public void DeployRovers()
		{
			for (int i = 0; i < _numberOfRovers; i++)
			{
				Console.Write($"Enter the position for Rover Id# {i + 1}: ");
				var position = Console.ReadLine();
				ListOfRovers.Add(new Rover(position, UpperRightCoordinates));
			}
		}
	}
}
