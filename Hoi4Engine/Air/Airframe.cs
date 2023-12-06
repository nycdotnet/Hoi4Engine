namespace Hoi4Engine.Air
{
    public abstract class Airframe
    {
        required public Engine Engine { get; set; }
        public abstract IEnumerable<Armament> Armaments { get; }
        /// <summary>
        /// Speed in km/hr for combination of airframe and engine(s)
        /// </summary>
        public abstract int BaseSpeed { get; }
        /// <summary>
        /// in km
        /// </summary>
        public abstract int BaseRange { get; }
    }
}
