using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.KhSystem.ItemsFile;

namespace Kh2ProjectEditor.Modules.KhSystem.Items
{
    internal class SystemItemsPrizebox_Converter : BaseEnumStringConverter<PrizeboxType>
    {
        public SystemItemsPrizebox_Converter()
        {
            Options = new Dictionary<PrizeboxType, string>
            {
                {PrizeboxType.RedS, "[0] Red S" },
                {PrizeboxType.RedL, "[1] Red L" },
                {PrizeboxType.RedXL, "[2] Red XL" },
                {PrizeboxType.BlueS, "[3] Blue S" },
                {PrizeboxType.BlueL, "[4] Blue L" },
                {PrizeboxType.BlueXL, "[5] Blue XL" },
                {PrizeboxType.HornedS, "[6] Horned S" },
                {PrizeboxType.HornedL, "[7] Horned L" },
                {PrizeboxType.HornedXL, "[8] Horned XL" },
                {PrizeboxType.PurpleS, "[9] Purple S" },
                {PrizeboxType.PurpleL, "[10] Purple L" },
                {PrizeboxType.PurpleXL, "[11] Purple XL" }
            };
        }
    }
}
