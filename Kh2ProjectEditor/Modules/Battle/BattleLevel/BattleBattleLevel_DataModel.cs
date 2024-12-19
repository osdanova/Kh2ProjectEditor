using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.BattleLevel
{
    internal class BattleBattleLevel_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleBattleLevel_Wrapper> LoadedEntries { get; set; }

        public BattleBattleLevel_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleBattleLevel_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.BtlvFile);
        }

        public void LoadData(BattleLevelFile khFile)
        {
            LoadedEntries.Clear();
            foreach (BattleLevelFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new BattleBattleLevel_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.BtlvFile.Entries.Clear();
            foreach (BattleBattleLevel_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.BtlvFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("btlv");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
