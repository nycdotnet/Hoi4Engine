using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class Equipment : IParadoxRead
    {
        public List<InfantryEquipment> InfantryEquipment = new();

        public static Equipment Parse(Stream file)
        {
            return ParadoxParser.Parse(file, new Equipment());
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (token.StartsWith("infantry_equipment"))
            {
                InfantryEquipment.Add(parser.Parse(new InfantryEquipment(token)));
            }
        }

        public void Normalize()
        {
            if (InfantryEquipment is { Count: > 0 })
            {
                var cache = new Dictionary<string, InfantryEquipment>();
                foreach (var item in InfantryEquipment)
                {
                    if (string.IsNullOrEmpty(item?.Archetype))
                    {
                        continue;
                    }

                    if (!cache.TryGetValue(item!.Archetype!, out var archetype))
                    {
                        archetype = InfantryEquipment.FirstOrDefault(ie => ie.Name == item.Archetype);
                        if (archetype is null)
                        {
                            continue;
                        }
                        cache.Add(archetype.Name, archetype);
                    }
                    item?.Normalize(archetype);
                }
            }
        }
    }
}
