using Hoi4Extract.Units;
using Hoi4Extract.Units.Equipment;
using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class Hoi4Parser //: IParadoxRead
    {
        public List<InfantryEquipment> InfantryEquipment = [];
        public List<ArtilleryEquipment> ArtilleryEquipment = [];

        public static List<InfantryEquipment> ParseInfantryEquipment(Stream file)
        {
            var result = ParadoxParser.Parse(file, new InfantryEquipmentParser());
            Normalize(result.InfantryEquipment.Cast<Equipment>().ToList());
            return result.InfantryEquipment;
        }

        public static List<ArtilleryEquipment> ParseArtilleryEquipment(Stream file)
        {
            var result = ParadoxParser.Parse(file, new ArtilleryEquipmentParser());
            Normalize(result.ArtilleryEquipment.Cast<Equipment>().ToList());
            return result.ArtilleryEquipment;
        }

        public static List<InfantryBattalion> ParseInfantryBattalions(FileStream file)
        {
            var result = ParadoxParser.Parse(file, new InfantryBatallionParser());
            return result.Battalions;
        }


        private static void Normalize(List<Equipment> equipment)
        {
            if (equipment is { Count: > 0 })
            {
                var cache = new Dictionary<string, Equipment>();
                foreach (var item in equipment)
                {
                    if (string.IsNullOrEmpty(item?.Archetype))
                    {
                        continue;
                    }

                    if (!cache.TryGetValue(item!.Archetype!, out var archetype))
                    {
                        archetype = equipment.FirstOrDefault(ie => ie.Name == item.Archetype);
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


        //public static Hoi4Parser Parse(Stream file)
        //{
        //    return Parse(file, new Hoi4Parser());
        //}

        //public static Hoi4Parser Parse(Stream file, Hoi4Parser equipment)
        //{
        //    return ParadoxParser.Parse(file, equipment);
        //}

        //public void TokenCallback(ParadoxParser parser, string token)
        //{
        //    if (token.StartsWith("infantry_equipment"))
        //    {
        //        InfantryEquipment.Add(parser.Parse(new InfantryEquipment(token)));
        //    }
        //    //else if (token.StartsWith("artillery_equipment") ||
        //    //    token.StartsWith("rocket_artillery") ||
        //    //    token.StartsWith("motorized_rocket"))
        //    //{
        //    //    ArtilleryEquipment.Add(parser.Parse(new ArtilleryEquipment(token)));
        //    //}
        //}

        //public void Normalize()
        //{
        //    Norm(InfantryEquipment);
        //    Norm(ArtilleryEquipment);

        //    void Norm<T>(List<T> list) where T : Equipment<T>
        //    {

        //    }
        //}

        //public static void Normalize<T>(IList<Equipment<T>> equipment)
        //{
        //    // making this generic so I can apply it to line 15
        //    //if (equipment is { Count: > 0 })
        //    //{
        //    //    var cache = new Dictionary<string, T>();
        //    //    foreach (var item in equipment)
        //    //    {
        //    //        if (string.IsNullOrEmpty(item?.Archetype))
        //    //        {
        //    //            continue;
        //    //        }

        //    //        if (!cache.TryGetValue(item!.Archetype!, out var archetype))
        //    //        {
        //    //            archetype = equipment.FirstOrDefault(ie => ie.Name == item.Archetype);
        //    //            if (archetype is null)
        //    //            {
        //    //                continue;
        //    //            }
        //    //            cache.Add(archetype.Name, archetype);
        //    //        }
        //    //        item?.Normalize(archetype);
        //    //    }
        //    //}
        //}


    }
}
