using System;
using System.Drawing;

namespace MarsRover
{
	public class Rover
	{
		public Rover() { }
		public Rover(string position)
		{
			Position = position;
		}

		public enum Control
		{
			L = 0,	// Letf
			R = 1,	// Right
			M = 2	// Move
		}

		public enum Orientation
		{
			N = 0,  // North
			E = 1,  // East
			S = 2,  // South
			W = 3,	// West
		}

		private Position _position;
		public string Position 
		{
			get 
			{
				return new string($"{_position.Coordinates.X} {_position.Coordinates.Y} {_position.Orientation}");
			}
			set 
			{
				string position = value.Trim(' ');
				var positionArray = position.Split(' ');
				if (positionArray.Length != 3)
				{
					throw new ArgumentException("Invalid number of arguments. Supply X, Y and orientation values in the form 'X Y O'.");
				}

				int x = int.Parse(positionArray[0]);
				int y = int.Parse(positionArray[1]);
				char orientation = positionArray[2].ToUpper()[0];

				if (x < 0 || x > _upperRightCoordinates.X || y < 0 || y > _upperRightCoordinates.Y)
				{
					throw new ArgumentOutOfRangeException("X and Y coordinates can not exceed the bounds set by the upper right coordinates.");
				} 

				if (orientation != 'N' && orientation != 'E' && orientation != 'S' && orientation != 'W')
				{
					throw new FormatException("Invalid orientation. Valid values are N, E, S and W.");
				}
				
				_position = new Position
				{
					Coordinates = new Point(x, y),
					Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation.ToString())
				};
			} 
		}

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
				var coordinatesArray = coordinates.Split(' ');
				if (coordinatesArray.Length != 2)
				{
					throw new ArgumentException("Invalid number of arguments. Supply X and Y values in the form 'X Y'.");
				}

				int x = int.Parse(coordinatesArray[0]);
				int y = int.Parse(coordinatesArray[1]);

				if (x < 1 || y < 1)
				{
					throw new ArgumentOutOfRangeException("X or Y value for upper right coordinates cannot be less than 1.");
				}

				_upperRightCoordinates = new Point(x, y); 
			} 
		}

		public string Explore (string instructions)
		{
			var sanitizedInstruction = instructions.ToUpper();
			foreach(var instruction in sanitizedInstruction)
			{
				ValidateInstruction(instruction);

				Execute((Control)Enum.Parse(typeof(Control), instruction.ToString()));
			}

			return Position;
		}

		private void ValidateInstruction(char instruction)
		{
			if (instruction != 'L' && instruction != 'R' && instruction != 'M')
			{
				throw new FormatException("Invalid instruction. Valid values are L, R and M.");
			}
		}

		private void Execute(Control instruction)
		{
			switch (instruction)
			{
				case Control.L:
					UpdateOrientationLeft(instruction);
					break;
				case Control.R:
					UpdateOrientationRight(instruction);
					break;
				case Control.M:
					Move();
					break;
				default:
					break;
			}
		}

		private void UpdateOrientationLeft(Control instruction)
		{
			if (_position.Orientation == Orientation.N)
			{
				_position.Orientation = Orientation.W;
			}
			else
			{
				var orientation = (int)instruction - 1;
				_position.Orientation = (Orientation)orientation;
			}
		}

		private void UpdateOrientationRight(Control instruction)
		{
			if (_position.Orientation == Orientation.W)
			{
				_position.Orientation = Orientation.N;
			}
			else
			{
				var orientation = (int)instruction + 1;
				_position.Orientation = (Orientation)orientation;
			}
		}

		private void Move()
		{
			switch (_position.Orientation)
			{
				case Orientation.N:
					MoveNorth();
					break;
				case Orientation.E:
					MoveEast();
					break;
				case Orientation.S:
					SouthDown();
					break;
				case Orientation.W:
					MoveWest();
					break;
			}
		}

		private void MoveNorth()
		{
			var currentCoordinates = _position.Coordinates;
			var newYCoordinate = currentCoordinates.Y + 1;
			if (newYCoordinate <= _upperRightCoordinates.Y)
			{
				_position.Coordinates = new Point(currentCoordinates.X, newYCoordinate);
			}
			
		}

		private void MoveEast()
		{
			var currentCoordinates = _position.Coordinates;
			var newXCoordinate = currentCoordinates.X + 1;
			if (newXCoordinate <= _upperRightCoordinates.X)
			{
				_position.Coordinates = new Point(newXCoordinate, currentCoordinates.Y);
			}

		}

		private void SouthDown()
		{
			var currentCoordinates = _position.Coordinates;
			var newYCoordinate = currentCoordinates.Y - 1;
			if (newYCoordinate >= 0)
			{
				_position.Coordinates = new Point(currentCoordinates.X, newYCoordinate);
			}
		}

		private void MoveWest()
		{
			var currentCoordinates = _position.Coordinates;
			var newXCoordinate = currentCoordinates.X - 1;
			if (newXCoordinate >= 0)
			{
				_position.Coordinates = new Point(newXCoordinate, currentCoordinates.Y);
			}
		}
	}
}
