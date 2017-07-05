using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Net.Chdk.Meta.Generators.Platform
{
    public abstract class PowerShotPlatformGenerator : InnerPlatformGeneratorBase
    {
        protected override string Keyword => "PowerShot";

        protected override string[] Suffixes => new[] { "IS" };

        protected override IEnumerable<string> Trim(IEnumerable<string> split)
        {
            Debug.Assert(split.Last().Equals("IS"));

            var split2 = split.Take(split.Count() - 1);
            var beforeLast = split2.Last();
            var index = GetIndexOfDigit(beforeLast);
            var series = beforeLast.Substring(0, index);
            var modelStr = beforeLast.Substring(index);
            uint model = uint.Parse(modelStr);
            switch (series)
            {
                case "": // ELPH
                case "A":
                case "SD":
                case "SX" when model < 100:
                    return split2;
                default:
                    return split;
            }
        }

        protected override IEnumerable<string> Process(IEnumerable<string> split)
        {
            if (split.Count() >= 2 && split.Skip(1).First() == "Facebook")
                return new[] { "N_Facebook" };
            return split;
        }

        private static int GetIndexOfDigit(string value)
        {
            for (int i = 0; i < value.Length; i++)
                if (char.IsDigit(value[i]))
                    return i;
            return -1;
        }
    }
}
