using Hoi4Extract;

namespace Hoi4Engine
{
    public class ArtilleryBatallion : Batallion
    {
        // SEEMS TO BE IN C:\Program Files (x86)\Steam\steamapps\common\Hearts of Iron IV\common\units\equipment\artillery.txt
        public ArtilleryBatallion()
        {
            MaxSpeed = 4;
            HP = 0.6m;
            Organization = 0;
            RecoveryRate = 0.1m;
            Reconnaisance = 0;
            Suppression = 0;
            Weight = 0.5m;
            SupplyUse = 0.21m;
            AverageReliability = 0.8m;
            ReliabilityBonus = 0;
            TricklebackAndWarSupportProtection = 0;
            ExperienceLoss = 0;
            SoftAttack = 25;
            HardAttack = 2;
            AirAttack = 0;
            Defense = 10;
            Breakthrough = 6;
            Armor = 0;
            Piercing = 5;
            Initiative = 0;
            Entrenchment = 0;
            EquipmentCaptureRatio = 0;
            CombatWidth = 3;
            Manpower = 500;
            TrainingTime = 120;
            FuelCapacity = 0;
            FuelUsage = 0;
            Artillery = 36;
            ProductionCost = 126; // this is `build_cost_ic` * 
            Kind = BatallionKind.CombatSupport;
        }

        public override void AddEquipment(Hoi4Parser equipment, Technology technology)
        {
            throw new NotImplementedException();
        }
    }
}
