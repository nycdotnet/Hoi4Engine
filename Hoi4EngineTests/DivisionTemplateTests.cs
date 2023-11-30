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
            template.RecoveryRate.Should().Be(0.3m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5m);
            template.Weight.Should().Be(0.5m);
            template.SupplyUse.Should().Be(0.06m);
            template.AverageReliability.Should().Be(0.9m);
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
            template.RecoveryRate.Should().Be(0.3m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(3);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.12m);
            template.AverageReliability.Should().Be(0.9m);
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
            template.RecoveryRate.Should().Be(0.3m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(3.5m);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.12m);
            template.AverageReliability.Should().Be(0.9m);
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

        [Fact]
        public void OneInfantryOneArtilleryHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade2(new ArtilleryBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(25.6m);
            template.Organization.Should().Be(30);
            template.RecoveryRate.Should().Be(0.2m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5m);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.27m);
            template.AverageReliability.Should().Be(0.85m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(31);
            template.HardAttack.Should().Be(3);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(32);
            template.Breakthrough.Should().Be(9);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4.7m);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(1500);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(100);
            template.Artillery.Should().Be(36);
            template.ProductionCost.Should().Be(176);
            template.CombatWidth.Should().Be(5);
        }

        [Fact]
        public void ClassicSevenTwoHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(176.2m);
            template.Organization.Should().Be(46.6m);
            template.RecoveryRate.Should().Be(0.25m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(10.5m);
            template.Weight.Should().Be(4.5m);
            template.SupplyUse.Should().Be(0.84m);
            template.AverageReliability.Should().Be(0.877m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(92);
            template.HardAttack.Should().Be(11);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(174);
            template.Breakthrough.Should().Be(33);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4.5m);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(8000);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(700);
            template.Artillery.Should().Be(72);
            template.ProductionCost.Should().Be(602);
            template.CombatWidth.Should().Be(20);
        }

        [Fact]
        public void ClassicFourteenFourHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade2(new InfantryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());
            template.AddToBrigade3(new ArtilleryBatallion());
            template.AddToBrigade4(new InfantryBatallion());
            template.AddToBrigade4(new InfantryBatallion());
            template.AddToBrigade4(new InfantryBatallion());
            template.AddToBrigade4(new InfantryBatallion());
            template.AddToBrigade5(new InfantryBatallion());
            template.AddToBrigade5(new InfantryBatallion());
            
            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(352.4m);
            template.Organization.Should().Be(46.6m);
            template.RecoveryRate.Should().Be(0.25m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(21);
            template.Weight.Should().Be(9);
            template.SupplyUse.Should().Be(1.68m);
            template.AverageReliability.Should().Be(0.877m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(184);
            template.HardAttack.Should().Be(22);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(348);
            template.Breakthrough.Should().Be(66);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4.5m);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(16000);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(1400);
            template.Artillery.Should().Be(144);
            template.ProductionCost.Should().Be(1204);
            template.CombatWidth.Should().Be(40);
        }
    }
}