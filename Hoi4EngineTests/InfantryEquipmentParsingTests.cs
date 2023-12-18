using FluentAssertions;
using Hoi4Extract;

namespace Hoi4EngineTests
{
    public class InfantryEquipmentParsingTests
    {
        [Fact]
        public void ParsingInfantryEquipmentWorks()
        {
            using var file = new FileStream(
                Path.Join(Environment.GetEnvironmentVariable("ProgramFiles(x86)"),
                    @"Steam\steamapps\common\Hearts of Iron IV",
                    @"common\units\equipment\infantry.txt"), FileMode.Open);

            var equipment = Equipment.Parse(file);
            equipment.Normalize();
            equipment.InfantryEquipment.Should().HaveCount(5);

            var archetype = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment");
            archetype.IsArchetype.Should().Be(true);
            archetype.Picture.Should().Be("archetype_infantry_equipment");
            archetype.Type.Should().Be("infantry");
            archetype.GroupBy.Should().Be("archetype");
            archetype.InterfaceCategory.Should().Be("interface_category_land");
            archetype.Active.Should().Be(true);
            archetype.Reliability.Should().Be(0.9m);
            archetype.MaximumSpeed.Should().Be(4);
            archetype.Defense.Should().Be(20);
            archetype.Breakthrough.Should().Be(2);
            archetype.Hardness.Should().Be(0);
            archetype.ArmorValue.Should().Be(0);
            archetype.SoftAttack.Should().Be(3);
            archetype.HardAttack.Should().Be(0.5m);
            archetype.Piercing.Should().Be(1);
            archetype.AirAttack.Should().Be(0);
            archetype.LendLeaseCost.Should().Be(1);
            archetype.BuildCostIC.Should().Be(0.43m);
            archetype.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                { "steel", 2 }
            });

            // Basic Infantry Equipment

            var basic = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_0");
            basic.Defense.Should().Be(20); // copied from archetype
            basic.ArmorValue.Should().Be(0); // copied from archetype
            basic.Year.Should().Be(1918);

            // Infantry Equipment I

            var infantryEquipI = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_1");
            infantryEquipI.Priority.Should().Be(10);
            infantryEquipI.VisualLevel.Should().Be(1);
            infantryEquipI.Defense.Should().Be(22);
            infantryEquipI.Breakthrough.Should().Be(3);
            infantryEquipI.SoftAttack.Should().Be(6);
            infantryEquipI.HardAttack.Should().Be(1);
            infantryEquipI.Piercing.Should().Be(4);
            infantryEquipI.AirAttack.Should().Be(0);
            infantryEquipI.ArmorValue.Should().Be(0); // copied from archetype
            infantryEquipI.Year.Should().Be(1936);
            infantryEquipI.BuildCostIC.Should().Be(0.5m);
        }
    }
}
