using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.LevelParams
{
    internal class BattleLevelParams_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleLevelParams_Wrapper> LoadedEntries { get; set; }

        public BattleLevelParams_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleLevelParams_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.LvpmFile);
        }

        public void LoadData(LevelParamsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (LevelParamsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new BattleLevelParams_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.LvpmFile.Entries.Clear();
            foreach (BattleLevelParams_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.LvpmFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("lvpm");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
