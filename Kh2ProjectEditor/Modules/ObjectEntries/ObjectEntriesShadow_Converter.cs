using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.ObjectEntryFile;

namespace Kh2ProjectEditor.Modules.ObjectEntries
{
    public class ObjectEntriesShadow_Converter : BaseEnumStringConverter<ShadowSize>
    {
        public ObjectEntriesShadow_Converter()
        {
            Options = new Dictionary<ShadowSize, string>
            {
                {ShadowSize.NoShadow, "[0] -"},
                {ShadowSize.SmallShadow, "[1] Small"},
                {ShadowSize.MiddleShadow, "[2] Middle"},
                {ShadowSize.LargeShadow, "[3] Large"},
                {ShadowSize.SmallMovingShadow, "[4] Small Moving"},
                {ShadowSize.MiddleMovingShadow, "[5] Middle Moving"},
                {ShadowSize.LargeMovingShadow, "[6] Large Moving"}
            };
        }
    }
}
