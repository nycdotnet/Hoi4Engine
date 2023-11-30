namespace Hoi4Engine
{
    public class CavalryBatallion : Batallion
    {
        public CavalryBatallion()
        {
            MaxSpeed = 6.4f;
            HP = 25;
            Organization = 70;
            RecoveryRate = 0.3f;
            Reconnaisance = 0;
            Suppression = 2.0f;
            Weight = 0.5f;
            SupplyUse = 0.06f;
            AverageReliability = 0.9f;
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
    }
}
