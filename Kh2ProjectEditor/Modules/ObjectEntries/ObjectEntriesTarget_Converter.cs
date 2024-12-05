using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.ObjectEntryFile;

namespace Kh2ProjectEditor.Modules.ObjectEntries
{
    public class ObjectEntriesTarget_Converter : BaseEnumStringConverter<TargetType>
    {
        public ObjectEntriesTarget_Converter()
        {
            Options = new Dictionary<TargetType, string>
            {
                {TargetType.M, "[0] -"},
                {TargetType.S, "[1] Small"},
                {TargetType.L, "[2] Large"}
            };
        }
    }
}
