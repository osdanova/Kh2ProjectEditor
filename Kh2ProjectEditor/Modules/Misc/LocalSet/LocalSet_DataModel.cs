using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.LocalSet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Misc.LocalSet
{
    internal partial class LocalSet_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal LocalSetFile _file;
        [ObservableProperty] internal World_Enum selectedWorld;
        internal ObservableCollection<LocalSetWorld.Entry> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public LocalSet_DataModel()
        {
            LoadedEntries = new ObservableCollection<LocalSetWorld.Entry>();
            SelectedWorld = 0;
            LoadFromFile();
        }

        partial void OnSelectedWorldChanged(World_Enum oldValue, World_Enum newValue)
        {
            LoadWorld((byte)oldValue, (byte)newValue);
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.LocalSetExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathLocalSet);
            _file = LocalSetFile.Read(byteFile);

            LoadData(_file);
        }

        public void LoadData(LocalSetFile khFile)
        {
            LoadWorld(null, 0);
        }

        public void LoadWorld(byte? oldWorldId, byte newWorldId)
        {
            if(oldWorldId != null)
            {
                _file.Files[oldWorldId.Value].Entries = new List<LocalSetWorld.Entry>(LoadedEntries);
            }

            LoadedEntries.Clear();
            foreach (LocalSetWorld.Entry entry in _file.Files[(byte)newWorldId].Entries)
            {
                LoadedEntries.Add(entry);
            }
        }

        public void RemoveEntry(int EntryIndex)
        {
            LoadedEntries.RemoveAt(EntryIndex);
        }
        public void AddEntry()
        {
            LoadedEntries.Add(new LocalSetWorld.Entry());
        }

        public void SaveFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathLocalSet, _file.GetAsByteArray());
        }
    }
}
