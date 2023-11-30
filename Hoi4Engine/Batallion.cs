namespace Hoi4Engine
{
    public class Batallion
    {
        // *************** BASE STATS *************** 

        /// <summary>
        /// In Km/hr
        /// </summary>
        public decimal MaxSpeed { get; protected set; }
        public decimal HP { get; protected set; }
        public decimal Organization { get; protected set; }
        public decimal RecoveryRate { get; protected set; }
        public decimal Reconnaisance { get; protected set; }
        public decimal Suppression { get; protected set; }
        public decimal Weight { get; protected set; }
        public decimal SupplyUse { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal AverageReliability { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal ReliabilityBonus { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal TricklebackAndWarSupportProtection { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal ExperienceLoss { get; protected set; }

        // *************** COMBAT STATS *************** 

        public decimal SoftAttack { get; protected set; }
        public decimal HardAttack { get; protected set; }
        public decimal AirAttack { get; protected set; }
        public decimal Defense { get; protected set; }
        public decimal Breakthrough { get; protected set; }
        public decimal Armor { get; protected set; }
        public decimal Piercing { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal Initiative { get; protected set; }
        public decimal Entrenchment { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal EquipmentCaptureRatio { get; protected set; }
        public decimal CombatWidth { get; protected set; }


        // *************** EQUIPMENT COST *************** 

        public decimal Manpower { get; protected set; }
        /// <summary>
        /// In Days
        /// </summary>
        public decimal TrainingTime { get; protected set; }
        public decimal FuelCapacity { get; protected set; }
        public decimal FuelUsage { get; protected set; }

        /// <summary>
        /// In IC
        /// </summary>
        public decimal ProductionCost { get; protected set; }
        
        public decimal InfantryEquipment { get; protected set; }
        public decimal Artillery { get; protected set; }
        public decimal AntiAir { get; protected set; }
        public decimal SupportEquipment { get; protected set; }


        public BatallionKind Kind { get; protected set; }
        public bool IsLegInfantry { get; protected set; }
    }
}
