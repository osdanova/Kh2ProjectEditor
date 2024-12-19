using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Battle.Limits
{
    internal class BattleLimits_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleLimits_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public BattleLimits_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleLimits_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.LimtFile);
        }

        public void LoadData(LimitsFile limtFile)
        {
            LoadedEntries.Clear();
            foreach (LimitsFile.Entry entry in limtFile.Entries)
            {
                LoadedEntries.Add(new BattleLimits_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.LimtFile.Entries.Clear();
            foreach (BattleLimits_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.LimtFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("limt");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
