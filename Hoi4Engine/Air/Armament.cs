namespace Hoi4Engine.Air
{
    public abstract class Armament : IAirModule
    {
        public abstract int AirAttack { get; }
        public abstract decimal Weight { get; }
    }
}
