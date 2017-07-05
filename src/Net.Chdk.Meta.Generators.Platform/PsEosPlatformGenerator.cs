using System.Collections.Generic;
using System.Linq;

namespace Net.Chdk.Meta.Generators.Platform
{
    sealed class PsEosPlatformGenerator : InnerPlatformGeneratorBase
    {
        protected override IEnumerable<string> Process(IEnumerable<string> split)
        {
            if (split.Contains("Rebel") != false)
                return null;

            return split;
        }

        protected override string Keyword => "EOS";
    }
}
