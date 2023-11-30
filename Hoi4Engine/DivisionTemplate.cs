namespace Hoi4Engine
{
    public class DivisionTemplate
    {
        private List<Batallion> brigade1 = new(5);
        private List<Batallion> brigade2 = new(5);
        private List<Batallion> brigade3 = new(5);
        private List<Batallion> brigade4 = new(5);
        private List<Batallion> brigade5 = new(5);
        private List<SupportCompany> supportCompanies = new(5);

        public void AddSupportCompany(SupportCompany batallion)
        {
            AddToBrigade(batallion, supportCompanies);
        }
        public void AddToBrigade1(Batallion batallion)
        {
            AddToBrigade(batallion, brigade1);
        }
        public void AddToBrigade2(Batallion batallion)
        {
            AddToBrigade(batallion, brigade2);
        }
        public void AddToBrigade3(Batallion batallion)
        {
            AddToBrigade(batallion, brigade3);
        }
        public void AddToBrigade4(Batallion batallion)
        {
            AddToBrigade(batallion, brigade4);
        }
        public void AddToBrigade5(Batallion batallion)
        {
            AddToBrigade(batallion, brigade5);
        }

        private void AddToBrigade<TBattalion>(TBattalion batallion, List<TBattalion> brigade) where TBattalion: Batallion
        {
            if (brigade.Count >= 5)
            {
                throw new InvalidOperationException("This brigade is already full.");
            }
            if (brigade.Count > 0 && brigade[0].Kind != batallion.Kind)
            {
                throw new InvalidOperationException($"This brigade only accepts {brigade[0].Kind} batallions.");
            }
            
            brigade.Add(batallion);
        }

        private IEnumerable<Batallion> AllBatallions()
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


        public float MaxSpeed => AllBatallions().Min(b => b.MaxSpeed);

        public float HP => AllBatallions().Sum(b => b.HP);

        /// <summary>
        /// https://hoi4.paradoxwikis.com/Land_units#Base_stats
        /// </summary>
        public float Organization => AllBatallions().Average(b => b.Organization);
        /// <summary>
        /// This stat is additional recovery rate on top of the base recovery rate.
        /// </summary>
        public float RecoveryRate => AllBatallions().Average(b => b.RecoveryRate);
        /// <summary>
        /// Note typically this will only be gained by a recon support company, so it may
        /// not be needed to sum the regular batallions.
        /// </summary>
        public float Reconnaisance => AllBatallions().Sum(b => b.Reconnaisance);
        public float Suppression => AllBatallions().Sum(b => b.Suppression);
        public float Weight => AllBatallions().Sum(b => b.Weight);
        public float SupplyUse => AllBatallions().Sum(b => b.SupplyUse);
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float AverageReliability => AllBatallions().Average(b => b.AverageReliability);
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public float ReliabilityBonus => AllBatallions().Average(b => b.ReliabilityBonus);
        /// <summary>
        /// Percentage - between -1 and 1
        /// </summary>
        public float TricklebackAndWarSupportProtection => AllBatallions().Average(b => b.TricklebackAndWarSupportProtection);
        /// <summary>
        /// Percentage - between -1 and 1
        /// </summary>
        public float ExperienceLoss => AllBatallions().Average(b => b.ExperienceLoss);

        public float SoftAttack => AllBatallions().Sum(b => b.SoftAttack);
        public float HardAttack => AllBatallions().Sum(b => b.HardAttack);
        public float AirAttack => AllBatallions().Sum(b => b.AirAttack);
        public float Defense => AllBatallions().Sum(b => b.Defense);
        public float Breakthrough => AllBatallions().Sum(b => b.Breakthrough);
        public float Armor {
            get {
                var maxArmorUnit = AllBatallions().Max(b => b.Armor);
                var avgArmor = AllBatallions().Average(b => b.Armor);
                return (maxArmorUnit * 0.4f) + (avgArmor * 0.6f);
            }
        }
        public float Piercing
        {
            get
            {
                var maxPiercingUnit = AllBatallions().Max(b => b.Piercing);
                var avgPiercing = AllBatallions().Average(b => b.Piercing);
                return (maxPiercingUnit * 0.4f) + (avgPiercing * 0.6f);
            }
        }

        // NOTE: Definitely not correct - need to consider engineers which modify leg infantry only.
        public float Entrenchment => AllBatallions().Sum(b => b.Entrenchment);
        // NOTE: Def wrong - need to consider maint cos and probably not sum.
        public float EquipmentCaptureRatio => AllBatallions().Sum(b => b.EquipmentCaptureRatio);
        public float CombatWidth => AllBatallions().Sum(b => b.CombatWidth);
        public float Manpower => AllBatallions().Sum(b => b.Manpower);
        /// <summary>
        /// In Days
        /// </summary>
        public float TrainingTime => AllBatallions().Max(b => b.TrainingTime);

        public float FuelCapacity => AllBatallions().Sum(b => b.FuelCapacity);
        public float FuelUsage => AllBatallions().Sum(b => b.FuelUsage);

        public float InfantryEquipment => AllBatallions().Sum(b => b.InfantryEquipment);
        public float ProductionCost => AllBatallions().Sum(b => b.ProductionCost);

    }
}
