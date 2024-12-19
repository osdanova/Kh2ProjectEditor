using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.PlayerParams
{
    internal partial class BattlePlayerParams_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattlePlayerParams_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showStats;
        [ObservableProperty] public bool showSlots;
        [ObservableProperty] public bool showInventory;

        public BattlePlayerParams_DataModel()
        {
            showStats = true;
            LoadedEntries = new ObservableCollection<BattlePlayerParams_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.PlrpFile);
        }

        public void LoadData(PlayerParamsFile plrpFile)
        {
            LoadedEntries.Clear();
            foreach (PlayerParamsFile.Entry entry in plrpFile.Entries)
            {
                LoadedEntries.Add(new BattlePlayerParams_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.PlrpFile.Entries.Clear();
            foreach (BattlePlayerParams_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.PlrpFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("plrp");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
