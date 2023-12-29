using Hoi4Extract.Units;
using Hoi4Extract.Units.Equipment;

namespace Hoi4Engine
{
    public class EquipedBattalion : Batallion
    {
        private Dictionary<string, List<(InfantryEquipment Equipment, int Quantity)>> _equipment = new();
        public InfantryBatallion UnitTemplate { get; }

        public EquipedBattalion(Batallion battalionTemplate)
        {
            //UnitTemplate = battalionTemplate;
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
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.SoftAttack.HasValue)
                        .Sum(e => e.Equipment.SoftAttack!.Value * e.Quantity / need);
                    result += sa;
                }
                return result + UnitTemplate.SoftAttack;
            }
        }

        public override decimal HardAttack
        {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.HardAttack.HasValue)
                        .Sum(e => e.Equipment.HardAttack!.Value * e.Quantity / need);
                    result += sa;
                }
                return result + UnitTemplate.HardAttack;
            }
        }

        public override decimal Defense
        {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.Defense.HasValue)
                        .Sum(e => e.Equipment.Defense!.Value * e.Quantity / need);
                    result += sa;
                }
                return result + UnitTemplate.Defense;
            }
        }

        public override decimal Breakthrough
        {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.Breakthrough.HasValue)
                        .Sum(e => e.Equipment.Breakthrough!.Value * e.Quantity / need);
                    result += sa;
                }
                return result + UnitTemplate.Breakthrough;
            }
        }

        public override decimal Armor
        {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.ArmorValue.HasValue)
                        .Sum(e => e.Equipment.ArmorValue!.Value * e.Quantity / need);
                    result += sa;
                }
                return result;
            }
        }

        public override decimal Piercing
        {
            get
            {
                var result = 0m;
                foreach (var equip in _equipment)
                {
                    var need = UnitTemplate.EquipmentNeed[equip.Key];
                    if (need == 0)
                    {
                        continue;
                    }
                    var sa = equip.Value
                        .Where(e => e.Equipment.Piercing.HasValue)
                        .Sum(e => e.Equipment.Piercing!.Value * e.Quantity / need);
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

        public override decimal MaxSpeed {
            get
            {
                // The max speed the battalion can go is the speed of its slowest element.

                var maxSpeedFromEquipment = _equipment
                    .Values
                    .SelectMany(v => v.Where(x => x.Equipment.MaximumSpeed.HasValue && x.Equipment.MaximumSpeed.Value > 0).Select(x => x.Equipment.MaximumSpeed.Value))
                    .Min();

                return maxSpeedFromEquipment * (1 + UnitTemplate.MaxSpeed);
            }
        }

        public override decimal HP => UnitTemplate.MaxStrength;
        public override decimal Organization => UnitTemplate.MaxOrganization;
        public override decimal RecoveryRate => UnitTemplate.RecoveryRate;
        public override decimal Suppression => UnitTemplate.Suppression;
        public override decimal Weight => UnitTemplate.Weight;
        public override decimal SupplyUse => UnitTemplate.SupplyConsumption;

        public override decimal AverageReliability
        {
            get
            {
                var result = _equipment
                    .Where(e => e.Value.Any(v => v.Equipment.Reliability.HasValue && v.Equipment.Reliability > 0))
                    .Select(equip =>
                    {
                        var rel = equip.Value.Select(e => (reliability: e.Equipment.Reliability!.Value, quantity: e.Quantity));

                        var denominator = rel.Sum(r => r.quantity);

                        if (denominator == 0)
                        {
                            return null;
                        }

                        return (decimal?)rel.Sum(r => r.quantity * r.reliability) / denominator;
                    })
                    .Where(e => e is not null)
                    .Average();

                return result ?? 1;
            }
        }

        public override decimal Manpower => UnitTemplate.Manpower;
        public override decimal TrainingTime => UnitTemplate.TrainingTime;
        public override decimal ProductionCost => _equipment
            .SelectMany(e => e.Value.Select(eq => (eq.Equipment.BuildCostIC * eq.Quantity) ?? 0))
            .Sum();

        public override decimal CombatWidth => UnitTemplate.CombatWidth;
    }
}
