using ElectrodeListSimplifier.Library.Extensions;
using System.Linq;
using Xunit;

namespace ElectrodeListSimplifier.Tests
{
    public class ElectrodeListExtensionsTests
    {
        [Theory]
        [InlineData("E1...E3, E5" ,"E1", "E2", "E3", "E5")]
        [InlineData("E1, E3", "E1", "E3")]
        [InlineData("E1...E4, E6, E7, E9, ICE1...ICE3", "E1", "E4", "E2", "E6", "E7", "E9", "ICE03", "ICE002", "ICE1", "E3")]
        public void ElectrodeListSimplifiedSuccessfully(string expected, params string[] input)
        {
            var actual = input.ToElectrodeList().ToSimplifiedString();

            Assert.Equal(expected, actual);
        }
    }
}
