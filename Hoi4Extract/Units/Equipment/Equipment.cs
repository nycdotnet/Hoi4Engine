namespace Hoi4Extract.Units.Equipment
{
    public abstract class Equipment(string name)
    {
        public string Name { get; set; } = name;
        public bool IsArchetype { get; set; }
        public string Archetype { get; set; } = "";
        public int? Year { get; set; }
        public string Picture { get; set; } = "";
        public string Parent { get; set; } = "";
        public int? Priority { get; set; }
        public int? VisualLevel { get; set; }
        public bool? IsBuildable { get; set; }
        public IList<string>? Type { get; set; }
        public string? GroupBy { get; set; }
        public string? InterfaceCategory { get; set; }
        public bool? Active { get; set; }
        public decimal? Reliability { get; set; }
        public decimal? MaximumSpeed { get; set; }
        public decimal? Defense { get; set; }
        public decimal? Breakthrough { get; set; }
        public decimal? Hardness { get; set; }
        public decimal? ArmorValue { get; set; }
        public decimal? SoftAttack { get; set; }
        public decimal? HardAttack { get; set; }
        public decimal? Piercing { get; set; }
        public decimal? AirAttack { get; set; }
        /// <summary>
        /// Space taken in convoy
        /// </summary>
        public decimal? LendLeaseCost { get; set; }
        public decimal? BuildCostIC { get; set; }
        public decimal? FuelConsumption { get; set; }
        public IDictionary<string, int>? Resources { get; set; }

        public void Normalize(Equipment archetype)
        {
            if (!Year.HasValue)
            {
                Year = archetype.Year;
            }
            if (string.IsNullOrEmpty(Picture))
            {
                Picture = archetype.Picture;
            }
            if (!IsBuildable.HasValue)
            {
                IsBuildable = archetype.IsBuildable;
            }
            
            Type ??= archetype.Type;

            if (string.IsNullOrEmpty(GroupBy))
            {
                GroupBy = archetype.GroupBy;
            }
            if (string.IsNullOrEmpty(InterfaceCategory))
            {
                InterfaceCategory = archetype.InterfaceCategory;
            }
            if (!Active.HasValue)
            {
                Active = archetype.Active;
            }
            if (!Reliability.HasValue)
            {
                Reliability = archetype.Reliability;
            }
            if (!MaximumSpeed.HasValue)
            {
                MaximumSpeed = archetype.MaximumSpeed;
            }
            if (!Defense.HasValue)
            {
                Defense = archetype.Defense;
            }
            if (!Breakthrough.HasValue)
            {
                Breakthrough = archetype.Breakthrough;
            }
            if (!Hardness.HasValue)
            {
                Hardness = archetype.Hardness;
            }
            if (!ArmorValue.HasValue)
            {
                ArmorValue = archetype.ArmorValue;
            }
            if (!SoftAttack.HasValue)
            {
                SoftAttack = archetype.SoftAttack;
            }
            if (!HardAttack.HasValue)
            {
                HardAttack = archetype.HardAttack;
            }
            if (!Piercing.HasValue)
            {
                Piercing = archetype.Piercing;
            }
            if (!AirAttack.HasValue)
            {
                AirAttack = archetype.AirAttack;
            }
            if (!LendLeaseCost.HasValue)
            {
                LendLeaseCost = archetype.LendLeaseCost;
            }
            if (!BuildCostIC.HasValue)
            {
                BuildCostIC = archetype.BuildCostIC;
            }
            if (string.IsNullOrEmpty(Parent))
            {
                Parent = archetype.Parent;
            }
            if (!Priority.HasValue)
            {
                Priority = archetype.Priority;
            }
            if (!VisualLevel.HasValue)
            {
                VisualLevel = archetype.VisualLevel;
            }
            
            Resources ??= archetype.Resources;
        }
    }
}
