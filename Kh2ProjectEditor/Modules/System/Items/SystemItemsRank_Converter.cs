using Kh2ProjectEditor.Utils;
using KhLib.Kh2.System;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.System.Items
{
    internal class SystemItemsRank_Converter : BaseEnumStringConverter<ItemsFile.Rank>
    {
        public SystemItemsRank_Converter()
        {
            Options = new Dictionary<ItemsFile.Rank, string>
            {
                {ItemsFile.Rank.C, "[0] C"},
                {ItemsFile.Rank.B, "[1] B"},
                {ItemsFile.Rank.A, "[2] A"},
                {ItemsFile.Rank.S, "[3] S"},
            };
        }
    }
}
