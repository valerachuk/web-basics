using System;
using Xunit;

namespace StringUnitTests
{
  public class ReplaceTest
  {
    [Theory]
    [InlineData("abaca", 'a', 'b', "bbbcb")]
    [InlineData("", 'a', 'b', "")]
    [InlineData("qwerty", 'a', 'b', "qwerty")]
    [InlineData("a", 'a', 'b', "b")]
    [InlineData("b", 'a', 'b', "b")]
    public void ReplaceChar_ReplacingCharactersInString_ShouldReplaceCharactersInString(string initialString, char oldChar, char newValue, string expectedReplacedString)
    {
      // Arrange

      // Act
      var actualReplacedString = initialString.Replace(oldChar, newValue);

      // Assert
      Assert.Equal(expectedReplacedString, actualReplacedString);
    }

    [Theory]
    [InlineData("abaca", "a", "b", "bbbcb")]
    [InlineData("abaca", "a", "", "bc")]
    [InlineData("abaca", "a", null, "bc")]
    [InlineData("hello, ll, ello", "ll", "1", "he1o, 1, e1o")]
    [InlineData("aaaabcaaazxyaaa", "aa", "@", "@@bc@azxy@a")]
    [InlineData("aaaabcaaazxyaaa", "aa", null, "bcazxya")]
    public void ReplaceString_ReplacingInString_ShouldReplaceInString(string initialString, string oldValue, string newValue, string expectedReplacedString)
    {
      // Arrange

      // Act
      var actualReplacedString = initialString.Replace(oldValue, newValue);

      // Assert
      Assert.Equal(expectedReplacedString, actualReplacedString);
    }

    [Fact]
    public void ReplaceString_ReplacingStringWithNullOldValue_ShouldFail()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentNullException>("oldValue", () => "123".Replace(null!, "5"));

      // Assert

    }

    [Fact]
    public void ReplaceString_ReplacingStringWithEmptyOldValue_ShouldFail()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentException>("oldValue", () => "123".Replace("", "5"));

      // Assert

    }

  }
}
