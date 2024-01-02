using Hoi4Extractor;

namespace Hoi4Engine
{
    public class DivisionTemplate2
    {
        private readonly List<Subunit> brigade1 = new(5);
        private readonly List<Subunit> brigade2 = new(5);
        private readonly List<Subunit> brigade3 = new(5);
        private readonly List<Subunit> brigade4 = new(5);
        private readonly List<Subunit> brigade5 = new(5);
        private readonly List<Subunit> supportCompanies = new(5);
        private bool statsCalculated = false;

        public void AddToBrigade1(Subunit batallion)
        {
            AddToBrigade(batallion, brigade1);
        }

        private void AddToBrigade<TSubunit>(TSubunit batallion, List<TSubunit> brigade) where TSubunit : Subunit
        {
            if (brigade.Count >= 5)
            {
                throw new InvalidOperationException("This brigade is already full.");
            }

            if (brigade.Count > 0 && brigade[0].Group != batallion.Group)
            {
                throw new InvalidOperationException($"This brigade only accepts {brigade[0].Group} batallions.");
            }
            statsCalculated = false;
            brigade.Add(batallion);
        }

        private decimal _softAttack;
        public decimal SoftAttack
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _softAttack;
            }
        }

        private decimal _hardAttack;
        public decimal HardAttack
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _hardAttack;
            }
        }

        private decimal _airAttack;
        public decimal AirAttack
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _airAttack;
            }
        }

        private decimal _defense;
        public decimal Defense
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _defense;
            }
        }

        private decimal _breakthrough;
        public decimal Breakthrough
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _breakthrough;
            }
        }


        private decimal _averageReliability;
        public decimal AverageReliability
        {
            get
            {
                if (!statsCalculated)
                {
                    CalculateStats();
                }
                return _averageReliability;
            }
        }

        private void CalculateStats()
        {
            ResetStats();
            var availableEquipment = CurrentEquipment().ToDictionary(e => e.archetype, e => e.items);

            _averageReliability = Math.Round(CurrentEquipment()
                .Where(e => e.items.Sum(x => x.Quantity) > 0 && e.items.Any(x => x.Equipment.Reliability.HasValue))
                .Select(e => {
                    var qty = e.items.Sum(x => x.Quantity);
                    return e.items.Select(x => (x.Equipment.Reliability ?? 0) * x.Quantity / qty).Sum();
                }).DefaultIfEmpty(1m).Average(), 3);

            foreach (var batallion in AllBatallionsAndSupportCompanies())
            {
                _softAttack += batallion.SoftAttack;
                _hardAttack += batallion.HardAttack;

                if (batallion.EssentialEquipment is { Count: > 0})
                {
                    throw new NotSupportedException("Essential equipment is not yet supported.");
                }
                foreach (var need in batallion.EquipmentNeed)
                {
                    var quantityFound = 0;
                    if (availableEquipment.TryGetValue(need.Key, out var equip))
                    {
                        for (var i = 0; i < equip.Count; i++)
                        {
                            var e = equip[i];
                            var remainder = e.Quantity - need.Value;
                            var ratio = 0m;
                            if (remainder >= 0)
                            {
                                quantityFound += need.Value;
                                ratio = 1;
                                equip[i] = (e.Equipment, remainder);
                            }
                            else
                            {
                                quantityFound += e.Quantity;
                                ratio = (decimal)e.Quantity / need.Value;
                                equip[i] = (e.Equipment, 0);
                            }

                            if (ratio != 0)
                            {
                                if (e.Equipment.SoftAttack.HasValue)
                                {
                                    _softAttack += e.Equipment.SoftAttack.Value * ratio;
                                }
                                if (e.Equipment.HardAttack.HasValue)
                                {
                                    _hardAttack += e.Equipment.HardAttack.Value * ratio;
                                }
                                if (e.Equipment.AirAttack.HasValue)
                                {
                                    _airAttack += e.Equipment.AirAttack.Value * ratio;
                                }
                                if (e.Equipment.Defense.HasValue)
                                {
                                    _defense += e.Equipment.Defense.Value * ratio;
                                }
                                if (e.Equipment.Breakthrough.HasValue)
                                {
                                    _breakthrough += e.Equipment.Breakthrough.Value * ratio;
                                }
                            }

                            if (quantityFound == need.Value)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            statsCalculated = true;

            void ResetStats()
            {
                _softAttack = 0;
                _hardAttack = 0;
                _airAttack = 0;
                _defense = 0;
                _breakthrough = 0;
            }
        }

        private IEnumerable<Subunit> AllBatallions()
        {
            for (var i = 0; i < brigade1.Count; i++)
            {
                yield return brigade1[i];
            }
            for (var i = 0; i < brigade2.Count; i++)
            {
                yield return brigade2[i];
            }
            for (var i = 0; i < brigade3.Count; i++)
            {
                yield return brigade3[i];
            }
            for (var i = 0; i < brigade4.Count; i++)
            {
                yield return brigade4[i];
            }
            for (var i = 0; i < brigade5.Count; i++)
            {
                yield return brigade5[i];
            }
        }

        private IEnumerable<Subunit> AllBatallionsAndSupportCompanies()
        {
            for (var i = 0; i < brigade1.Count; i++)
            {
                yield return brigade1[i];
            }
            for (var i = 0; i < brigade2.Count; i++)
            {
                yield return brigade2[i];
            }
            for (var i = 0; i < brigade3.Count; i++)
            {
                yield return brigade3[i];
            }
            for (var i = 0; i < brigade4.Count; i++)
            {
                yield return brigade4[i];
            }
            for (var i = 0; i < brigade5.Count; i++)
            {
                yield return brigade5[i];
            }
            for (var i = 0; i < supportCompanies.Count; i++)
            {
                yield return supportCompanies[i];
            }
        }

        public void AddEquipment(Equipment equipment, int quantity)
        {
            if (NeededEquipment.TryGetValue(equipment.Archetype, out var needed))
            {
                if (_equipment.TryGetValue(equipment.Archetype, out var current))
                {
                    if (current.Sum(e => e.Quantity) + quantity > needed)
                    {
                        throw new NotImplementedException("Upgrade or refill logic is not currently implemented.");
                    }
                    var index = current.FindIndex(c => c.Equipment.Name == equipment.Name);
                    if (index == -1)
                    {
                        current.Add((equipment, quantity));
                    }
                    else
                    {
                        current[index] = (current[index].Equipment, current[index].Quantity + quantity);
                    }
                }
                else
                {
                    _equipment[equipment.Archetype] = [(equipment, quantity)];
                    statsCalculated = false;
                }
            }
        }

        private readonly Dictionary<string, List<(Equipment Equipment, int Quantity)>> _equipment = [];

        /// <summary>
        /// The current inventory of equipment in this division.  Will never be more for any given
        /// archetype than the NeededEquipment.  Keyed by archetype and then name.  Equipment for
        /// each archetype is ordered so the most modern kit is first.
        /// </summary>
        public IEnumerable<(string archetype, List<(Equipment Equipment, int Quantity)> items)> CurrentEquipment() =>
            _equipment.Select(e => (archetype: e.Key, items: e.Value.OrderByDescending(x => x.Equipment.Year).ToList()));

        /// <summary>
        /// The complete list of all equipment needed to fill this template from zero (ignores current
        /// inventory).  The key represents the archetype and the integer is the count.
        /// </summary>
        public Dictionary<string, int> NeededEquipment
        {
            get
            {
                var result = new Dictionary<string, int>();
                foreach (var batallion in AllBatallionsAndSupportCompanies())
                {
                    foreach (var req in batallion.EquipmentNeed)
                    {
                        if (result.TryGetValue(req.Key, out var previousNeed))
                        {
                            result[req.Key] = previousNeed + req.Value;
                        }
                        else
                        {
                            result[req.Key] = req.Value;
                        }
                    }
                }
                return result;
            }
        }
    }
}
