using System;

namespace Hoi4Extractor
{
    /// <summary>
    /// Classes with this attribute will have source generated properties 
    /// </summary>
    /// <param name="relativePath">The relative path to the text file from the HOI4 root
    /// such as <c>common/units/cavalry.txt</c> (using Unix path separators)</param>
    public class Hoi4DataFileAttribute(string relativePath) : Attribute
    {
        /// <summary>
        /// The relative path to the text file from the HOI4 root using Unix path separators.
        /// </summary>
        public string RelativePath => relativePath;
    }
}
