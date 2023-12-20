using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class KnownEquipment : IParadoxRead
    {
        public List<InfantryEquipment> InfantryEquipment = [];
        public List<ArtilleryEquipment> ArtilleryEquipment = [];

        public static KnownEquipment Parse(Stream file)
        {
            return ParadoxParser.Parse(file, new KnownEquipment());
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (token.StartsWith("infantry_equipment"))
            {
                InfantryEquipment.Add(parser.Parse(new InfantryEquipment(token)));
            }
            else if (token.StartsWith("artillery_equipment") ||
                token.StartsWith("rocket_artillery") ||
                token.StartsWith("motorized_rocket"))
            {
                ArtilleryEquipment.Add(parser.Parse(new ArtilleryEquipment(token)));
            }
        }

        public void Normalize()
        {
            Norm(InfantryEquipment);
            Norm(ArtilleryEquipment);

            void Norm<T>(List<T> list) where T : Equipment<T>
            {
                if (list is { Count: > 0 })
                {
                    var cache = new Dictionary<string, T>();
                    foreach (var item in list)
                    {
                        if (string.IsNullOrEmpty(item?.Archetype))
                        {
                            continue;
                        }

                        if (!cache.TryGetValue(item!.Archetype!, out var archetype))
                        {
                            archetype = list.FirstOrDefault(ie => ie.Name == item.Archetype);
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
}
