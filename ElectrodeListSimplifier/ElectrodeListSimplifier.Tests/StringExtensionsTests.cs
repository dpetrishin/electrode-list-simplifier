using ElectrodeListSimplifier.Library.Extensions;
using ElectrodeListSimplifier.Library.Exceptions;
using System;
using Xunit;

namespace ElectrodeListSimplifier.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("E1", "E", 1)]
        [InlineData("E01", "E", 1)]
        [InlineData("E001", "E", 1)]
        [InlineData("E01 ", "E", 1)]
        [InlineData(" E01", "E", 1)]
        [InlineData(" E0123", "E", 123)]
        [InlineData("E01000", "E", 1000)]
        public void StringSplitSuccessfully(string input, string expectedName, int expectedNumber)
        {
            var actual = input.SplitNameAndNumber();
            Assert.Equal(expectedName, actual.Item1);
            Assert.Equal(expectedNumber, actual.Item2);
        }


        [Theory]
        [InlineData("1E1")]
        [InlineData("E")]
        [InlineData("E1E")]
        [InlineData("E11E1E")]
        public void StringSplitThrowsFormatException(string input)
        {
            var exception = Assert.Throws<ElectrodeNameFormatException>(() => { var actual = input.SplitNameAndNumber(); });
            Assert.Contains(input, exception.UserMessage);
        }

        [Theory]
        [InlineData(null)]
        public void StringSplitThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => { var actual = input.SplitNameAndNumber(); });
        }
    }
}
