
namespace Hoi4Engine.Air
{
    public class BasicSmall : Airframe
    {
        required public Armament MainArmamentSlot { get; set; }

        public override IEnumerable<Armament> Armaments => [MainArmamentSlot];
        public override IEnumerable<IAirModule> Modules => [MainArmamentSlot];

        public override int BaseSpeed => Engine switch
        {
            { Kind: EngineKind.PistonI } => 425,
            { Kind: EngineKind.PistonII } => 510,
            { Kind: EngineKind.PistonIII } => 520,
            { Kind: EngineKind.PistonIV } => 580,
            _ => throw new NotImplementedException("This engine kind or count is not yet implemented")
        };

        public override int BaseRange => 550;

        /// <summary>
        /// Note: Supply use doesn't seem to change when changing weapons, engines, or going from interwar to basic or even small to medium.
        /// Haven't tested past that
        /// </summary>
        public override decimal SupplyUse => 0.28m;

        public override decimal BaseWeight => 5;
    }
}
