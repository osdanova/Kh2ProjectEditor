using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.Tools.BarEditor
{
    internal partial class BarEditorMotionsetType_Converter : BaseEnumStringConverter<BinaryArchive.MotionsetType>
    {
        public BarEditorMotionsetType_Converter()
        {
            Options = new Dictionary<BinaryArchive.MotionsetType, string>
            {
                {BinaryArchive.MotionsetType.Default, "[0] -" },
                {BinaryArchive.MotionsetType.Player, "[1] Player" },
                {BinaryArchive.MotionsetType.Raw, "[2] Raw" }
            };
        }
    }
}
