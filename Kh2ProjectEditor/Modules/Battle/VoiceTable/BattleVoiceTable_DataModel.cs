using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.VoiceTable
{
    internal class BattleVoiceTable_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleVoiceTable_Wrapper> LoadedEntries { get; set; }

        public BattleVoiceTable_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleVoiceTable_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.VtblFile);
        }

        public void LoadData(VoiceTableFile vtblFile)
        {
            LoadedEntries.Clear();
            foreach (VoiceTableFile.Entry entry in vtblFile.Entries)
            {
                LoadedEntries.Add(new BattleVoiceTable_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.VtblFile.Entries.Clear();
            foreach (BattleVoiceTable_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.VtblFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("vtbl");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
