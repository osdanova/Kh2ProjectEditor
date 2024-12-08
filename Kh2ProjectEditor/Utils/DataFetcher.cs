using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2;
using KhLib.Kh2.KhSystem;
using Kh2ProjectEditor.Services;

namespace Kh2ProjectEditor.Utils
{
    public class DataFetcher
    {
        public static string GetObjectDescription(uint objId)
        {
            if(objId == 0)
            {
                return "";
            }

            foreach (ObjectEntryFile.Entry entry in FileObjentry_Service.Instance.ObjentryFile.Entries)
            {
                if (entry.Id == objId)
                {
                    return Objects_Dictionary.Instance[entry.ModelName];
                }
            }

            return "<NOT_FOUND>";
        }

        public static string GetProgressFlagDescription(ushort flagId)
        {
            return (flagId == 0) ? "" : ProgressFlags_Dictionary.Instance[flagId];
        }

        public static string GetCommandMessage(ushort commandId)
        {
            foreach (CommandsFile.Entry entry in FileSystem_Service.Instance.CmdFile.Entries)
            {
                if (entry.Id == commandId)
                {
                    return MessageService.Instance.GetEntryText(entry.MessageId);
                }
            }
            return "<NOT_FOUND>";
        }

        public static string GetItemName(ushort itemId)
        {
            if (itemId == 0)
            {
                return "";
            }

            foreach (ItemsFile.Entry entry in FileSystem_Service.Instance.ItemFile.Items)
            {
                if (entry.Id == itemId)
                {
                    return MessageService.Instance.GetEntryText(entry.NameId);
                }
            }
            return "<NOT_FOUND>";
        }

        public static string GetWorldRoomName(byte world, byte room)
        {
            int roomId = world * 1000 + room;
            return (!WorldRooms_Dictionary.Instance.ContainsKey(roomId)) ? "<NOT_FOUND>" : WorldRooms_Dictionary.Instance[roomId];
        }

        public static string GetCharacterName(ushort entryId)
        {
            return (!Characters_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : Characters_Dictionary.Instance[entryId];
        }

        public static string GetPlayerName(ushort entryId)
        {
            return (!Players_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : Players_Dictionary.Instance[entryId];
        }

        public static string GetMenuFlagName(byte entryId) => (!MenuFlags_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : MenuFlags_Dictionary.Instance[entryId];
        public static string GetSignalName(byte entryId) => (!Signals_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : Signals_Dictionary.Instance[entryId];
        public static string GetBonusLevelName(byte entryId) => (!BonusLevels_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : BonusLevels_Dictionary.Instance[entryId];
    }
}
