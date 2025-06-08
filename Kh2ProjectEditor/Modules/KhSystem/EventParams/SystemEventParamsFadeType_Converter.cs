using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.KhSystem.EventTypeFile;

namespace Kh2ProjectEditor.Modules.KhSystem.EventParams
{
    internal class SystemEventParamsFadeType_Converter : BaseEnumStringConverter<FadeType>
    {
        public SystemEventParamsFadeType_Converter()
        {
            Options = new Dictionary<FadeType, string>
            {
                {FadeType.None, "[0] -"},
                {FadeType.Black, "[1] Black"},
                {FadeType.White, "[2] White"},
                {FadeType.Keyhole, "[3] Keyhole"}
            };
        }
    }
}
