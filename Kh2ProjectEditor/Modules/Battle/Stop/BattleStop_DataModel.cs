using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.Stop
{
    internal class BattleStop_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleStop_Wrapper> LoadedEntries { get; set; }

        public BattleStop_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleStop_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.StopFile);
        }

        public void LoadData(StopFile stopFile)
        {
            LoadedEntries.Clear();
            foreach (StopFile.Entry entry in stopFile.Entries)
            {
                LoadedEntries.Add(new BattleStop_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.StopFile.Entries.Clear();
            foreach (BattleStop_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.StopFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("stop");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
