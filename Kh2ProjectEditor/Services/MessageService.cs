using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.OpenKh.Msg;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kh2ProjectEditor.Services
{
    public class MessageService : SingletonBase<MessageService>
    {
        /******************************************
         * STATE
         ******************************************/
        private InternationalSystemDecode Decoder { get; set; }
        private Dictionary<int, byte[]> MsgEntries { get; set; }
        //private static long _MsgSysGlobalPointer { get; set; }

        public MessageService()
        {
            Decoder = new InternationalSystemDecode();
            MsgEntries = new Dictionary<int, byte[]>();
        }

        /******************************************
         * Public functions
         ******************************************/
        // Returns the message by Id
        public string GetEntryText(int entryId)
        {
            try
            {
                // Mask byte
                int msgId = entryId > 0x8000 ? entryId - 0x8000 : entryId;
                List<MessageCommandModel> decodedEntries = Decoder.Decode(MsgEntries[msgId]);
                foreach (MessageCommandModel messageModel in decodedEntries)
                {
                    if (messageModel.Command == MessageCommand.PrintText)
                        return messageModel.Text;
                }
                return "<NOT_FOUND>";
            }
            catch (Exception exc)
            {
                return "<ERROR>";
            }
        }

        // Loads the entries from the current project
        // Currently only built for HD US
        public void LoadFromProject()
        {
            if (!ProjectService.Instance.MsgSysUsExists)
            {
                throw new Exception("[MessageService] Attempted to load messages from unloaded project");
            }

            byte[] sysFile = ProjectService.Instance.GetMsgSysUs();
            BinaryArchive sysBar = BinaryArchive.Read(sysFile);
            foreach (BinaryArchive.Entry entry in sysBar.Entries)
            {
                if (entry.Name == "sys\0")
                {
                    LoadEntries(entry.File);
                    return;
                }
            }
            throw new Exception("[MessageService] MSG file doesn't contain sys subfile");
        }

        /******************************************
         * Private functions
         ******************************************/

        // Loads the entries from the given file
        private void LoadEntries(byte[] msgSysFile)
        {
            List<Msg.Entry> Entries;
            using (MemoryStream stream = new MemoryStream(msgSysFile))
            {
                Entries = Msg.Read(stream);
            }

            MsgEntries.Clear();
            foreach (Msg.Entry entry in Entries)
            {
                MsgEntries.Add(entry.Id, entry.Data);
            }
        }

        //public static void LoadFromGame()
        //{
        //    if (MsgEntries != null || ProcessService.ThisProcess == null)
        //    {
        //        return;
        //    }
        //
        //    try
        //    {
        //        _MsgSysGlobalPointer = MemoryAccess.readLong(ProcessService.ThisProcess, Kh2Pointers.EGS_FileSysMsg_Pointer);
        //        int MsgSize = MemoryAccess.readInt(ProcessService.ThisProcess, _MsgSysGlobalPointer + 0x1C, true);
        //        byte[] MsgSysData = MemoryAccess.readMemory(ProcessService.ThisProcess, _MsgSysGlobalPointer + 0x30, MsgSize, true);
        //
        //        List<Msg.Entry> Entries;
        //        using (MemoryStream stream = new MemoryStream(MsgSysData))
        //        {
        //            Entries = Msg.Read(stream);
        //        }
        //        MsgEntries = new Dictionary<int, byte[]>();
        //        foreach (Msg.Entry entry in Entries)
        //        {
        //            MsgEntries.Add(entry.Id, entry.Data);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //
        //    }
        //}
    }
}
