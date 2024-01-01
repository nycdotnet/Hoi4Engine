using Pdoxcl2Sharp;
using System;
using System.Collections.Generic;

namespace Hoi4Extractor
{
    public class Equipment(string name) : IParadoxRead
    {
        public string Name { get; } = name;
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
        public IDictionary<string, int> Resources { get; set; }
        public List<string> UnsupportedTokens { get; } = new();

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "year": Year = parser.ReadInt32(); break;
                case "is_archetype": IsArchetype = parser.ReadBool(); break;
                case "archetype": Archetype = parser.ReadString(); break;
                case "picture": Picture = parser.ReadString(); break;
                case "is_buildable": IsBuildable = parser.ReadBool(); break;
                case "type":
                    if (parser.NextIsBracketed())
                    {
                        Type = parser.ReadStringList();
                    }
                    else
                    {
                        Type = [parser.ReadString()];
                    }
                    break;
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
                case "resources": Resources = parser.ReadDictionary(x => x.ReadString(), x => x.ReadInt32()); break;
                case "parent": Parent = parser.ReadString(); break;
                case "priority": Priority = parser.ReadInt32(); break;
                case "visual_level": VisualLevel = parser.ReadInt32(); break;
                case "fuel_consumption": FuelConsumption = (decimal)parser.ReadDouble(); break;
                default: UnsupportedTokens.Add(token); break;
            }
        }
    }
}
