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
        [InlineData("IC12", "IC", 12)]
        public void ToElectrodeSuccessfully(string input, string expectedName, int expectedNumber)
        {
            var actual = input.ToElectode();
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedNumber, actual.Number);
        }


        [Theory]
        [InlineData("1E1")]
        [InlineData("E")]
        [InlineData("E1E")]
        [InlineData("E11E1E")]
        public void ToElectrodeThrowsFormatException(string input)
        {
            var exception = Assert.Throws<ElectrodeNameFormatException>(() => { var actual = input.ToElectode(); });
            Assert.Contains(input, exception.UserMessage);
        }

        [Theory]
        [InlineData(null)]
        public void StringSplitThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => { var actual = input.ToElectode(); });
        }
    }
}
