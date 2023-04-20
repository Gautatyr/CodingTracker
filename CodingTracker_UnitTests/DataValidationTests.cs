using static CodingTracker.DataValidation;

namespace CodingTracker_UnitTests;

[TestClass]
public class DataValidationTests
{
    [TestMethod]
    public void IsPositiveNumber_PositiveNumber_ReturnsTrue()
    {
        // Arrange
         string input = "23";

        // Act
        var result = IsPositiveNumber(input);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsPositiveNumber_NegativeNumber_ReturnsFalse()
    {
        // Arrange
         string input = "-23";

        // Act
        var result = IsPositiveNumber(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPositiveNumber_Zero_ReturnsTrue()
    {
        // Arrange
         string input = "0";

        // Act
        var result = IsPositiveNumber(input);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsPositiveNumber_NotANumber_ReturnsFalse()
    {
        // Arrange
        string input = "I am not a number";

        // Act
        var result = IsPositiveNumber(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPositiveNumber_Empty_ReturnsFalse()
    {
        // Arrange
        string input = string.Empty;

        // Act
        var result = IsPositiveNumber(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidDate_ValidDate_ReturnsTrue()
    {
        // Arrange
        string input = "22-10-98";

        // Act
        var result = IsValidDate(input);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidDate_NotADate_ReturnsFalse()
    {
        // Arrange
        string input = "this is not a date";

        // Act
        var result = IsValidDate(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidDate_InvalidDateFormat_ReturnsFalse()
    {
        // Arrange
        string input = "10-22-98";

        // Act
        var result = IsValidDate(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidDate_Empty_ReturnsFalse()
    {
        // Arrange
        string input = string.Empty;

        // Act
        var result = IsValidDate(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidTime_ValidTime_ReturnsTrue()
    {
        // Arrange
        string input = "22:10";

        // Act
        var result = IsValidTime(input);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidTime_InvalidTime_ReturnsFalse()
    {
        // Arrange
        string input = "2:2";

        // Act
        var result = IsValidTime(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidTime_NotADateTime_ReturnsFalse()
    {
        // Arrange
        string input = "This is not a datetime";

        // Act
        var result = IsValidTime(input);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidTime_Empty_ReturnsTrue()
    {
        // Arrange
        string input = string.Empty;

        // Act
        var result = IsValidTime(input);

        // Assert
        Assert.IsFalse(result);
    }
}