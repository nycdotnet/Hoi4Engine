using Hoi4Extract.Units.Equipment;
using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class ArtilleryEquipmentParser : IParadoxRead
    {
        public List<ArtilleryEquipment> ArtilleryEquipment = [];
        public bool ready = false;

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (ready && parser.CurrentIndent == 1)
            {
                ArtilleryEquipment.Add(parser.Parse(new ArtilleryEquipment(token)));
            }
            else if (parser.CurrentIndent == 0 && token == "equipments")
            {
                ready = true;
            }
        }
    }
}
