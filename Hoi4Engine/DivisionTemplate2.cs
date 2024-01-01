using Hoi4Extractor;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            brigade.Add(batallion);
        }

        public decimal SoftAttack => AllBatallionsAndSupportCompanies().Sum(b => b.SoftAttack);

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
            // need to figure out how this should work - by the archetype??
            throw new NotImplementedException();
        }

        public Dictionary<string, int> Equipment { get; } = new();

        public Dictionary<string, int> NeededEquipment
        {
            get
            {
                var result = new Dictionary<string, int>();
                foreach (var batallion in AllBatallionsAndSupportCompanies())
                {
                    foreach (var need in batallion.EquipmentNeed)
                    {
                        if (result.TryGetValue(need.Key, out var previousNeed))
                        {
                            result[need.Key] = previousNeed + need.Value;
                        }
                        else
                        {
                            result[need.Key] = need.Value;
                        }
                    }
                }
                return result;
            }
        }

        //public void FillEquipment()
        //{
        //    Equipment.Clear();
        //    foreach (var batallion in AllBatallionsAndSupportCompanies())
        //    {
        //        foreach (var need in batallion.EquipmentNeed)
        //        {
        //            if (Equipment.TryGetValue(need.Key, out var existingAmount))
        //            {
        //                Equipment[need.Key] = existingAmount + need.Value;
        //            }
        //            else
        //            {
        //                Equipment[need.Key] = need.Value;
        //            }
        //        }
        //    }
        //}
    }
}
