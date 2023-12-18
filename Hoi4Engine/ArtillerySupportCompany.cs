namespace Hoi4Engine
{
    public class ArtillerySupportCompany : SupportCompany
    {
        public ArtillerySupportCompany()
        {
            HP = 0.2m;
            Organization = 0;
            Weight = 0.1m;
            SupplyUse = 0.16m;
            AverageReliability = 0.80m;
            SoftAttack = 15m;
            HardAttack = 1.2m;
            Piercing = 5m;
            Defense = 6m;
            Breakthrough = 3.6m;
            Manpower = 300;
            TrainingTime = 120;
            // from C:\Program Files (x86)\Steam\steamapps\common\Hearts of Iron IV\common\units\artillery.txt
            //need = {
            //    artillery_equipment = 12
            //}
            Artillery = 12;
            SupportEquipment = 30;
            ProductionCost = 42;
            RecoveryRate = 0.1m;
        }
    }
}
