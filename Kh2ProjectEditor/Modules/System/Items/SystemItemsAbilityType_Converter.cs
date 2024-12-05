using Kh2ProjectEditor.Utils;
using KhLib.Kh2.System;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.System.Items
{
    internal class SystemItemsAbilityType_Converter : BaseEnumStringConverter<ItemsFile.AbilityType>
    {
        public SystemItemsAbilityType_Converter()
        {
            Options = new Dictionary<ItemsFile.AbilityType, string>
            {
                {ItemsFile.AbilityType.Support, "[0] Support"},
                {ItemsFile.AbilityType.Limit, "[1] Limit"},
                {ItemsFile.AbilityType.Action, "[2] Action"},
                {ItemsFile.AbilityType.Growth, "[3] Growth"},
            };
        }
    }
}
