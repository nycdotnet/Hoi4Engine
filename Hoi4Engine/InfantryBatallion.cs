﻿namespace Hoi4Engine
{
    public class InfantryBatallion : Batallion
    {
        public InfantryBatallion()
        {
            MaxSpeed = 4;
            HP = 25;
            Organization = 60;
            RecoveryRate = 0.3m;
            Reconnaisance = 0;
            Suppression = 1.5m;
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
            TrainingTime = 90;
            FuelCapacity = 0;
            FuelUsage = 0;
            InfantryEquipment = 100;
            ProductionCost = 50;
            Kind = BatallionKind.Infantry;
            IsLegInfantry = true;
        }
    }
}
