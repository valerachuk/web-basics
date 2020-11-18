using System;
using Xunit;

namespace StringUnitTests
{
  public class SplitTest
  {

    [Theory]
    [InlineData("aaa, bbb, ccc,    eeee,    eeeee", new[] { ',' }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries,
      new[] { "aaa", " bbb", " ccc", "    eeee", "    eeeee" })]
    [InlineData("aaa, bbb, ccc,    eeee,    eeeee", new[] { ',', ' ' }, int.MaxValue,
      StringSplitOptions.RemoveEmptyEntries, new[] { "aaa", "bbb", "ccc", "eeee", "eeeee" })]
    [InlineData("aaa, bbb, ccc,    eeee,    eeeee", new[] { ',', ' ' }, 3, StringSplitOptions.None,
      new[] { "aaa", "", "bbb, ccc,    eeee,    eeeee" })]
    [InlineData("aaa, bbb, ccc,    eeee,    eeeee", new[] { ',', ' ' }, 0, StringSplitOptions.None, new string[] { })]
    [InlineData("", new[] { ',', ' ' }, int.MaxValue, StringSplitOptions.None, new[] { "" })]
    [InlineData("", new[] { ',', ' ' }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries, new string[] { })]
    [InlineData("", new char[] { }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries, new string[] { })]
    [InlineData("hello,   world", (char[])null, int.MaxValue, StringSplitOptions.RemoveEmptyEntries, new[] { "hello,", "world" })]
    [InlineData("hello,  world", (char[])null, int.MaxValue, StringSplitOptions.None, new[] { "hello,", "", "world" })]
    public void SplitChar_SplittingString_ShouldSplitString(string @string, char[] separator, int count,
      StringSplitOptions options, string[] expectedResult)
    {
      // Arrange

      // Act
      var actualResult = @string.Split(separator, count, options);

      // Assert
      Assert.Equal(expectedResult, actualResult);

    }

    [Fact]
    public void SplitChar_SplittingStringWithNegativeArraySize_ShouldFail()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>("count", () => "".Split(new[] { ',' }, -1));

      // Assert

    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(-13)]
    [InlineData(100)]
    public void SplitChar_SplittingStringWithInvalidEnum_ShouldFail(int enumValue)
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentException>(() => "".Split(new[] { ',' }, int.MaxValue, (StringSplitOptions)enumValue));

      // Assert

    }

    [Theory]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--" }, int.MaxValue, StringSplitOptions.None,
      new[] { "aaa", "bbb", "ccc-%%kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%%" }, int.MaxValue, StringSplitOptions.None,
      new[] { "aaa", "bbb", "ccc-", "kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%" }, int.MaxValue, StringSplitOptions.None,
      new[] { "aaa", "bbb", "ccc-", "", "kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%" }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries,
      new[] { "aaa", "bbb", "ccc-", "kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "-", "%" }, int.MaxValue, StringSplitOptions.RemoveEmptyEntries,
      new[] { "aaa", "bbb", "ccc", "kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--" }, 2, StringSplitOptions.None,
      new[] { "aaa", "bbb--ccc-%%kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%%" }, 3, StringSplitOptions.None,
      new[] { "aaa", "bbb", "ccc-%%kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%" }, 2, StringSplitOptions.None,
      new[] { "aaa", "bbb--ccc-%%kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "--", "%" }, 3, StringSplitOptions.RemoveEmptyEntries,
      new[] { "aaa", "bbb", "ccc-%%kk" })]
    [InlineData("aaa--bbb--ccc-%%kk", new[] { "-", "%" }, 2, StringSplitOptions.RemoveEmptyEntries,
      new[] { "aaa", "bbb--ccc-%%kk" })]
    [InlineData("hello, world   ", (string[])null, int.MaxValue, StringSplitOptions.RemoveEmptyEntries, new[] { "hello,", "world" })]
    [InlineData("hello,  world", (string[])null, int.MaxValue, StringSplitOptions.None, new[] { "hello,", "", "world" })]
    public void SplitString_SplittingString_ShouldSplitString(string @string, string[] separator, int count,
      StringSplitOptions options, string[] expectedResult)
    {
      // Arrange

      // Act
      var actualResult = @string.Split(separator, count, options);

      // Assert
      Assert.Equal(expectedResult, actualResult);

    }

    [Fact]
    public void SplitString_SplittingStringWithNegativeArraySize_ShouldFail()
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentOutOfRangeException>("count", () => "".Split(new[] { "," }, -12, StringSplitOptions.RemoveEmptyEntries));

      // Assert

    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(-13)]
    [InlineData(100)]
    public void SplitString_SplittingStringWithInvalidEnum_ShouldFail(int enumValue)
    {
      // Arrange

      // Act
      Assert.Throws<ArgumentException>(() => "".Split(new[] { "," }, int.MaxValue, (StringSplitOptions)enumValue));

      // Assert

    }

  }
}
