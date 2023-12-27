using Pdoxcl2Sharp;

namespace Hoi4Extract.Units
{
    /// <summary>
    /// Represents a parsed batallion template
    /// </summary>
    public class InfantryBattalion(string name) : IParadoxRead
    {
        public string Name => name;
        public string Abbreviation { get; private set; } = "";
        public string Sprite { get; private set; } = "";
        public string MapIconCategory { get; private set; } = "";
        public int Priority { get; private set; }
        public int AIPriority { get; private set; }
        /// <summary>
        /// Not quite sure what this does - only mechanized is listed as active
        /// in common/units/infantry.txt; even motorized is not.
        /// </summary>
        public bool Active { get; private set; }
        public List<string> Type { get; private set; } = [];
        public List<string> EssentialEquipment { get; private set; } = [];
        public string Group { get; private set; } = "";
        public List<string> Categories { get; private set; } = [];
        /// <summary>
        /// Note: This is called Morale in the game files
        /// </summary>
        public decimal RecoveryRate { get; private set; }
        public int MaxOrganization { get; private set; }
        public int MaxStrength { get; private set; }
        public int CombatWidth { get; private set; }
        public int Manpower { get; private set; }
        public int TrainingTime { get; private set; }
        public decimal Suppression { get; private set; }
        public decimal Weight { get; private set; }
        public decimal SupplyConsumption { get; private set; }
        public IDictionary<string, int> EquipmentNeed { get; private set; }
        public decimal MaxSpeed { get; private set; }
        public IDictionary<string, decimal> Forest { get; private set; }
        public IDictionary<string, decimal> Amphibious { get; private set; }
        public IDictionary<string, decimal> Hills { get; private set; }
        public IDictionary<string, decimal> Mountain { get; private set; }
        public IDictionary<string, decimal> Marsh { get; private set; }
        public IDictionary<string, decimal> Plains { get; private set; }
        public IDictionary<string, decimal> Urban { get; private set; }
        public IDictionary<string, decimal> Desert { get; private set; }
        public IDictionary<string, decimal> River { get; private set; }
        public IDictionary<string, decimal> Jungle { get; private set; }
        public bool SpecialForces { get; private set; }
        public bool Marines { get; private set; }
        public bool Mountaineers { get; private set; }
        public decimal Breakthrough { get; private set; }
        public bool CanExfiltrateFromCoast { get; private set; }
        public bool CanBeParachuted { get; private set; }
        /// <summary>
        /// This is what moves us and sets speed
        /// </summary>
        public string Transport { get; private set; } = "";
        public decimal SoftAttack { get; private set; }
        public decimal HardAttack { get; private set; }
        public decimal Defense { get; private set; }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "abbreviation": Abbreviation = parser.ReadString(); break;
                case "sprite": Sprite = parser.ReadString(); break;
                case "map_icon_category": MapIconCategory = parser.ReadString(); break;
                case "priority": Priority = parser.ReadInt32(); break;
                case "ai_priority": AIPriority = parser.ReadInt32(); break;
                case "active": Active = parser.ReadBool(); break;
                case "special_forces": SpecialForces = parser.ReadBool(); break;
                case "can_be_parachuted": CanBeParachuted = parser.ReadBool(); break;
                case "marines": Marines = parser.ReadBool(); break;
                case "mountaineers": Mountaineers = parser.ReadBool(); break;
                case "type": Type.AddRange(parser.ReadStringList()); break;
                case "essential": EssentialEquipment.AddRange(parser.ReadStringList()); break;
                case "group": Group = parser.ReadString(); break;
                case "transport": Transport = parser.ReadString(); break;
                case "categories": Categories.AddRange(parser.ReadStringList()); break;
                case "combat_width": CombatWidth = parser.ReadInt32(); break;
                case "max_strength": MaxStrength = parser.ReadInt32(); break;
                case "max_organisation": MaxOrganization = parser.ReadInt32(); break;
                case "maximum_speed": MaxSpeed = (decimal)parser.ReadDouble(); break;
                case "default_morale": RecoveryRate = (decimal)parser.ReadDouble(); break;
                case "manpower": Manpower = parser.ReadInt32(); break;
                case "training_time": TrainingTime = parser.ReadInt32(); break;
                case "suppression": Suppression = (decimal)parser.ReadDouble(); break;
                case "breakthrough": Breakthrough = (decimal)parser.ReadDouble(); break;
                case "can_exfiltrate_from_coast": CanExfiltrateFromCoast = parser.ReadBool(); break;
                case "weight": Weight = (decimal)parser.ReadDouble(); break;
                case "soft_attack": SoftAttack = (decimal)parser.ReadDouble(); break;
                case "hard_attack": HardAttack = (decimal)parser.ReadDouble(); break;
                case "defense": Defense = (decimal)parser.ReadDouble(); break;
                case "supply_consumption": SupplyConsumption = (decimal)parser.ReadDouble(); break;
                case "need": EquipmentNeed = parser.ReadDictionary(x => x.ReadString(), x => x.ReadInt32()); break;
                case "forest": Forest = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "hills": Hills = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "mountain": Mountain = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "marsh": Marsh = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "plains": Plains = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "urban": Urban = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "desert": Desert = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "river": River = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "amphibious": Amphibious = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                case "jungle": Jungle = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                default:
                    throw new NotSupportedException($"The token {token} is not supported!");
            }
        }
    }
}
