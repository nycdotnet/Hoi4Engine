using FluentAssertions;
using Hoi4Engine;

namespace Hoi4EngineTests
{
    public class DivisionTemplateTests
    {
        [Fact]
        public void SingleInfantryBatallionHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(25);
            template.Organization.Should().Be(60);
            template.RecoveryRate.Should().Be(0.3f);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5f);
            template.Weight.Should().Be(0.5f);
            template.SupplyUse.Should().Be(0.06f);
            template.AverageReliability.Should().Be(0.9f);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(6);
            template.HardAttack.Should().Be(1);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(22);
            template.Breakthrough.Should().Be(3);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);
            template.Manpower.Should().Be(1000);
            template.TrainingTime.Should().Be(90);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(100);
            template.ProductionCost.Should().Be(50);
            template.CombatWidth.Should().Be(2);
        }

        [Fact]
        public void TwoInfantryBatallionHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(50);
            template.Organization.Should().Be(60);
            template.RecoveryRate.Should().Be(0.3f);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(3);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.12f);
            template.AverageReliability.Should().Be(0.9f);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(12);
            template.HardAttack.Should().Be(2);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(44);
            template.Breakthrough.Should().Be(6);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(2000);
            template.TrainingTime.Should().Be(90);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(200);
            template.ProductionCost.Should().Be(100);
            template.CombatWidth.Should().Be(4);
        }

        [Fact]
        public void UnableToPutMobileBatallionWithInfantryBatallion()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            var act = () => template.AddToBrigade1(new CavalryBatallion());
            act.Should().Throw<InvalidOperationException>().WithMessage("This brigade only accepts Infantry batallions.");
        }

        [Fact]
        public void UnableToOverfillABrigade()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            var act = () => template.AddToBrigade1(new InfantryBatallion());
            act.Should().Throw<InvalidOperationException>().WithMessage("This brigade is already full.");
        }

        [Fact]
        public void OneInfantryBatallionOneCavalryHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade2(new CavalryBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(50);
            template.Organization.Should().Be(65);
            template.RecoveryRate.Should().Be(0.3f);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(3.5f);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.12f);
            template.AverageReliability.Should().Be(0.9f);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(12);
            template.HardAttack.Should().Be(2);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(44);
            template.Breakthrough.Should().Be(6);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(2000);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(220);
            template.ProductionCost.Should().Be(110);
            template.CombatWidth.Should().Be(4);
        }
    }
}