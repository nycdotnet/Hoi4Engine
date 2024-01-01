using FluentAssertions;
using Hoi4Data.common.units.equipment;

namespace Hoi4EngineTests
{
    public class ArtilleryParsingTests
    {
        [Fact]
        public void ParsingArtilleryWorks()
        {
            var artilleryEquipment = new ArtilleryEquipment();

            artilleryEquipment.Should().HaveCount(9);

            {
                var archetype = artilleryEquipment.Single(eq => eq.Name == "artillery_equipment");
                archetype.IsArchetype.Should().BeTrue();
                archetype.Picture.Should().Be("archetype_artillery_equipment");
                archetype.Type.Should().BeEquivalentTo(["artillery", "infantry"]);
                archetype.GroupBy.Should().Be("archetype");
                archetype.InterfaceCategory.Should().Be("interface_category_land");
                archetype.Reliability.Should().Be(0.8m);
                archetype.Defense.Should().Be(10);
                archetype.Breakthrough.Should().Be(6);
                archetype.Hardness.Should().Be(0);
                archetype.ArmorValue.Should().Be(0);
                archetype.SoftAttack.Should().Be(25);
                archetype.HardAttack.Should().Be(2);
                archetype.Piercing.Should().Be(5);
                archetype.AirAttack.Should().Be(0);
                archetype.LendLeaseCost.Should().Be(4);
                archetype.BuildCostIC.Should().Be(3.5m);
                archetype.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "steel", 2 },
                    { "tungsten", 1 }
                });
            }

            {
                var aeII = artilleryEquipment.Single(eq => eq.Name == "artillery_equipment_2");
                aeII.IsArchetype.Should().BeFalse();
                aeII.Defense.Should().Be(15);
                aeII.Breakthrough.Should().Be(7);
                aeII.SoftAttack.Should().Be(30);
            }

            {
                var aeIII = artilleryEquipment.Single(eq => eq.Name == "artillery_equipment_3");
                aeIII.IsArchetype.Should().BeFalse();
                aeIII.Defense.Should().Be(18);
                aeIII.Breakthrough.Should().Be(8);
                aeIII.SoftAttack.Should().Be(34);
            }

            {
                var rocketI = artilleryEquipment.Single(eq => eq.Name == "rocket_artillery_equipment_1");
                rocketI.IsArchetype.Should().BeFalse();
                rocketI.Defense.Should().Be(12);
                rocketI.Breakthrough.Should().Be(9);
                rocketI.SoftAttack.Should().Be(30);
            }
        }
    }
}
