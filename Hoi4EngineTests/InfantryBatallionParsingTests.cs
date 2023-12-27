using FluentAssertions;
using Hoi4Extract;

namespace Hoi4EngineTests
{
    public class InfantryBatallionParsingTests
    {
        [Fact]
        public void ParsingInfantryBatallionsWorks()
        {
            var parsingContext = new Hoi4ParsingContext();
            var batallions = parsingContext.GetInfantryBatallions();
            batallions.Should().HaveCount(12);

            {
                var ib = batallions.Single(b => b.Name == "infantry");
                ib.Abbreviation.Should().Be("INF");
                ib.Sprite.Should().Be("infantry");
                ib.MapIconCategory.Should().Be("infantry");
                ib.Priority.Should().Be(600);
                ib.AIPriority.Should().Be(200);
                ib.Active.Should().BeFalse(); // no idea what this is.
                ib.Type.Should().BeEquivalentTo(["infantry"]);
                ib.Group.Should().Be("infantry");
                ib.Categories.Should().BeEquivalentTo([
                    "category_front_line",
                    "category_light_infantry",
                    "category_all_infantry",
                    "category_army"
                ]);
                ib.CombatWidth.Should().Be(2);
                ib.MaxStrength.Should().Be(25);
                ib.MaxOrganization.Should().Be(60);
                ib.RecoveryRate.Should().Be(0.3m);
                ib.Manpower.Should().Be(1000);
                ib.TrainingTime.Should().Be(90);
                ib.Suppression.Should().Be(1.5m);
                ib.Weight.Should().Be(0.5m);
                ib.SupplyConsumption.Should().Be(0.06m);
                ib.EquipmentNeed.Should().BeEquivalentTo(new Dictionary<string, int> {
                    { "infantry_equipment", 100 }
                });
            }
        }
    }
}
