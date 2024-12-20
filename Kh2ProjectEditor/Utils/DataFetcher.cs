using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.KhSystem;
using System;

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
            if (commandId == 609)
                return "<Genie Limit>";

            foreach (CommandsFile.Entry entry in FileSystem_Service.Instance.CmdFile.Entries)
            {
                if (entry.Id == commandId)
                {
                    return Message_Service.Instance.GetSysText(entry.MessageId);
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
                    return Message_Service.Instance.GetSysText(entry.NameId);
                }
            }
            return "<NOT_FOUND>";
        }

        public static string GetAbilityName(ushort abilityId)
        {
            if (abilityId == 0)
            {
                return "";
            }

            foreach (ItemsFile.Entry entry in FileSystem_Service.Instance.ItemFile.Items)
            {
                if (entry.Type == ItemsFile.Type.Ability &&
                    entry.AbilityId == abilityId && 
                    entry.Id != 248 && // Dummy
                    entry.Id != 249 && // Upper Dummy
                    entry.Id != 521 // Combo Upper
                    )
                {
                    return Message_Service.Instance.GetSysText(entry.NameId);
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
        public static string GetBonusEventName(byte entryId)
        {
            return (!BonusLevels_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : BonusLevels_Dictionary.Instance[entryId];
        }
        public static string GetBonusEventDesc(byte entryId)
        {
            return (!BonusLevelsDesc_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : BonusLevelsDesc_Dictionary.Instance[entryId];
        }

        public static string GetMenuFlagName(sbyte entryId)
        {
            if (entryId == -1)
            {
                return "-";
            }
            return (!MenuFlags_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : MenuFlags_Dictionary.Instance[entryId];
        }
        public static string GetSignalName(byte entryId) => (!Signals_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : Signals_Dictionary.Instance[entryId];
        public static string GetBonusLevelName(byte entryId) => (!BonusLevels_Dictionary.Instance.ContainsKey(entryId)) ? "<NOT_FOUND>" : BonusLevels_Dictionary.Instance[entryId];

        public static string GetAttackParamDesc(ushort id, ushort version)
        {
            return (!AttackParamDesc_Dictionary.Instance.ContainsKey((id,version))) ? "" : AttackParamDesc_Dictionary.Instance[(id, version)];
        }
        public static string GetMotionName(short motionId)
        {
            if(motionId == -1)
            {
                return "-";
            }
            return (!Enum.IsDefined(typeof(Motion_Enum), (Motion_Enum)motionId)) ? "<NOT_FOUND>" : ((Motion_Enum)motionId).ToString();
        }
    }
}
