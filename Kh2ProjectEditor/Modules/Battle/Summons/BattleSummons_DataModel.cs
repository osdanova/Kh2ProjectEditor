using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Battle.Summons
{
    internal class BattleSummons_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleSummons_Wrapper> LoadedEntries { get; set; }

        public BattleSummons_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleSummons_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.SumnFile);
        }

        public void LoadData(SummonsFile sumnFile)
        {
            LoadedEntries.Clear();
            foreach (SummonsFile.Entry entry in sumnFile.Entries)
            {
                LoadedEntries.Add(new BattleSummons_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.SumnFile.Entries.Clear();
            foreach (BattleSummons_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.SumnFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("sumn");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
