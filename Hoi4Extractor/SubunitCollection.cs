using Pdoxcl2Sharp;
using System.Collections;
using System.Collections.Generic;

namespace Hoi4Extractor
{
    public class SubunitCollection : IReadOnlyList<Subunit>, IParadoxRead
    {
        public List<Subunit> Subunits { get; } = [];
        private bool parseStateSubunitsFound = false;
        public Subunit this[int index] => Subunits[index];

        public int Count => Subunits.Count;

        public IEnumerator<Subunit> GetEnumerator() => Subunits.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Subunits.GetEnumerator();

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (parseStateSubunitsFound && parser.CurrentIndent == 1)
            {
                Subunits.Add(parser.Parse(new Subunit(token)));
            }
            else if (parser.CurrentIndent == 0 && token == "sub_units")
            {
                parseStateSubunitsFound = true;
            }
        }
    }
}
