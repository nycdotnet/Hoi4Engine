using Hoi4Extract.Units.Equipment;
using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class InfantryEquipmentParser : IParadoxRead
    {
        public List<InfantryEquipment> InfantryEquipment = [];
        public bool ready = false;

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (ready && parser.CurrentIndent == 1)
            {
                InfantryEquipment.Add(parser.Parse(new InfantryEquipment(token)));
            }
            else if (parser.CurrentIndent == 0 && token == "equipments")
            {
                ready = true;
            }
        }
    }
}
