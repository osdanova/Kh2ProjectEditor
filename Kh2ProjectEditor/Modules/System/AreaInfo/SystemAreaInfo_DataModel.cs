using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.System.AreaInfo
{
    internal partial class SystemAreaInfo_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<ObservableCollection<SystemAreaInfo_Wrapper>> LoadedWorldInfos { get; set; }
        internal ObservableCollection<SystemAreaInfo_Wrapper> DisplayAreaInfos { get; set; }
        [ObservableProperty] internal World_Enum selectedWorld;
        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showFlags;
        [ObservableProperty] public bool showEffects;
        [ObservableProperty] public bool showBgm1;
        [ObservableProperty] public bool showBgm2;
        [ObservableProperty] public bool showBgm3;
        [ObservableProperty] public bool showBgm4;
        [ObservableProperty] public bool showBgm5;
        [ObservableProperty] public bool showBgm6;
        [ObservableProperty] public bool showBgm7;
        [ObservableProperty] public bool showBgm8;
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        partial void OnSelectedWorldChanged(World_Enum oldValue, World_Enum newValue)
        {
            ApplyFilters();
        }

        public SystemAreaInfo_DataModel()
        {
            ShowFlags = true;
            ShowBgm1 = true;
            LoadedWorldInfos = new ObservableCollection<ObservableCollection<SystemAreaInfo_Wrapper>>();
            DisplayAreaInfos = new ObservableCollection<SystemAreaInfo_Wrapper>();
            SelectedWorld = 0;
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.ArifFile);
        }

        public void LoadData(AreaInfoFile areaInfoFile)
        {
            LoadedWorldInfos.Clear();
            for (byte i = 0; i < areaInfoFile.WorldInfos.Count; i++)
            {
                ObservableCollection<SystemAreaInfo_Wrapper> worldInfoWrap = new ObservableCollection<SystemAreaInfo_Wrapper>();
                for(byte j = 0; j < areaInfoFile.WorldInfos[i].Count; j++)
                {
                    SystemAreaInfo_Wrapper area = new SystemAreaInfo_Wrapper(areaInfoFile.WorldInfos[i][j]);
                    area.World = i;
                    area.Room = j;
                    worldInfoWrap.Add(area);
                }
                LoadedWorldInfos.Add(worldInfoWrap);
            }
            ApplyFilters();
        }

        public void ApplyFilters()
        {
            DisplayAreaInfos.Clear();
            foreach (SystemAreaInfo_Wrapper areaInfo in LoadedWorldInfos[(byte)SelectedWorld])
            {
                DisplayAreaInfos.Add(areaInfo);
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.ArifFile.WorldInfos.Clear();
            foreach (ObservableCollection<SystemAreaInfo_Wrapper> worldInfo in LoadedWorldInfos)
            {
                List<AreaInfoFile.AreaInfo> areaInfos = new List<AreaInfoFile.AreaInfo>();
                foreach(SystemAreaInfo_Wrapper areaInfo in worldInfo)
                {
                    areaInfos.Add(areaInfo.ToEntry());
                }
                FileSystem_Service.Instance.ArifFile.WorldInfos.Add(areaInfos);
            }

            FileSystem_Service.Instance.SaveBarFile("arif");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
