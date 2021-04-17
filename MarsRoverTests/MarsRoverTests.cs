using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
	[TestClass]
	public class MarsRoverTests
	{
		#region SetPlateauBoundsRegion
		[TestMethod]
		public void UpprerRightCoordinates_WithValidInput_SetsCoordinates()
		{
			string upperRightCoordinates = "10 15";
			string expected = "10 15";

			Rover.UpperRightCoordinates = upperRightCoordinates;

			string actual = Rover.UpperRightCoordinates;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}

		[TestMethod]
		public void UpprerRightCoordinates_WithUpprerRightCoordinatesLessThanOne_ShouldThrowArgumentOutOfRangeException()
		{
			string upperRightCoordinates = "0 15";

			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => Rover.UpperRightCoordinates = upperRightCoordinates);
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
		#endregion
	}
}
