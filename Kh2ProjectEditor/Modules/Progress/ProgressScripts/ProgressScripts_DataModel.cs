using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Progress;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Progress.ProgressScripts
{
    internal partial class ProgressScripts_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        [ObservableProperty] internal World_Enum selectedWorld = World_Enum.Other;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(DisplayScript))] internal int selectedIndex = 0;
        public ObservableCollection<string> ScriptList { get; set; } = new();
        public ObservableCollection<string> LoadedWorldScripts { get; set; } = new();
        public string DisplayScript { get; set; }


        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public ProgressScripts_DataModel()
        {
            LoadFromFile();
        }

        partial void OnSelectedWorldChanged(World_Enum oldValue, World_Enum newValue)
        {
            LoadWorld((byte)oldValue, (byte)newValue);
        }
        partial void OnSelectedIndexChanged(int oldValue, int newValue)
        {
            DisplayScript = LoadedWorldScripts[SelectedIndex];
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.ProgressExists) {
                return;
            }

            LoadData(FileProgress_Service.Instance.ProgressScriptFiles[(byte)selectedWorld]);
            DisplayScript = LoadedWorldScripts[SelectedIndex];
        }

        public void LoadData(ProgressScript khFile)
        {
            LoadedWorldScripts.Clear();
            ScriptList.Clear();

            for(int i = 0; i < khFile.Scripts.Count; i++)
            {
                LoadedWorldScripts.Add(khFile.Scripts[i]);
                ScriptList.Add("Script " + i);
            }
        }

        public void LoadWorld(byte? oldWorldId, byte newWorldId)
        {
            LoadData(FileProgress_Service.Instance.ProgressScriptFiles[newWorldId]);
            SelectedIndex = 0;
            DisplayScript = LoadedWorldScripts[SelectedIndex];
        }

        public void SaveScript()
        {
            LoadedWorldScripts[SelectedIndex] = DisplayScript;
            FileProgress_Service.Instance.ProgressScriptFiles[(byte)SelectedWorld].Scripts = LoadedWorldScripts.ToList();
        }

        public void SaveWorld()
        {
            FileProgress_Service.Instance.ProgressScriptFiles[(byte)selectedWorld].Scripts = LoadedWorldScripts.ToList();
            FileProgress_Service.Instance.SaveScripts();
            FileProgress_Service.Instance.SaveFile();
        }
    }
}
