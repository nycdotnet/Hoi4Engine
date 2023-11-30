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
            template.Initiative.Should().Be(0);
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
            template.Initiative.Should().Be(0);
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
            template.Initiative.Should().Be(0);
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
        public void OneInfantryBatallionOneAAHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddToBrigade2(new AntiAirBatallion());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(25.6m);
            template.Organization.Should().Be(30);
            template.RecoveryRate.Should().Be(0.2m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5m);
            template.Weight.Should().Be(1);
            template.SupplyUse.Should().Be(0.16m);
            template.AverageReliability.Should().Be(0.85m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(9);
            template.HardAttack.Should().Be(8);
            template.AirAttack.Should().Be(19);
            template.Defense.Should().Be(26);
            template.Breakthrough.Should().Be(4);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(18.7m);
            template.Initiative.Should().Be(0);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(1500);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(100);
            template.AntiAir.Should().Be(30);
            template.ProductionCost.Should().Be(170);
            template.CombatWidth.Should().Be(3);
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
            template.Initiative.Should().Be(0);
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
        public void OneInfantryOneArtillerySupportCompanyHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddSupportCompany(new ArtillerySupportCompany());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(25.2m);
            template.Organization.Should().Be(30);
            template.RecoveryRate.Should().Be(0.2m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5m);
            template.Weight.Should().Be(0.6m);
            template.SupplyUse.Should().Be(0.22m);
            template.AverageReliability.Should().Be(0.85m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(21);
            template.HardAttack.Should().Be(2.2m);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(28);
            template.Breakthrough.Should().Be(6.6m);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4.7m);
            template.Initiative.Should().Be(0);
            template.Entrenchment.Should().Be(0);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(1300);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(100);
            template.Artillery.Should().Be(12);
            template.ProductionCost.Should().Be(92);
            template.CombatWidth.Should().Be(2);
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
            template.Initiative.Should().Be(0);
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
        public void CanNotAddDuplicateSupportCompanies()
        {
            var template = new DivisionTemplate();
            template.AddSupportCompany(new EngineerSupportCompany());
            var act = () => template.AddSupportCompany(new EngineerSupportCompany());
            act.Should().Throw<InvalidOperationException>().WithMessage("This division already has a(n) EngineerSupportCompany.");
        }

        [Fact]
        public void ClassicSevenTwoWithEngineerHasExpectedStats()
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
            template.AddSupportCompany(new EngineerSupportCompany());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(178.2m);
            template.Organization.Should().Be(44);
            template.RecoveryRate.Should().Be(0.26m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(10.5m);
            template.Weight.Should().Be(4.6m);
            template.SupplyUse.Should().Be(0.86m);
            template.AverageReliability.Should().Be(0.875m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(95);
            template.HardAttack.Should().Be(12);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(198.2m);
            template.Breakthrough.Should().Be(37.5m);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4.5m);
            template.Initiative.Should().Be(0);
            template.Entrenchment.Should().Be(3.4m);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(8300);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(710);
            template.Artillery.Should().Be(72);
            template.SupportEquipment.Should().Be(30);
            template.ProductionCost.Should().Be(727);
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
            template.Initiative.Should().Be(0);
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

        [Fact]
        public void OneInfantryBatallionWithEngineerHasExpectedStats()
        {
            var template = new DivisionTemplate();
            template.AddToBrigade1(new InfantryBatallion());
            template.AddSupportCompany(new EngineerSupportCompany());

            template.MaxSpeed.Should().Be(4);
            template.HP.Should().Be(27.0m);
            template.Organization.Should().Be(40);
            template.RecoveryRate.Should().Be(0.3m);
            template.Reconnaisance.Should().Be(0);
            template.Suppression.Should().Be(1.5m);
            template.Weight.Should().Be(0.6m);
            template.SupplyUse.Should().Be(0.08m);
            template.AverageReliability.Should().Be(0.875m);
            template.ReliabilityBonus.Should().Be(0);
            template.TricklebackAndWarSupportProtection.Should().Be(0);
            template.ExperienceLoss.Should().Be(0);

            template.SoftAttack.Should().Be(9);
            template.HardAttack.Should().Be(2);
            template.AirAttack.Should().Be(0);
            template.Defense.Should().Be(46.2m);
            template.Breakthrough.Should().Be(7.5m);
            template.Armor.Should().Be(0);
            template.Piercing.Should().Be(4);
            template.Initiative.Should().Be(0);
            template.Entrenchment.Should().Be(2.2m);
            template.EquipmentCaptureRatio.Should().Be(0);

            template.Manpower.Should().Be(1300);
            template.TrainingTime.Should().Be(120);
            template.FuelUsage.Should().Be(0);
            template.FuelCapacity.Should().Be(0);
            template.InfantryEquipment.Should().Be(110);
            template.SupportEquipment.Should().Be(30);
            template.ProductionCost.Should().Be(175);
            template.CombatWidth.Should().Be(2);
        }

    }
}