using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Modules.KhSystem.Items;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2;
using KhLib.Kh2.KhSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Kh2ProjectEditor.Modules.KhSystem.MemberTable
{
    internal partial class SystemMemberTable_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemMemberTableEntry_Wrapper> LoadedEntries { get; set; }
        internal ObservableCollection<MemberTableFile.Set> LoadedSets { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showConditions;
        [ObservableProperty] public bool showMemorySize;
        [ObservableProperty] public bool showParty;
        [ObservableProperty] public bool showForms;
        [ObservableProperty] public bool showHp;
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public SystemMemberTable_DataModel()
        {
            ShowConditions = true;
            ShowMemorySize = false;
            ShowParty = true;
            ShowForms = false;
            ShowHp = false;
            LoadedEntries = new ObservableCollection<SystemMemberTableEntry_Wrapper> ();
            LoadedSets = new ObservableCollection<MemberTableFile.Set> ();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.MemtFile);
        }

        public void LoadData(MemberTableFile memtFile)
        {
            LoadedEntries.Clear();
            foreach (MemberTableFile.Entry entry in memtFile.Entries)
            {
                //LoadedEntries.Add(new SystemReactionCount_Wrapper(entry));
                LoadedEntries.Add(new SystemMemberTableEntry_Wrapper(entry));
            }
            LoadedSets.Clear();
            foreach (MemberTableFile.Set set in memtFile.Sets)
            {
                LoadedSets.Add(set);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.MemtFile.Entries.Clear();
            foreach (SystemMemberTableEntry_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.MemtFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.MemtFile.Sets.Clear();
            foreach (MemberTableFile.Set set in LoadedSets)
            {
                FileSystem_Service.Instance.MemtFile.Sets.Add(set);
            }

            FileSystem_Service.Instance.SaveBarFile("memt");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
