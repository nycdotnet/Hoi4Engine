using FluentAssertions;
using Hoi4Extract;

namespace Hoi4EngineTests
{
    public class ArtilleryParsingTests
    {
        [Fact]
        public void ParsingArtilleryWorks()
        {
            using var file = new FileStream(
                Path.Join(Environment.GetEnvironmentVariable("ProgramFiles(x86)"),
                    @"Steam\steamapps\common\Hearts of Iron IV",
                    @"common\units\equipment\artillery.txt"), FileMode.Open);       

            var equipment = KnownEquipment.Parse(file);
            equipment.Normalize();
            equipment.InfantryEquipment.Should().BeEmpty();
            equipment.ArtilleryEquipment.Should().HaveCount(9);

            { 
                var artiArchetype = equipment.ArtilleryEquipment.Single(eq => eq.Name == "artillery_equipment");
                artiArchetype.IsArchetype.Should().Be(true);
                artiArchetype.Picture.Should().Be("archetype_artillery_equipment");
                artiArchetype.Type.Should().BeEquivalentTo(["artillery", "infantry"]);
                artiArchetype.GroupBy.Should().Be("archetype");
                artiArchetype.InterfaceCategory.Should().Be("interface_category_land");
                artiArchetype.Reliability.Should().Be(0.8m);
                artiArchetype.Defense.Should().Be(10);
                artiArchetype.Breakthrough.Should().Be(6);
                artiArchetype.Hardness.Should().Be(0);
                artiArchetype.ArmorValue.Should().Be(0);
                artiArchetype.SoftAttack.Should().Be(25);
                artiArchetype.HardAttack.Should().Be(2);
                artiArchetype.Piercing.Should().Be(5);
                artiArchetype.AirAttack.Should().Be(0);
                artiArchetype.LendLeaseCost.Should().Be(4);
                artiArchetype.BuildCostIC.Should().Be(3.5m);
                artiArchetype.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "steel", 2 },
                    { "tungsten", 1 }
                });
            }
        }
    }
}
