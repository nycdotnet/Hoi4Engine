namespace Hoi4Engine
{
    public class DivisionTemplate
    {
        private readonly List<Batallion> brigade1 = new(5);
        private readonly List<Batallion> brigade2 = new(5);
        private readonly List<Batallion> brigade3 = new(5);
        private readonly List<Batallion> brigade4 = new(5);
        private readonly List<Batallion> brigade5 = new(5);
        private readonly List<SupportCompany> supportCompanies = new(5);

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

        private static void AddToBrigade<TBattalion>(TBattalion batallion, List<TBattalion> brigade) where TBattalion: Batallion
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


        public decimal MaxSpeed => AllBatallions().Min(b => b.MaxSpeed);

        public decimal HP => AllBatallions().Sum(b => b.HP);

        /// <summary>
        /// https://hoi4.paradoxwikis.com/Land_units#Base_stats
        /// </summary>
        public decimal Organization => Math.Round(AllBatallions().Average(b => b.Organization), 1, MidpointRounding.ToZero);
        /// <summary>
        /// This stat is additional recovery rate on top of the base recovery rate.
        /// </summary>
        public decimal RecoveryRate => Math.Round(AllBatallions().Average(b => b.RecoveryRate), 2, MidpointRounding.ToZero);
        /// <summary>
        /// Note typically this will only be gained by a recon support company, so it may
        /// not be needed to sum the regular batallions.
        /// </summary>
        public decimal Reconnaisance => AllBatallions().Sum(b => b.Reconnaisance);
        public decimal Suppression => AllBatallions().Sum(b => b.Suppression);
        public decimal Weight => AllBatallions().Sum(b => b.Weight);
        public decimal SupplyUse => AllBatallions().Sum(b => b.SupplyUse);
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal AverageReliability => Math.Round(AllBatallions().Average(b => b.AverageReliability), 3, MidpointRounding.ToZero);
        /// <summary>
        /// Percentage - between 0 and 1
        /// </summary>
        public decimal ReliabilityBonus => AllBatallions().Average(b => b.ReliabilityBonus);
        /// <summary>
        /// Percentage - between -1 and 1
        /// </summary>
        public decimal TricklebackAndWarSupportProtection => AllBatallions().Average(b => b.TricklebackAndWarSupportProtection);
        /// <summary>
        /// Percentage - between -1 and 1
        /// </summary>
        public decimal ExperienceLoss => AllBatallions().Average(b => b.ExperienceLoss);

        public decimal SoftAttack => AllBatallions().Sum(b => b.SoftAttack);
        public decimal HardAttack => AllBatallions().Sum(b => b.HardAttack);
        public decimal AirAttack => AllBatallions().Sum(b => b.AirAttack);
        public decimal Defense => AllBatallions().Sum(b => b.Defense);
        public decimal Breakthrough => AllBatallions().Sum(b => b.Breakthrough);
        public decimal Armor {
            get {
                var maxArmorUnit = AllBatallions().Max(b => b.Armor);
                var avgArmor = AllBatallions().Average(b => b.Armor);
                return (maxArmorUnit * 0.4m) + (avgArmor * 0.6m);
            }
        }
        public decimal Piercing
        {
            get
            {
                var maxPiercingUnit = AllBatallions().Max(b => b.Piercing);
                var avgPiercing = AllBatallions().Average(b => b.Piercing);
                return Math.Round((maxPiercingUnit * 0.4m) + (avgPiercing * 0.6m), 1, MidpointRounding.ToZero);
            }
        }

        // NOTE: Definitely not correct - need to consider engineers which modify leg infantry only.
        public decimal Entrenchment => AllBatallions().Sum(b => b.Entrenchment);
        // NOTE: Def wrong - need to consider maint cos and probably not sum.
        public decimal EquipmentCaptureRatio => AllBatallions().Sum(b => b.EquipmentCaptureRatio);
        public decimal CombatWidth => AllBatallions().Sum(b => b.CombatWidth);
        public decimal Manpower => AllBatallions().Sum(b => b.Manpower);
        /// <summary>
        /// In Days
        /// </summary>
        public decimal TrainingTime => AllBatallions().Max(b => b.TrainingTime);

        public decimal FuelCapacity => AllBatallions().Sum(b => b.FuelCapacity);
        public decimal FuelUsage => AllBatallions().Sum(b => b.FuelUsage);

        /// <summary>
        /// The amount of Infantry equipment required by this division
        /// </summary>
        public decimal InfantryEquipment => AllBatallions().Sum(b => b.InfantryEquipment);
        /// <summary>
        /// The amount of Artillery equipment required by this division
        /// </summary>
        public decimal Artillery => AllBatallions().Sum(b => b.Artillery);
        /// <summary>
        /// The amount of Anti-Air equipment required by this division
        /// </summary>
        public decimal AntiAir => AllBatallions().Sum(b => b.AntiAir);

        public decimal ProductionCost => AllBatallions().Sum(b => b.ProductionCost);

    }
}
