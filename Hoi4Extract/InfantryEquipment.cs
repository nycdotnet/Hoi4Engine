using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    //C:\Program Files(x86)\Steam\steamapps\common\Hearts of Iron IV\
    // The file common\units\equipment\infantry.txt
    // contains stats on infantry equipment.
    public class InfantryEquipment : IParadoxRead
    {
        public InfantryEquipment(string name)
        {
            Name = name;   
        }
        public string Name { get; set; }
        public bool IsArchetype { get; set; }
        public string? Archetype { get; set; }
        public int? Year { get; set; }
        public string? Picture { get; set; }
        public string? Parent { get; set; }
        public int? Priority { get; set; }
        public int? VisualLevel { get; set; }
        public bool? IsBuildable { get; set; }
        public string? Type { get; set; }
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
        public IDictionary<string, int>? Resources { get; set; }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch(token)
            {
                case "year": Year = parser.ReadInt32(); break;
                case "is_archetype": IsArchetype = parser.ReadBool(); break;
                case "archetype": Archetype = parser.ReadString(); break;
                case "picture": Picture = parser.ReadString(); break;
                case "is_buildable": IsBuildable = parser.ReadBool(); break;
                case "type": Type = parser.ReadString(); break;
                case "group_by": GroupBy = parser.ReadString(); break;
                case "interface_category": InterfaceCategory = parser.ReadString(); break;
                case "active": Active = parser.ReadBool(); break;
                case "reliability": Reliability = (decimal)parser.ReadDouble(); break;
                case "maximum_speed": MaximumSpeed = (decimal)parser.ReadDouble(); break;
                case "defense": Defense = (decimal)parser.ReadDouble(); break;
                case "breakthrough": Breakthrough = (decimal)parser.ReadDouble(); break;
                case "hardness": Hardness = (decimal)parser.ReadDouble(); break;
                case "armor_value": ArmorValue = (decimal)parser.ReadDouble(); break;
                case "soft_attack": SoftAttack = (decimal)parser.ReadDouble(); break;
                case "hard_attack": HardAttack = (decimal)parser.ReadDouble(); break;
                case "ap_attack": Piercing = (decimal)parser.ReadDouble(); break;
                case "air_attack": AirAttack = (decimal)parser.ReadDouble(); break;
                case "lend_lease_cost": LendLeaseCost = (decimal)parser.ReadDouble(); break;
                case "build_cost_ic": BuildCostIC = (decimal)parser.ReadDouble(); break;
                case "resources": Resources = parser.ReadDictionary(x => x.ReadString(), x => x.ReadInt32()) ; break;
                case "parent": Parent = parser.ReadString(); break;
                case "priority": Priority = parser.ReadInt32(); break;
                case "visual_level": VisualLevel = parser.ReadInt32(); break;
            }
        }

        public void Normalize(InfantryEquipment archetype)
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
            if (string.IsNullOrEmpty(Type))
            {
                Type = archetype.Type;
            }
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
            if (Resources is null)
            {
                Resources = archetype.Resources;
            }
        }
    }
}
