
namespace Hoi4Engine.Air
{
    public class InterWarSmall : Airframe
    {
        required public Armament MainArmamentSlot { get; set; }

        public override IEnumerable<Armament> Armaments => [MainArmamentSlot];

        public override int BaseSpeed => Engine switch
        {
            { Kind: EngineKind.PistonI } => 400,
            { Kind: EngineKind.PistonII } => 480,
            { Kind: EngineKind.PistonIII } => 520,
            { Kind: EngineKind.PistonIV } => 580,
            _ => throw new NotImplementedException("This engine kind or count is not yet implemented")
        };

        public override int BaseRange => 400;
    }
}
