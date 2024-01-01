using FluentAssertions;
using Hoi4Data.common.units;
using Hoi4Data.common.units.equipment;

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

        [Fact]
        public void SourceGeneratedInfantryEquipmentIsAsExpected()
        {
            var infEquip = new InfantryEquipment();
            infEquip.Equipment.Should().HaveCount(5);
            var basic = infEquip.Equipment.Single(e => e.Name == "infantry_equipment_0");
            basic.SoftAttack.Should().Be(3);
        }
    }
}
