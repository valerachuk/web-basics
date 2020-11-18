using System;
using Xunit;

namespace StringUnitTests
{
  // Substring source code
  // https://referencesource.microsoft.com/#mscorlib/system/string.cs,8124961f027d9ac9

  public class SubstringTest
  {
    [Theory]
    [InlineData("hello", 0, 5, "hello")]
    [InlineData("hello", 1, 4, "ello")]
    [InlineData("hello", 2, 3, "llo")]
    [InlineData("hello", 3, 2, "lo")]
    [InlineData("hello", 4, 1, "o")]
    [InlineData("hello", 5, 0, "")]
    [InlineData("hello", 2, 2, "ll")]
    [InlineData("hello", 0, 4, "hell")]
    [InlineData("hello", 0, 0, "")]
    [InlineData("hello", 4, 0, "")]
    [InlineData("", 0, 0, "")]
    public void Substring_GettingSubstring_ShouldReturnSubstring(string @string, int startIndex, int length, string expectedSubstring)
    {
      // Arrange

      // Act
      var actualSubstring = @string.Substring(startIndex, length);

      // Assert
      Assert.Equal(expectedSubstring, actualSubstring);
    }

    [Theory]
    [InlineData("hello", -123)]
    [InlineData("", -1)]
    [InlineData("hello", 6)]
    [InlineData("123", 100)]
    public void Substring_GettingSubstringWithInvalidStartIndex_ShouldFail(string @string, int startIndex)
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>("startIndex", () => @string.Substring(startIndex));

      // Assert

    }

    [Theory]
    [InlineData("hello", 0, -123)]
    [InlineData("", 0, -1)]
    [InlineData("abc", 3, 1)]
    [InlineData("good", 3, 5)]
    [InlineData("qq", 0, 100)]
    public void Substring_GettingSubstringWithInvalidLength_ShouldFail(string @string, int startIndex, int length)
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>("length", () => @string.Substring(startIndex, length));

      // Assert

    }

  }
}
