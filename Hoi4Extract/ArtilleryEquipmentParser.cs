using Hoi4Extract.Units;
using Pdoxcl2Sharp;

namespace Hoi4Extract
{
    public class InfantryBatallionParser : IParadoxRead
    {
        public List<InfantryBattalion> Battalions = [];
        public bool ready = false;

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (ready && parser.CurrentIndent == 1)
            {
                Battalions.Add(parser.Parse(new InfantryBattalion(token)));
            }
            else if (parser.CurrentIndent == 0 && token == "sub_units")
            {
                ready = true;
            }
        }
    }
}
