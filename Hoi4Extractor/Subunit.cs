using Pdoxcl2Sharp;
using System.Collections.Generic;

namespace Hoi4Extractor
{
    public class Subunit(string name) : IParadoxRead
    {
        public string Name => name;
        public string Abbreviation { get; set; } = "";
        public string Sprite { get; set; } = "";
        public string MapIconCategory { get; set; } = "";
        public int Priority { get; set; }
        public int AIPriority { get; set; }
        /// <summary>
        /// Not quite sure what this does - only mechanized is listed as active
        /// in common/units/infantry.txt; even motorized is not.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// This is set to false on some support units.
        /// </summary>
        public bool AffectsSpeed { get; set; }
        public List<string> Type { get; set; } = [];
        public List<string> EssentialEquipment { get; set; } = [];
        public string Group { get; set; } = "";
        public List<string> Categories { get; set; } = [];
        /// <summary>
        /// Note: This is called Morale in the game files
        /// </summary>
        public decimal RecoveryRate { get; set; }
        public int MaxOrganization { get; set; }
        public int MaxStrength { get; set; }
        public int CombatWidth { get; set; }
        public int Manpower { get; set; }
        public int TrainingTime { get; set; }
        public decimal Suppression { get; set; }
        public decimal Weight { get; set; }
        public decimal SupplyConsumption { get; set; }
        public IDictionary<string, int> EquipmentNeed { get; set; }
        /// <summary>
        /// This is a modifier on speed - a value of 0.6 means this batallion goes 60% faster than
        /// it would if the modifier was 0.
        /// </summary>
        public decimal MaxSpeed { get; set; }
        public IDictionary<string, decimal> Forest { get; set; }
        public IDictionary<string, decimal> Amphibious { get; set; }
        public IDictionary<string, decimal> Hills { get; set; }
        public IDictionary<string, decimal> Mountain { get; set; }
        public IDictionary<string, decimal> Marsh { get; set; }
        public IDictionary<string, decimal> Plains { get; set; }
        public IDictionary<string, decimal> Urban { get; set; }
        public IDictionary<string, decimal> Desert { get; set; }
        public IDictionary<string, decimal> River { get; set; }
        public IDictionary<string, decimal> Jungle { get; set; }
        public IDictionary<string, decimal> Fort { get; set; }
        public bool SpecialForces { get; set; }
        public bool Cavalry { get; set; }
        public bool Marines { get; set; }
        public bool Mountaineers { get; set; }
        public decimal Breakthrough { get; set; }
        public bool CanExfiltrateFromCoast { get; set; }
        public bool CanBeParachuted { get; set; }
        /// <summary>
        /// This is what moves us and sets speed
        /// </summary>
        public string Transport { get; set; } = "";
        public decimal SoftAttack { get; set; }
        public decimal HardAttack { get; set; }
        public decimal Defense { get; set; }
        public List<string> UnsupportedTokens { get; } = [];

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
                case "affects_speed": AffectsSpeed = parser.ReadBool(); break;
                case "special_forces": SpecialForces = parser.ReadBool(); break;
                case "cavalry": Cavalry = parser.ReadBool(); break;
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
                case "fort": Fort = parser.ReadDictionary(x => x.ReadString(), x => (decimal)x.ReadDouble()); break;
                default: UnsupportedTokens.Add(token); break;
            }
        }
    }
}
