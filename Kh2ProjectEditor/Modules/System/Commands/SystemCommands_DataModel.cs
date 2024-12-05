using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2;
using KhLib.Kh2.System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Kh2ProjectEditor.Modules.System.Commands
{
    public partial class SystemCommands_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemCommandsEntry_Wrapper> LoadedEntries { get; set; }
        internal ObservableCollection<SystemCommandsEntry_Wrapper> DisplayEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty]
        public bool showBasic;
        [ObservableProperty]
        public bool showExtended;
        [ObservableProperty]
        public bool showFlags;
        [ObservableProperty]
        public string filterText;
        public List<string> EntryIconOptions => new SystemCommandsIcon_Converter().Options.Values.ToList();
        public List<string> EntryCameraOptions => new SystemCommandsCamera_Converter().Options.Values.ToList();
        public List<string> EntryReceiverOptions => new SystemCommandsReceiver_Converter().Options.Values.ToList();
        public List<string> EntryActionOptions => new SystemCommandsAction_Converter().Options.Values.ToList();

        public SystemCommands_DataModel()
        {
            ShowBasic = true;
            ShowExtended = false;
            ShowFlags = false;
            LoadedEntries = new ObservableCollection<SystemCommandsEntry_Wrapper>();
            DisplayEntries = new ObservableCollection<SystemCommandsEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.CmdFile);
        }

        public void LoadData(CommandsFile commandsFile)
        {
            LoadedEntries.Clear();
            foreach (CommandsFile.Entry entry in commandsFile.Entries)
            {
                LoadedEntries.Add(new SystemCommandsEntry_Wrapper(entry));
            }
            ApplyFilters();
        }

        public void ApplyFilters()
        {
            DisplayEntries.Clear();
            foreach (SystemCommandsEntry_Wrapper entry in LoadedEntries)
            {
                if(entry?.CommandMessage == null) {
                    continue;
                }
                if (FilterText == null ||
                   FilterText == "" ||
                   entry.Id.ToString().Contains(FilterText) ||
                   entry.CommandMessage.ToString().ToLower().Contains(FilterText.ToLower()))
                {
                    DisplayEntries.Add(entry);
                }
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.CmdFile.Entries.Clear();
            foreach (SystemCommandsEntry_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.CmdFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("cmd\0");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
