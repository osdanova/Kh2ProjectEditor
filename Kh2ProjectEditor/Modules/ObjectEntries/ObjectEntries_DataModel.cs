using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using KhLib.Kh2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Kh2ProjectEditor.Modules.ObjectEntries
{
    public partial class ObjectEntries_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        public ObjectEntryFile ObjentryFile { get; set; }
        public ObservableCollection<ObjectEntryFile.Entry> LoadedObjectEntries { get; set; }
        public ObservableCollection<ObjectEntryFile.Entry> DisplayObjectEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        [ObservableProperty] public bool showBasic;
        [ObservableProperty] public bool showExtended;
        [ObservableProperty] public bool showFlags;
        [ObservableProperty] public bool showSpawns;
        [ObservableProperty] public string filterText;
        public List<string> EntryTypeOptions => new ObjectEntriesType_Converter().Options.Values.ToList();
        public List<string> EntryShadowOptions => new ObjectEntriesShadow_Converter().Options.Values.ToList();
        public List<string> EntryFormOptions => new ObjectEntriesForm_Converter().Options.Values.ToList();
        public List<string> EntryTargetOptions => new ObjectEntriesTarget_Converter().Options.Values.ToList();

        public ObjectEntries_DataModel()
        {
            ShowBasic = true;
            ShowExtended = false;
            ShowFlags = false;
            ShowSpawns = false;
            filterText = "";
            LoadedObjectEntries = new ObservableCollection<ObjectEntryFile.Entry>();
            DisplayObjectEntries = new ObservableCollection<ObjectEntryFile.Entry>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.ObjentryExists) {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathObjentry);
            LoadEntries(byteFile);
        }

        public void LoadEntries(byte[] byteFile)
        {
            ObjentryFile = ObjectEntryFile.Read(byteFile);
            LoadedObjectEntries = new ObservableCollection<ObjectEntryFile.Entry>(ObjentryFile.Entries);
            ApplyFilters();
        }

        public void ApplyFilters()
        {
            DisplayObjectEntries.Clear();
            foreach (ObjectEntryFile.Entry entry in LoadedObjectEntries)
            {
                if(FilterText == null ||
                   FilterText == "" ||
                   entry.Id.ToString().Contains(FilterText) ||
                   entry.ObjectDescription.ToString().ToLower().Contains(FilterText.ToLower()) ||
                   entry.ModelName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                   entry.AnimationName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                   entry.SpawnObject1.ToString().Contains(FilterText) ||
                   entry.SpawnObject2.ToString().Contains(FilterText) ||
                   entry.SpawnObject3.ToString().Contains(FilterText) ||
                   entry.SpawnObject4.ToString().Contains(FilterText))
                {
                    DisplayObjectEntries.Add(entry);
                }
            }
        }

        public void SaveFile()
        {
            ObjentryFile.Entries = LoadedObjectEntries.ToList();
            byte[] byteFile = ObjentryFile.GetAsByteArray();
            File.WriteAllBytes(ProjectService.Instance.PathObjentry, byteFile);
        }
    }
}
