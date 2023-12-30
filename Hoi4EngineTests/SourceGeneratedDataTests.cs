using FluentAssertions;
using Hoi4Data.common.units;

namespace Hoi4EngineTests
{
    public class SourceGeneratedDataTests
    {
        [Fact]
        public void SourceGeneratedDataFilesHavePropertyThatMatchesAttribute()
        {
            Cavalry.RelativePath.Should().Be("common/units/cavalry.txt");
            Infantry.RelativePath.Should().Be("common/units/infantry.txt");
        }
    }
}
