using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class ArtilleryEquipment : Equipment<ArtilleryEquipment>, IParadoxRead
    {
        public ArtilleryEquipment(string name) : base(name)
        {
        }

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
                    Type = parser.ReadStringList();
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
                default:
                    throw new NotSupportedException($"The token {token} is not supported!");
            }
        }
    }
}
