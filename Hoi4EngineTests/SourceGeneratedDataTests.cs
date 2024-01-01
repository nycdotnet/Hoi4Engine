using FluentAssertions;
using Hoi4Data.common.units;

namespace Hoi4EngineTests
{
    public class SourceGeneratedDataTests
    {
        [Fact]
        public void SourceGeneratedCavalrySubunitsAreAsExpected()
        {
            var cavalryType = new Cavalry();
            cavalryType.Subunits.Should().HaveCount(2);
            var cav = cavalryType.Subunits.Single(su => su.Name == "cavalry");

            cav.Abbreviation.Should().Be("CAV");
            cav.MaxOrganization.Should().Be(70);

            cavalryType.Subunits.Single(su => su.Name == "camelry").Abbreviation.Should().Be("CAM");
        }
    }
}
