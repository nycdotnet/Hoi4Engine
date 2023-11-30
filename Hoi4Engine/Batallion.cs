namespace Hoi4Engine
{
    public class Batallion
    {
        // *************** BASE STATS *************** 

        /// <summary>
        /// In Km/hr
        /// </summary>
        public float MaxSpeed { get; set; }
        public float HP { get; set; }
        public float Organization { get; set; }
        public float RecoveryRate { get; set; }
        public float Reconnaisance { get; set; }
        public float Suppression { get; set; }
        public float Weight { get; set; }
        public float SupplyUse { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float AverageReliability { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float ReliabilityBonus { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float TricklebackAndWarSupportProtection { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float ExperienceLoss { get; set; }

        // *************** COMBAT STATS *************** 

        public float SoftAttack { get; set; }
        public float HardAttack { get; set; }
        public float AirAttack { get; set; }
        public float Defense { get; set; }
        public float Breakthrough { get; set; }
        public float Armor { get; set; }
        public float Piercing { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float Initiative { get; set; }
        public float Entrenchment { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float EquipmentCaptureRatio { get; set; }
        public float CombatWidth { get; set; }


        // *************** EQUIPMENT COST *************** 

        public float Manpower { get; set; }
        /// <summary>
        /// In Days
        /// </summary>
        public float TrainingTime { get; set; }
        public float FuelCapacity { get; set; }
        public float FuelUsage { get; set; }

        /// <summary>
        /// In IC
        /// </summary>
        public float ProductionCost { get; set; }
        public float InfantryEquipment { get; set; }
        public BatallionKind Kind { get; set; }
    }
}
