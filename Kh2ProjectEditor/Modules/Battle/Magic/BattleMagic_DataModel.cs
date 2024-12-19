using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Battle;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Battle.Magic
{
    internal class BattleMagic_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleMagic_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public BattleMagic_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleMagic_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.MagcFile);
        }

        public void LoadData(MagicFile magcFile)
        {
            LoadedEntries.Clear();
            foreach (MagicFile.Entry entry in magcFile.Entries)
            {
                LoadedEntries.Add(new BattleMagic_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.MagcFile.Entries.Clear();
            foreach (BattleMagic_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.MagcFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("magc");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
