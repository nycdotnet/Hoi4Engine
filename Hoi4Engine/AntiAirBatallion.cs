namespace Hoi4Engine
{
    public class AntiAirBatallion : Batallion
    {
        public AntiAirBatallion()
        {
            MaxSpeed = 4;
            HP = 0.6m;
            Organization = 0;
            RecoveryRate = 0.1m;
            Reconnaisance = 0;
            Suppression = 0;
            Weight = 0.5m;
            SupplyUse = 0.1m;
            AverageReliability = 0.8m;
            ReliabilityBonus = 0;
            TricklebackAndWarSupportProtection = 0;
            ExperienceLoss = 0;
            SoftAttack = 3;
            HardAttack = 7;
            AirAttack = 19;
            Defense = 4;
            Breakthrough = 1;
            Armor = 0;
            Piercing = 25;
            Initiative = 0;
            Entrenchment = 0;
            EquipmentCaptureRatio = 0;
            CombatWidth = 1;
            Manpower = 500;
            TrainingTime = 120;
            FuelCapacity = 0;
            FuelUsage = 0;
            AntiAir = 30;
            ProductionCost = 120;
            Kind = BatallionKind.CombatSupport;
        }
    }
}
