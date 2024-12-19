using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.OpenKh.Msg;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kh2ProjectEditor.Services
{
    public class Message_Service : SingletonBase<Message_Service>
    {
        private static string DEFAULT_LANGUAGE = "us";
        /******************************************
         * STATE
         ******************************************/
        public string SelectedLanguage { get; set; }
        public List<string> AvailableLanguages { get; set; }
        private InternationalSystemDecode _Decoder { get; set; }
        private Dictionary<int, byte[]> _SysEntries { get; set; }
        private Dictionary<int, byte[]> _JmEntries { get; set; }
        //private static long _MsgSysGlobalPointer { get; set; }

        public Message_Service()
        {
            AvailableLanguages = new List<string>();
            _Decoder = new InternationalSystemDecode();
            _SysEntries = new Dictionary<int, byte[]>();
            _JmEntries = new Dictionary<int, byte[]>();
        }

        /******************************************
         * Public functions
         ******************************************/
        // Returns the message by Id
        public string GetSysText(int entryId)
        {
            if(_SysEntries == null || _SysEntries.Count == 0)
            {
                return "<NOT_LOADED>";
            }
            return FetchEntry(_SysEntries, entryId);
        }
        public string GetJmText(int entryId)
        {
            if (_JmEntries == null || _JmEntries.Count == 0)
            {
                return "<NOT_LOADED>";
            }
            return FetchEntry(_JmEntries, entryId);
        }

        // Loads the current project
        public void LoadFromProject()
        {
            string pathMsg = Path.Combine([ProjectService.Instance.ProjectPath, "msg"]);
            if (!Directory.Exists(pathMsg))
            {
                return;
            }

            AvailableLanguages.Clear();
            SelectedLanguage = "";
            foreach (string directory in Directory.GetDirectories(pathMsg))
            {
                string language = Path.GetFileName(directory);
                AvailableLanguages.Add(language);

                // Set to first and default to US if it exists
                if(SelectedLanguage == "" || language == DEFAULT_LANGUAGE) {
                    SelectedLanguage = language;
                }
            }

            LoadFilesFromProject();
        }

        public void SetLanguage(string language)
        {
            if (!AvailableLanguages.Contains(language))
            {
                throw new Exception("[Message_Service] Language not available!");
            }

            SelectedLanguage = language;
            LoadFilesFromProject();
        }

        /******************************************
         * Private functions
         ******************************************/

        // Loads the msg files from project
        private void LoadFilesFromProject()
        {
            string pathMsg = Path.Combine([ProjectService.Instance.ProjectPath, "msg"]);

            _SysEntries.Clear();
            string MsgSystemPath = Path.Combine([pathMsg, SelectedLanguage, "sys.bar"]);
            if (File.Exists(MsgSystemPath))
            {
                byte[] sysFile = File.ReadAllBytes(MsgSystemPath);
                BinaryArchive sysBar = BinaryArchive.Read(sysFile);
                LoadSysEntries(sysBar.GetFirstByName("sys\0").File);
            }

            _JmEntries.Clear();
            string MsgJiminyPath = Path.Combine([pathMsg, SelectedLanguage, "jm.bar"]);
            if (File.Exists(MsgJiminyPath))
            {
                byte[] jmFile = File.ReadAllBytes(MsgJiminyPath);
                BinaryArchive jmBar = BinaryArchive.Read(jmFile);
                LoadJmEntries(jmBar.GetFirstByName("jm\0\0").File);
            }
        }

        private string FetchEntry(Dictionary<int, byte[]> entries, int entryId)
        {
            if(entryId == 0)
            {
                return "";
            }

            try
            {
                // Mask byte
                int msgId = entryId > 0x8000 ? entryId - 0x8000 : entryId;
                List<MessageCommandModel> decodedEntries = _Decoder.Decode(entries[msgId]);
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

        // Loads the entries from the given file
        private void LoadSysEntries(byte[] msgSysFile)
        {
            List<Msg.Entry> Entries;
            using (MemoryStream stream = new MemoryStream(msgSysFile))
            {
                Entries = Msg.Read(stream);
            }

            _SysEntries.Clear();
            foreach (Msg.Entry entry in Entries)
            {
                _SysEntries.Add(entry.Id, entry.Data);
            }
        }
        // Loads the entries from the given file
        private void LoadJmEntries(byte[] msgJmFile)
        {
            List<Msg.Entry> Entries;
            using (MemoryStream stream = new MemoryStream(msgJmFile))
            {
                Entries = Msg.Read(stream);
            }

            _JmEntries.Clear();
            foreach (Msg.Entry entry in Entries)
            {
                _JmEntries.Add(entry.Id, entry.Data);
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
