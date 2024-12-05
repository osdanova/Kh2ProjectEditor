using Kh2ProjectEditor.Utils;
using KhLib.Kh2.System;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.System.Items
{
    internal class SystemItemsType_Converter : BaseEnumStringConverter<ItemsFile.Type>
    {
        public SystemItemsType_Converter()
        {
            Options = new Dictionary<ItemsFile.Type, string>
            {
                {ItemsFile.Type.Consumable, "[0] Consumable"},
                {ItemsFile.Type.Boost, "[1] Boost"},
                {ItemsFile.Type.Keyblade, "[2] Keyblade"},
                {ItemsFile.Type.Staff, "[3] Staff"},
                {ItemsFile.Type.Shield, "[4] Shield"},
                {ItemsFile.Type.PingWeapon, "[5] Weapon - Ping"},
                {ItemsFile.Type.AuronWeapon, "[6] Weapon - Auron"},
                {ItemsFile.Type.BeastWeapon, "[7] Weapon - Beast"},
                {ItemsFile.Type.JackWeapon, "[8] Weapon - Jack Skellington"},
                {ItemsFile.Type.DummyWeapon, "[9] Weapon - Dummy"},
                {ItemsFile.Type.RikuWeapon, "[10] Weapon - Riku"},
                {ItemsFile.Type.SimbaWeapon, "[11] Weapon - Simba"},
                {ItemsFile.Type.JackSparrowWeapon, "[12] Weapon - Jack Sparrow"},
                {ItemsFile.Type.TronWeapon, "[13] Weapon - Tron"},
                {ItemsFile.Type.Armor, "[14] Armor"},
                {ItemsFile.Type.Accessory, "[15] Accessory"},
                {ItemsFile.Type.Synthesis, "[16] Synthesis"},
                {ItemsFile.Type.Recipe, "[17] Recipe"},
                {ItemsFile.Type.Magic, "[18] Magic"},
                {ItemsFile.Type.Ability, "[19] Ability"},
                {ItemsFile.Type.Summon, "[20] Summon"},
                {ItemsFile.Type.Form, "[21] Form"},
                {ItemsFile.Type.Map, "[22] Map"},
                {ItemsFile.Type.Report, "[23] Report"}
            };
        }
    }
}
