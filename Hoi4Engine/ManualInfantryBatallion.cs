//using Hoi4Extract;

//namespace Hoi4Engine
//{

//    // NOTE: A lot of this should be based on
//    //C:\Program Files (x86)\Steam\steamapps\common\Hearts of Iron IV\common\units\infantry.txt
//    public class ManualInfantryBatallion : Batallion
//    {
//        public string InfantryEquipmentAmount { get; set; }
//        public ManualInfantryBatallion()
//        {
//            //InfantryEquipmentAmount = 100;
//            HP = 25;
//            Organization = 60;
//            RecoveryRate = 0.3m;
//            Reconnaisance = 0;
//        }

//        public override void AddEquipment(Hoi4Parser equipment, Technology technology)
//        {
//            var infEq = equipment.InfantryEquipment.Where(ie => ie.Name == technology.InfantryEquipment).SingleOrDefault() ??
//                throw new KeyNotFoundException($"Unable to find infantry equipment with name \"{technology.InfantryEquipment}\"");
//            MaxSpeed = infEq.MaximumSpeed ?? 0;
            
//            //Suppression = 1.5m;
//            //Weight = 0.5m;
//            //SupplyUse = 0.06m;
//            //AverageReliability = 0.9m;
//            //ReliabilityBonus = 0;
//            //TricklebackAndWarSupportProtection = 0;
//            //ExperienceLoss = 0;
//            //SoftAttack = 6;
//            //HardAttack = 1;
//            //AirAttack = 0;
//            //Defense = 22;
//            //Breakthrough = 3;
//            //Armor = 0;
//            //Piercing = 4;
//            //Initiative = 0;
//            //Entrenchment = 0;
//            //EquipmentCaptureRatio = 0;
//            //CombatWidth = 2;
//            //Manpower = 1000;
//            //TrainingTime = 90;
//            //FuelCapacity = 0;
//            //FuelUsage = 0;
//            ////InfantryEquipment = 100;
//            //ProductionCost = 50;
//            //Kind = BatallionKind.Infantry;
//            //IsLegInfantry = true;            
//        }
//    }
//}
