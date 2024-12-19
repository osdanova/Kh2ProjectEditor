using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.BonusLevels
{
    internal class BattleBonusLevels_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleBonusLevelsEntry_Wrapper> LoadedEntries { get; set; }

        public BattleBonusLevels_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleBonusLevelsEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.BonsFile);
        }

        public void LoadData(BonusLevelsFile bonsFile)
        {
            LoadedEntries.Clear();
            foreach (BonusLevelsFile.Entry entry in bonsFile.Entries)
            {
                LoadedEntries.Add(new BattleBonusLevelsEntry_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.BonsFile.Entries.Clear();
            foreach (BattleBonusLevelsEntry_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.BonsFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("bons");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
