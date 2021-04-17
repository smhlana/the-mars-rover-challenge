using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
	[TestClass]
	public class MarsRoverTests
	{
		[TestMethod]
		public void UpprerRightCoordinates_WithValidInput_SetsCoordinates()
		{
			string upperRightCoordinates = "10 15";
			string expected = "10 15";

			Rover.UpperRightCoordinates = upperRightCoordinates;

			string actual = Rover.UpperRightCoordinates;
			Assert.AreEqual(expected, actual, "The set value is not equal to the get value");
		}
	}
}
