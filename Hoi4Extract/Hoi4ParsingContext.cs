using System.Collections.Immutable;
using Hoi4Extract.Units;
using Hoi4Extract.Units.Equipment;

namespace Hoi4Extract
{
    public class Hoi4ParsingContext
    {
        public Hoi4ParsingContext(string? hoi4Root = null)
        {
            Hoi4Root = string.IsNullOrEmpty(hoi4Root) ?
                Path.Join(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), @"Steam\steamapps\common\Hearts of Iron IV") :
                hoi4Root;
            infantryEquipment = ImmutableDictionary<string, IEnumerable<InfantryEquipment>>.Empty;
            artilleryEquipment = ImmutableDictionary<string, IEnumerable<ArtilleryEquipment>>.Empty;
            infantryBatallions = ImmutableDictionary<string, IEnumerable<InfantryBattalion>>.Empty;
        }

        public string Hoi4Root { get; }

        private ImmutableDictionary<string, IEnumerable<InfantryEquipment>> infantryEquipment;
        private ImmutableDictionary<string, IEnumerable<ArtilleryEquipment>> artilleryEquipment;
        private ImmutableDictionary<string, IEnumerable<InfantryBattalion>> infantryBatallions;

        public IEnumerable<InfantryEquipment> GetInfantryEquipment(string? relativeFilePath = null)
        {
            var path = Path.Combine(Hoi4Root, relativeFilePath ?? @"common\units\equipment\infantry.txt");
            if (infantryEquipment.TryGetValue(path, out var equipment) && equipment is not null)
            {
                return equipment;
            }

            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            equipment = Hoi4Parser.ParseInfantryEquipment(fileStream);
            
            infantryEquipment = infantryEquipment.Add(path, equipment);
            return equipment;
        }

        public IEnumerable<ArtilleryEquipment> GetArtilleryEquipment(string? relativeFilePath = null)
        {
            var path = Path.Combine(Hoi4Root, relativeFilePath ?? @"common\units\equipment\artillery.txt");
            if (artilleryEquipment.TryGetValue(path, out var equipment) && equipment is not null)
            {
                return equipment;
            }

            using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            equipment = Hoi4Parser.ParseArtilleryEquipment(file);
            
            artilleryEquipment = artilleryEquipment.Add(path, equipment);
            return equipment;
        }

        public IEnumerable<InfantryBattalion> GetInfantryBatallions(string? relativeFilePath = null)
        {
            var path = Path.Combine(Hoi4Root, relativeFilePath ?? @"common\units\infantry.txt");
            if (infantryBatallions.TryGetValue(path, out var battalions) && battalions is not null)
            {
                return battalions;
            }

            using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            battalions = Hoi4Parser.ParseInfantryBattalions(file);
            infantryBatallions = infantryBatallions.Add(path, battalions);
            return battalions;
        }
    }
}
