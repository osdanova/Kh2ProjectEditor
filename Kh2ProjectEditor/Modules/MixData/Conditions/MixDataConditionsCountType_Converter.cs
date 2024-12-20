using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Mixdata.ConditionsFile;

namespace Kh2ProjectEditor.Modules.MixData.Conditions
{
    internal class MixDataConditionsCountType_Converter : BaseEnumStringConverter<CountType>
    {
        public MixDataConditionsCountType_Converter()
        {
            Options = new Dictionary<CountType, string>
            {
                {CountType.Stack, "Stack" },
                {CountType.Collect, "Collect" },
            };
        }
    }
}
