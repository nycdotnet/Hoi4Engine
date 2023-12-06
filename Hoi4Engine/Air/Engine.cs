namespace Hoi4Engine.Air
{
    public record Engine
    {
        public EngineKind Kind { get; set; }
        public int Count { get; set; }
        public decimal Thrust => this switch
        {
            { Kind: EngineKind.PistonI, Count: 1 } => 11,
            _ => throw new NotImplementedException("This engine kind or count is not yet implemented")
        };
    }
}
