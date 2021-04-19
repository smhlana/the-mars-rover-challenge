using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverController;
using System.Collections.Generic;

namespace MarsRoverControllerTests
{
	[TestClass]
	public class MarsRoverControllerTests
	{
		#region SetPlateauBoundsRegion
		[TestMethod]
		public void UpperRightCoordinates_WithValidInput_SetsCoordinates()
		{
			var upperRightCoordinates = "10 15";
			var expected = "10 15";
			
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			var actual = rover.UpperRightCoordinates;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void UpperRightCoordinates_UpperRightCoordinatesWithTrailingOrLeadingWhiteSpace_SanitizesAndSetsCoordinates()
		{
			var upperRightCoordinates = " 10 15 ";
			var expected = "10 15";

			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			var actual = rover.UpperRightCoordinates;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void UpperRightCoordinates_WithXUpperRightCoordinateLessThan1_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "0 15";
			var rover = new RoverController();

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_WithYUpperRightCoordinateLessThan1_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "15 0";
			var rover = new RoverController();

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_WithXUpperRightCoordinateGreaterThan20_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "25 10";
			var rover = new RoverController();

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_WithYUpperRightCoordinateGreaterThan30_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "15 40";
			var rover = new RoverController();

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_UpperRightCoordinatesWithInvalidSyntaxX_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "H 15";
			var rover = new RoverController();

			Assert.ThrowsException<System.FormatException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_UpperRightCoordinatesWithInvalidSyntaxY_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "10 H";
			var rover = new RoverController();

			Assert.ThrowsException<System.FormatException>(() => rover.UpperRightCoordinates = upperRightCoordinates);
		}
		#endregion

		#region SetRoverPositionRegion
		[TestMethod]
		public void DeploySingleRover_WithValidPosition_DeploysSingleRover()
		{
			var upperRightCoordinates = "10 10";
			var position = "5 1 N";
			var expectedPosition = "5 1 N";
			var expectedNumberOfRovers = 1;
			var numberOfRovers = 1;
			var rover = new RoverController();

			rover.UpperRightCoordinates = upperRightCoordinates;
			rover.NumberOfRovers = numberOfRovers;
			for (int i = 0; i < numberOfRovers; i++)
			{
				rover.Deploy(position);
			}
			var actualPosition = rover.ListOfRovers[0].Position;
			var actualNumberOfRovers = rover.ListOfRovers.Count;

			Assert.AreEqual(expectedPosition, actualPosition, "The set value is not equal to the get value");
			Assert.AreEqual(expectedNumberOfRovers, actualNumberOfRovers, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void DeploySingleRover_PositionWithMissingArgument_ShouldThrowArgumentException()
		{
			var upperRightCoordinates = "10 10";
			var position = "5 N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.ArgumentException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void DeploySingleRover_PositionWithExtraArgument_ShouldThrowArgumentException()
		{
			var upperRightCoordinates = "10 10";
			var position = "5 10 6 N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.ArgumentException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void DeploySingleRover_PositionWithInvalidSyntaxX_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "10 10";
			var position = "H 5 N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.FormatException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void Rover_PositionWithInvalidSyntaxY_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "10 10";
			var position = "5 H N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.FormatException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void Rover_PositionWithInvalidSyntaxO_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "10 10";
			var position = "5 5 10";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.FormatException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void Rover_PositionOutOfBoundsX_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "12 12";
			var position = "13 10 N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void Rover_PositionOutOfBoundsY_ShouldThrowArgumentOutOfRangeException()
		{
			var upperRightCoordinates = "12 12";
			var position = "10 13 N";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => rover.Deploy(position));
		}

		[TestMethod]
		public void DeployMultipleRovers_WithValidPositions_DeploysMultipleRovers()
		{
			var upperRightCoordinates = "10 10";
			var numberOfRovers = 3;
			var expectedNumberOfRovers = 3;
			var rover = new RoverController();

			string[] positions = new string[] { "5 1 N", "5 10 E", "10 0 W" }; 
			rover.UpperRightCoordinates = upperRightCoordinates;
			for (int i = 0; i < numberOfRovers; i++)
			{
				rover.Deploy(positions[i]);
			}

			var actualNumberOfRovers = rover.ListOfRovers.Count;

			Assert.AreEqual(expectedNumberOfRovers, actualNumberOfRovers, "The set value is not equal to the get value");
		}
		#endregion

		#region ExecuteRoverInstructionsRegion
		[TestMethod]
		public void Rover_WithInvalidInstruction_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 1 N";
			var instruction = "H";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);

			Assert.ThrowsException<System.FormatException>(() => rover.ListOfRovers[0].Explore(instruction));
		}

		[TestMethod]
		public void Rover_WithMultipleInstructionsContainingInvalidInstruction_ShouldThrowFormatException()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 5 N";
			var instruction = "LMLMRTRMLLM";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);

			Assert.ThrowsException<System.FormatException>(() => rover.ListOfRovers[0].Explore(instruction));
		}

		[TestMethod]
		public void Rover_LeftInstruction_SetsRoverOrientation()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "5 1 W";
			var instruction = "L";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);

			var actual = rover.ListOfRovers[0].Position;
			Assert.AreEqual(expected, actual, "L instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_RightInstruction_SetsRoverOrientation()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "5 1 E";
			var instruction = "R";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);
			var actual = rover.ListOfRovers[0].Position;
			rover.ListOfRovers[0].Explore(instruction);

			Assert.AreEqual(expected, actual, "R instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveLeftInstruction_SetsRoverOrientation()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "4 1 W";
			var instruction = "LM";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);
			var actual = rover.ListOfRovers[0].Position;
			rover.ListOfRovers[0].Explore(instruction);
			
			Assert.AreEqual(expected, actual, "LM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveLeftInstructionOnLeftBound_NoChangeInCoordinates()
		{
			var upperRightCoordinates = "12 12";
			var position = "0 1 N";
			var expected = "0 1 W";
			var instruction = "LM";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);
			var actual = rover.ListOfRovers[0].Position;
			rover.ListOfRovers[0].Explore(instruction);

			Assert.AreEqual(expected, actual, "LM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveRightInstruction_SetsRoverOrientation()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 1 S";
			var expected = "4 1 W";
			var instruction = "RM";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);
			var actual = rover.ListOfRovers[0].Position;
			rover.ListOfRovers[0].Explore(instruction);
			
			Assert.AreEqual(expected, actual, "RM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveRightInstructionOnRightBound_NoChangeInCoordinates()
		{
			var upperRightCoordinates = "12 12";
			var position = "12 1 N";
			var expected = "12 1 E";
			var instruction = "RM";
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);
			rover.ListOfRovers[0].Explore(instruction);
			var actual = rover.ListOfRovers[0].Position;
			rover.ListOfRovers[0].Explore(instruction);
			
			Assert.AreEqual(expected, actual, "RM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_WithNullInstructionParameter_ShouldThrowArgumentNullException()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 5 N";
			string instruction = null;
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);

			Assert.ThrowsException<System.ArgumentNullException>(() => rover.ListOfRovers[0].Explore(instruction));
		}

		[TestMethod]
		public void Rover_WithEmptyInstructionParameter_ShouldThrowArgumentNullException()
		{
			var upperRightCoordinates = "12 12";
			var position = "5 5 N";
			var instruction = string.Empty;
			var rover = new RoverController
			{
				UpperRightCoordinates = upperRightCoordinates
			};

			rover.Deploy(position);

			Assert.ThrowsException<System.ArgumentNullException>(() => rover.ListOfRovers[0].Explore(instruction));
		}
		#endregion
	}
}
