using System;

namespace Hoi4Extractor
{
    /// <summary>
    /// Classes marked this attribute that are both that <c>public</c> and <c>partial</c> will gain
    /// source generated properties if the relevant file is found.
    /// </summary>
    /// <param name="RelativePath">The relative path to the text file from the HOI4 root
    /// such as <c>common/units/cavalry.txt</c> (using Unix path separators)</param>
    public class Hoi4DataFileAttribute(string RelativePath) : Attribute
    {
        /// <summary>
        /// The relative path to the text file from the HOI4 root using Unix path separators.
        /// </summary>
        public string RelativePath { get; } = RelativePath;
    }
}
