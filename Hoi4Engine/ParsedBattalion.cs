using Hoi4Extract.Units;
using Hoi4Extract.Units.Equipment;

namespace Hoi4Engine
{
    public class ParsedBattalion : Batallion
    {
        private Dictionary<string, List<(InfantryEquipment Equipment, int Quantity)>> _equipment = new();
        public InfantryBattalion UnitTemplate { get; }

        public ParsedBattalion(InfantryBattalion battalionTemplate)
        {
            UnitTemplate = battalionTemplate;
        }

        public void SetFullEquipment(InfantryEquipment equipment)
        {
            if (UnitTemplate.EquipmentNeed.TryGetValue(equipment.Archetype, out var need))
            {
                _equipment[equipment.Archetype] = [(equipment, need)];
            }
        }

        public void AddEquipment(InfantryEquipment equipment, int quantity)
        {
            if (UnitTemplate.EquipmentNeed.TryGetValue(equipment.Archetype, out var need))
            {
                if (!_equipment.TryGetValue(equipment.Archetype, out var e))
                {
                    e = [];
                    _equipment[equipment.Archetype] = e;
                }
                e.Add((equipment, quantity));

                var have = _equipment[equipment.Archetype].Sum(x => x.Quantity);
                if (have > need)
                {
                    throw new Exception($"Too much of {equipment.Archetype} - have {have} and need only {need}.");
                }
            }
        }

        /// <summary>
        /// Returns the equipment held by this battalion.
        /// </summary>
        public IEnumerable<(string Archetype, List<(InfantryEquipment Equipment, int Quantity)> Inventory)> GetEquipment() =>
            _equipment.Select(e => (Archetype: e.Key, Inventory: e.Value));

        public override decimal SoftAttack {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    var sa = equip.Value
                        .Where(e => e.Equipment.SoftAttack.HasValue)
                        .Sum(e => e.Equipment.SoftAttack!.Value * e.Quantity / need);
                    result += sa;
                }
                return result;
            }
        }

        public override int InfantryEquipmentCount
        {
            get
            {
                if (_equipment.TryGetValue("infantry_equipment", out var e))
                {
                    return e.Sum(x => x.Quantity);
                }
                return 0;
            }  
        }
    }
}
