using Hoi4Extract;

namespace Hoi4Engine
{
    public class CavalryBatallion : Batallion
    {
        public CavalryBatallion()
        {
            MaxSpeed = 6.4m;
            HP = 25;
            Organization = 70;
            RecoveryRate = 0.3m;
            Reconnaisance = 0;
            Suppression = 2.0m;
            Weight = 0.5m;
            SupplyUse = 0.06m;
            AverageReliability = 0.9m;
            ReliabilityBonus = 0;
            TricklebackAndWarSupportProtection = 0;
            ExperienceLoss = 0;
            SoftAttack = 6;
            HardAttack = 1;
            AirAttack = 0;
            Defense = 22;
            Breakthrough = 3;
            Armor = 0;
            Piercing = 4;
            Initiative = 0;
            Entrenchment = 0;
            EquipmentCaptureRatio = 0;
            CombatWidth = 2;
            Manpower = 1000;
            TrainingTime = 120;
            FuelCapacity = 0;
            FuelUsage = 0;
            InfantryEquipment = 120;
            ProductionCost = 60;
            Kind = BatallionKind.Mobile;
        }

        public override void AddEquipment(Hoi4Parser equipment, Technology technology)
        {
            throw new NotImplementedException();
        }
    }
}
