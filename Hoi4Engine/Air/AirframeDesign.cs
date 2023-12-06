﻿namespace Hoi4Engine.Air
{
    public class AirframeDesign
    {
        public required Airframe Airframe { get; set; }
        public int AirAttack => Airframe.Armaments.Sum(a => a.AirAttack);
        /// <summary>
        /// In km/hr
        /// </summary>
        public int MaxSpeed => Airframe.BaseSpeed;
        /// <summary>
        /// In km
        /// </summary>
        public int Range => Airframe.BaseRange;
    }
}
