using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Mixdata.RecipesFile;

namespace Kh2ProjectEditor.Modules.MixData.Recipes
{
    internal class MixDataRecipesType_Converter : BaseEnumStringConverter<UnlockType>
    {
        public MixDataRecipesType_Converter()
        {
            Options = new Dictionary<UnlockType, string>
            {
                {UnlockType.Recipe, "Recipe" },
                {UnlockType.FreeDev1, "Free Dev. 1" },
                {UnlockType.FreeDev2, "Free Dev. 2" },
                {UnlockType.FreeDev3, "Free Dev. 3" },
            };
        }
    }
}
