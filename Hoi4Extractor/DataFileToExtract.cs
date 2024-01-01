using System;

namespace Hoi4Extractor;

public partial class Hoi4DataFileExtractingSourceGenerator
{
    private record DataFileToExtract
    {
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string RelativePath { get; set; }
        public Type Type { get; set; }
    }
}
