using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Mixdata.ConditionsFile;

namespace Kh2ProjectEditor.Modules.MixData.Conditions
{
    internal class MixDataConditionsRewardType_Converter : BaseEnumStringConverter<RewardType>
    {
        public MixDataConditionsRewardType_Converter()
        {
            Options = new Dictionary<RewardType, string>
            {
                {RewardType.Item, "Item" },
                {RewardType.Upgrade, "Upgrade" },
            };
        }
    }
}
