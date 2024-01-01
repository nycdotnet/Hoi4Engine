using Pdoxcl2Sharp;
using System.Collections;
using System.Collections.Generic;

namespace Hoi4Extractor
{
    public class EquipmentCollection : IReadOnlyList<Equipment>, IParadoxRead
    {
        private bool parseStateEquipmentsFound = false;

        public List<Equipment> Equipment { get; } = [];
        public Equipment this[int index] => Equipment[index];

        public int Count => Equipment.Count;

        public IEnumerator<Equipment> GetEnumerator() => Equipment.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Equipment.GetEnumerator();

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (parseStateEquipmentsFound && parser.CurrentIndent == 1)
            {
                Equipment.Add(parser.Parse(new Equipment(token)));
            }
            else if (parser.CurrentIndent == 0 && token == "equipments")
            {
                parseStateEquipmentsFound = true;
            }
        }
    }
}
