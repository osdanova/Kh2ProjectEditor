using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.ObjectEntryFile;

namespace Kh2ProjectEditor.Modules.ObjectEntries
{
    public class ObjectEntriesType_Converter : BaseEnumStringConverter<EntryType>
    {
        public ObjectEntriesType_Converter()
        {
            Options = new Dictionary<EntryType, string>
            {
                {EntryType.PLAYER, "[0] Player"},
                {EntryType.FRIEND, "[1] Friend"},
                {EntryType.NPC, "[2] NPC"},
                {EntryType.BOSS, "[3] Boss"},
                {EntryType.ZAKO, "[4] Enemy"},
                {EntryType.WEAPON, "[5] Weapon"},
                {EntryType.E_WEAPON, "[6] Weapon (E)"},
                {EntryType.SP, "[7] Savepoint"},
                {EntryType.F_OBJ, "[8] Field Object"},
                {EntryType.BTLNPC, "[9] NPC (Battle)"},
                {EntryType.TREASURE, "[10] Treasure"},
                {EntryType.SUBMENU, "[11] Submenu"},
                {EntryType.L_BOSS, "[12] Boss (Large)"},
                {EntryType.G_OBJ, "[13] G Object"},
                {EntryType.MEMO, "[14] Memo"},
                {EntryType.RTN, "[15] NPC (Reaction)"},
                {EntryType.MINIGAME, "[16] Minigame"},
                {EntryType.WORLDMAP, "[17] Worldmap"},
                {EntryType.PRIZEBOX, "[18] Prizebox"},
                {EntryType.SHOP, "[20] Shop"},
                {EntryType.L_ZAKO, "[21] Enemy (Large)"},
                {EntryType.MASSEFFECT, "[22] Mass Effect"},
                {EntryType.E_OBJ, "[23] Object (Event)"},
                {EntryType.JIGSAW, "[24] Jigsaw"}
            };
        }
    }
}
