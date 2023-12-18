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

            {
                // Basic Infantry Equipment
                var basic = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_0");
                basic.Defense.Should().Be(20); // copied from archetype
                basic.ArmorValue.Should().Be(0); // copied from archetype
                basic.Year.Should().Be(1918);
            }

            {
                // Infantry Equipment I
                var infantryEquipI = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_1");
                infantryEquipI.Year.Should().Be(1936);
                infantryEquipI.Priority.Should().Be(10);
                infantryEquipI.VisualLevel.Should().Be(1);
                infantryEquipI.Defense.Should().Be(22);
                infantryEquipI.Breakthrough.Should().Be(3);
                infantryEquipI.SoftAttack.Should().Be(6);
                infantryEquipI.HardAttack.Should().Be(1);
                infantryEquipI.Piercing.Should().Be(4);
                infantryEquipI.AirAttack.Should().Be(0);
                infantryEquipI.ArmorValue.Should().Be(0); // copied from archetype
                infantryEquipI.BuildCostIC.Should().Be(0.5m);
                infantryEquipI.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "steel", 2 }
                });
            }

            {
                // Infantry Equipment II
                var infantryEquipII = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_2");
                infantryEquipII.Year.Should().Be(1939);
                infantryEquipII.Priority.Should().Be(10);
                infantryEquipII.VisualLevel.Should().Be(2);
                infantryEquipII.Defense.Should().Be(28);
                infantryEquipII.Breakthrough.Should().Be(4);
                infantryEquipII.SoftAttack.Should().Be(9);
                infantryEquipII.HardAttack.Should().Be(1.5m);
                infantryEquipII.Piercing.Should().Be(5);
                infantryEquipII.AirAttack.Should().Be(0);
                infantryEquipII.ArmorValue.Should().Be(0); // copied from archetype
                infantryEquipII.BuildCostIC.Should().Be(0.58m);
                infantryEquipII.Reliability.Should().Be(0.9m);
                infantryEquipII.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "steel", 3 }
                });
            }

            {
                // Infantry Equipment III
                var infantryEquipIII = equipment.InfantryEquipment.Single(eq => eq.Name == "infantry_equipment_3");
                infantryEquipIII.Year.Should().Be(1942);
                infantryEquipIII.Priority.Should().Be(10);
                infantryEquipIII.VisualLevel.Should().Be(3);
                infantryEquipIII.Defense.Should().Be(34);
                infantryEquipIII.Breakthrough.Should().Be(5);
                infantryEquipIII.SoftAttack.Should().Be(12);
                infantryEquipIII.HardAttack.Should().Be(2);
                infantryEquipIII.Piercing.Should().Be(10);
                infantryEquipIII.AirAttack.Should().Be(0);
                infantryEquipIII.ArmorValue.Should().Be(0); // copied from archetype
                infantryEquipIII.BuildCostIC.Should().Be(0.69m);
                infantryEquipIII.Reliability.Should().Be(0.8m);
                infantryEquipIII.Resources.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "steel", 4 }
                });
            }
        }
    }
}
