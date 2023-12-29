namespace Hoi4Extract.Units
{
    public abstract class Batallion
    {
        // *************** BASE STATS *************** 

        /// <summary>
        /// In Km/hr
        /// </summary>
        public abstract decimal MaxSpeed { get; }
        public abstract decimal HP { get; }
        public abstract decimal Organization { get; }
        public abstract decimal RecoveryRate { get; }
        public decimal Reconnaisance { get; protected set; }
        public abstract decimal Suppression { get; }
        public abstract decimal Weight { get; }
        public abstract decimal SupplyUse { get; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public abstract decimal AverageReliability { get; }
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

        public abstract decimal SoftAttack { get; }
        public abstract decimal HardAttack { get; }
        public decimal AirAttack { get; protected set; }
        public abstract decimal Defense { get; }
        public abstract decimal Breakthrough { get; }
        public abstract decimal Armor { get; }
        public abstract decimal Piercing { get; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal Initiative { get; protected set; }
        public decimal Entrenchment { get; protected set; }
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal EquipmentCaptureRatio { get; protected set; }
        public abstract decimal CombatWidth { get; }


        // *************** EQUIPMENT COST *************** 

        public abstract decimal Manpower { get; }
        /// <summary>
        /// In Days
        /// </summary>
        public abstract decimal TrainingTime { get; }
        public decimal FuelCapacity { get; protected set; }
        public decimal FuelUsage { get; protected set; }

        /// <summary>
        /// In IC
        /// </summary>
        public abstract decimal ProductionCost { get; }

        public abstract int InfantryEquipmentCount { get; }
        public decimal Artillery { get; protected set; }
        public decimal AntiAir { get; protected set; }
        public decimal SupportEquipment { get; protected set; }


        public string Kind { get; protected set; }
        public bool IsLegInfantry { get; protected set; }

    }
}
