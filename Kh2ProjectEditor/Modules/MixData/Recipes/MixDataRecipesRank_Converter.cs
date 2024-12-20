using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Mixdata.RecipesFile;

namespace Kh2ProjectEditor.Modules.MixData.Recipes
{
    internal class MixDataRecipesRank_Converter : BaseEnumStringConverter<Rank>
    {
        public MixDataRecipesRank_Converter()
        {
            Options = new Dictionary<Rank, string>
            {
                {Rank.C, "C" },
                {Rank.B, "B" },
                {Rank.A, "A" },
                {Rank.S, "S" },
            };
        }
    }
}
