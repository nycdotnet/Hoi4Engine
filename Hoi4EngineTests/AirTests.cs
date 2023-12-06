using FluentAssertions;
using Hoi4Engine.Air;

namespace Hoi4EngineTests
{
    public class AirTests
    {
        [Fact]
        public void SimplestInterWarFighterHasExpectedStats()
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
            sut.SupplyUse.Should().Be(0.28m);
            sut.Weight.Should().Be(4.5m);
            sut.Thrust.Should().Be(11);
        }

        [Fact]
        public void SimplestBasicFighterHasExpectedStats()
        {
            var sut = new AirframeDesign
            {
                Airframe = new BasicSmall
                {
                    Engine = new() { Kind = EngineKind.PistonI, Count = 1 },
                    MainArmamentSlot = new LightMachineGunx2()
                }
            };

            sut.MaxSpeed.Should().Be(425);
            sut.Range.Should().Be(550);
            sut.AirAttack.Should().Be(4);
            sut.SupplyUse.Should().Be(0.28m);
            sut.Weight.Should().Be(6.5m);
            sut.Thrust.Should().Be(11);
        }
    }
}
