using FluentAssertions;
using Hoi4Engine.Air;

namespace Hoi4EngineTests
{
    public class AirTests
    {
        [Fact]
        public void InterWarFighterHasExpectedStats()
        {
            var sut = new AirframeDesign
            {
                Airframe = new InterWarSmall
                {
                    Engine = new() { Kind = EngineKind.PistonI, Count = 1 },
                    MainArmamentSlot = new LightMachineGunx2()
                }
            };

            sut.MaxSpeed.Should().Be(400);
            sut.Range.Should().Be(400);
            sut.AirAttack.Should().Be(4);
        }
    }
}
