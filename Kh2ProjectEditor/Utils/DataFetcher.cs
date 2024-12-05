using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2;
using KhLib.Kh2.System;
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
    }
}
