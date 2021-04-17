using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
	[TestClass]
	public class MarsRoverTests
	{
		#region SetPlateauBoundsRegion
		[TestMethod]
		public void UpperRightCoordinates_WithValidInput_SetsCoordinates()
		{
			string upperRightCoordinates = "10 15";
			string expected = "10 15";

			Rover.UpperRightCoordinates = upperRightCoordinates;

			string actual = Rover.UpperRightCoordinates;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void UpperRightCoordinates_WithUpperRightCoordinatesLessThanOne_ShouldThrowArgumentOutOfRangeException()
		{
			string upperRightCoordinates = "0 15";

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => Rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_UpperRightCoordinatesWithInvalidSyntaxX_ShouldThrowFormatException()
		{
			string upperRightCoordinates = "H 15";

			Assert.ThrowsException<System.FormatException>(() => Rover.UpperRightCoordinates = upperRightCoordinates);
		}

		[TestMethod]
		public void UpperRightCoordinates_UpperRightCoordinatesWithInvalidSyntaxY_ShouldThrowFormatException()
		{
			string upperRightCoordinates = "10 H";

			Assert.ThrowsException<System.FormatException>(() => Rover.UpperRightCoordinates = upperRightCoordinates);
		}
		#endregion

		#region SetRoverPositionRegion
		[TestMethod]
		public void Rover_WithValidPosition_SetsRoverPosition()
		{
			string position = "5 1 N";
			string expected = "5 1 N";

			var rover = new Rover(position);

			string actual = rover.Position;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void Rover_WithMissingArgument_ShouldThrowArgumentException()
		{
			string position = "5 N";

			Assert.ThrowsException<System.ArgumentException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_WithExtraArgument_ShouldThrowArgumentException()
		{
			string position = "5 10 6 N";

			Assert.ThrowsException<System.ArgumentException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_PositionWithInvalidSyntaxX_ShouldThrowFormatException()
		{
			string position = "H 5 N";

			Assert.ThrowsException<System.FormatException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_PositionWithInvalidSyntaxY_ShouldThrowFormatException()
		{
			string position = "5 H N";

			Assert.ThrowsException<System.FormatException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_PositionWithInvalidSyntaxO_ShouldThrowFormatException()
		{
			string position = "5 5 10";

			Assert.ThrowsException<System.FormatException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_PositionOutOfBoundsX_ShouldThrowArgumentOutOfRangeException()
		{
			Rover.UpperRightCoordinates = "12 12";
			string position = "50 10 N";

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Rover(position));
		}

		[TestMethod]
		public void Rover_PositionOutOfBoundsY_ShouldThrowArgumentOutOfRangeException()
		{
			Rover.UpperRightCoordinates = "12 12";
			string position = "10 50 N";

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Rover(position));
		}
		#endregion

		#region ExecuteRoverInstructionsRegion
		[TestMethod]
		public void Rover_WithInvalidInstruction_ShouldThrowFormatException()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 1 N";
			var instruction = "H";
			var rover = new Rover(position);

			Assert.ThrowsException<System.FormatException>(() => rover.Explore(instruction));
		}

		[TestMethod]
		public void Rover_WithMultipleInstructionsContainingInvalidInstruction_ShouldThrowFormatException()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 5 N";
			var instruction = "LMLMRTRMLLM";
			var rover = new Rover(position);

			Assert.ThrowsException<System.FormatException>(() => rover.Explore(instruction));
		}

		[TestMethod]
		public void Rover_LeftInstruction_SetsRoverOrientation()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "5 1 W";
			var instruction = "L";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "L instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_RightInstruction_SetsRoverOrientation()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "5 1 E";
			var instruction = "R";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "R instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveLeftInstruction_SetsRoverOrientation()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 1 N";
			var expected = "4 1 W";
			var instruction = "LM";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "LM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveLeftInstructionOnLeftBound_NoChangeInCoordinates()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "0 1 N";
			var expected = "0 1 W";
			var instruction = "LM";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "LM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveRightInstruction_SetsRoverOrientation()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "5 1 S";
			var expected = "4 1 W";
			var instruction = "RM";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "RM instruction not executed correctly.");
		}

		[TestMethod]
		public void Rover_MoveRightInstructionOnRightBound_NoChangeInCoordinates()
		{
			Rover.UpperRightCoordinates = "12 12";
			var position = "12 1 N";
			var expected = "12 1 E";
			var instruction = "RM";

			var rover = new Rover(position);
			rover.Explore(instruction);

			var actual = rover.Position;
			Assert.AreEqual(expected, actual, "RM instruction not executed correctly.");
		}
		#endregion
	}
}
