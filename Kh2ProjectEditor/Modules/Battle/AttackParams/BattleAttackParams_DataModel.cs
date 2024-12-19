using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2;
using KhLib.Kh2.Battle;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal partial class BattleAttackParams_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<BattleAttackParamsEntry_Wrapper> LoadedEntries { get; set; }
        internal ObservableCollection<BattleAttackParamsEntry_Wrapper> DisplayEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        //[ObservableProperty] public bool showBasic;
        [ObservableProperty] public string filterText;
        public List<string> EntryTypeOptions => new BattleAttackParamsType_Converter().Options.Values.ToList();
        public List<string> EntryTeamOptions => new BattleAttackParamsTeam_Converter().Options.Values.ToList();
        public List<string> EntryElementOptions => new BattleAttackParamsElement_Converter().Options.Values.ToList();
        public List<string> EntryRefactOptions => new BattleAttackParamsRefact_Converter().Options.Values.ToList();
        public List<string> EntryTrReactionOptions => new BattleAttackParamsTrReaction_Converter().Options.Values.ToList();
        public List<string> EntryKindOptions => new BattleAttackParamsKind_Converter().Options.Values.ToList();

        public BattleAttackParams_DataModel()
        {
            LoadedEntries = new ObservableCollection<BattleAttackParamsEntry_Wrapper>();
            DisplayEntries = new ObservableCollection<BattleAttackParamsEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            LoadData(FileBattle_Service.Instance.AtkpFile);
        }

        public void LoadData(AttackParamsFile atkpFile)
        {
            LoadedEntries.Clear();
            foreach (AttackParamsFile.Entry entry in atkpFile.Entries)
            {
                LoadedEntries.Add(new BattleAttackParamsEntry_Wrapper(entry));
            }
            ApplyFilters();
        }
        public void ApplyFilters()
        {
            DisplayEntries.Clear();
            foreach (BattleAttackParamsEntry_Wrapper entry in LoadedEntries)
            {
                if (FilterText == null ||
                   FilterText == "" ||
                   entry.Id.ToString().Contains(FilterText) ||
                   entry.EntryDesc.ToString().ToLower().Contains(FilterText))
                {
                    DisplayEntries.Add(entry);
                }
            }
        }

        public void SaveFile()
        {
            FileBattle_Service.Instance.AtkpFile.Entries.Clear();
            foreach (BattleAttackParamsEntry_Wrapper wrapper in LoadedEntries)
            {
                FileBattle_Service.Instance.AtkpFile.Entries.Add(wrapper.ToEntry());
            }

            FileBattle_Service.Instance.SaveBarFile("atkp");
            FileBattle_Service.Instance.SaveBattleFile();
            FileBattle_Service.Instance.LoadFromProject();
        }
    }
}
