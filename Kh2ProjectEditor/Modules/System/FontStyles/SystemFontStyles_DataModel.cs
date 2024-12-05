using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.System;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.System.FontStyles
{
    internal class SystemFontStyles_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemFontStyles_Wrapper> LoadedEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        public SystemFontStyles_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemFontStyles_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.FtstFile);
        }

        public void LoadData(FontStyleFile ftstFile)
        {
            LoadedEntries.Clear();
            foreach (FontStyleFile.Entry entry in ftstFile.Entries)
            {
                LoadedEntries.Add(new SystemFontStyles_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.FtstFile.Entries.Clear();
            foreach (SystemFontStyles_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.FtstFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("ftst");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
