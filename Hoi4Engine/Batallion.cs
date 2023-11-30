namespace Hoi4Engine
{
    public class Batallion
    {
        // *************** BASE STATS *************** 

        /// <summary>
        /// In Km/hr
        /// </summary>
        public decimal MaxSpeed { get; set; }
        public decimal HP { get; set; }
        public decimal Organization { get; set; }
        public decimal RecoveryRate { get; set; }
        public decimal Reconnaisance { get; set; }
        public decimal Suppression { get; set; }
        public decimal Weight { get; set; }
        public decimal SupplyUse { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal AverageReliability { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal ReliabilityBonus { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal TricklebackAndWarSupportProtection { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal ExperienceLoss { get; set; }

        // *************** COMBAT STATS *************** 

        public decimal SoftAttack { get; set; }
        public decimal HardAttack { get; set; }
        public decimal AirAttack { get; set; }
        public decimal Defense { get; set; }
        public decimal Breakthrough { get; set; }
        public decimal Armor { get; set; }
        public decimal Piercing { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal Initiative { get; set; }
        public decimal Entrenchment { get; set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal EquipmentCaptureRatio { get; set; }
        public decimal CombatWidth { get; set; }


        // *************** EQUIPMENT COST *************** 

        public decimal Manpower { get; set; }
        /// <summary>
        /// In Days
        /// </summary>
        public decimal TrainingTime { get; set; }
        public decimal FuelCapacity { get; set; }
        public decimal FuelUsage { get; set; }

        /// <summary>
        /// In IC
        /// </summary>
        public decimal ProductionCost { get; set; }
        
        public decimal InfantryEquipment { get; set; }
        public decimal Artillery { get; set; }


        public BatallionKind Kind { get; set; }
    }
}
