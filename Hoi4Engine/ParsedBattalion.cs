using Hoi4Extract.Units;
using Hoi4Extract.Units.Equipment;

namespace Hoi4Engine
{
    public class ParsedBattalion : Batallion
    {
        private Dictionary<string, (InfantryEquipment equipment, int need, int have)> Equipment = new();
        public ParsedBattalion(InfantryBattalion battalionTemplate)
        {
            BattalionTemplate = battalionTemplate;
        }

        public void AddFullEquipment(InfantryEquipment equipment)
        {
            if (BattalionTemplate.EquipmentNeed.TryGetValue(equipment.Archetype, out var need))
            {
                Equipment[equipment.Archetype] = (equipment, need, need);
            }
        }

        private InfantryBattalion BattalionTemplate { get; }

        public override decimal SoftAttack {
            get =>
                BattalionTemplate.SoftAttack +
                Equipment.Values
                    .Where(e => e.equipment.SoftAttack.HasValue)
                    .Select(e => e.equipment.SoftAttack!.Value * e.have / e.need)
                    .Sum();
            protected set => throw new NotSupportedException();
        }
    }
}
