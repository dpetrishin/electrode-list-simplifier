using ElectrodeListSimplifier.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ElectrodeListSimplifier.Tests
{
    public class ListStringExtensionsTests
    {
        [Theory]
        [InlineData("E1...E3, E5" ,"E1", "E2", "E3", "E5")]
        [InlineData("E1, E3", "E1", "E3")]
        public void Test1(string expected, params string[] input)
        {
            var listInput = input.ToList();
            var actual = listInput.ToSimplifiedString();

            Assert.Equal(expected, actual);
        }
    }
}
