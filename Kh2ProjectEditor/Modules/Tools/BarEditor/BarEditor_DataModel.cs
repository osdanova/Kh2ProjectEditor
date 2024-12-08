using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.Motion;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Tools.BarEditor
{
    internal partial class BarEditor_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        public string BarPath { get; set; }
        public BinaryArchive Bar { get; set; }

        [ObservableProperty] public BinaryArchive.MotionsetType motionsetType;
        public ObservableCollection<EntryWrapper> EntryWrappers { get; set; }
        private void RefreshEntryWrappers()
        {
            List<EntryWrapper> entryWrappersTmp = new List<EntryWrapper>(EntryWrappers);
            EntryWrappers.Clear();
            foreach (EntryWrapper wrapper in entryWrappersTmp)
            {
                EntryWrappers.Add(wrapper);
            }
        }

        /******************************************
         * Options
         ******************************************/
        [ObservableProperty] private bool showMotionTags;
        public List<string> EntryTypeOptions => new BarEditorEntryType_Converter().Options.Values.ToList();
        public List<string> MotionSetTypeOptions => new BarEditorMotionsetType_Converter().Options.Values.ToList();

        /******************************************
         * Constructor
         ******************************************/
        public BarEditor_DataModel()
        {
            EntryWrappers = new ObservableCollection<EntryWrapper>();
        }

        /******************************************
         * Functions
         ******************************************/
        public void LoadBarFile(string filepath)
        {
            byte[] byteFile = File.ReadAllBytes(filepath);
            if (!BinaryArchive.IsValid(byteFile)) {
                return;
            }

            Bar = BinaryArchive.Read(byteFile);
            MotionsetType = Bar.MSetType;

            EntryWrappers.Clear();
            for (int i = 0; i < Bar.Entries.Count; i++)
            {
                EntryWrapper wrapper = new EntryWrapper();
                wrapper.Position = i;
                wrapper.Entry = Bar.Entries[i];
                EntryWrappers.Add(wrapper);
            }

            ShowMotionTags = Bar.MSetType == BinaryArchive.MotionsetType.Player ? true : false;
        }

        public void SaveEntriesToBar()
        {
            Bar.MSetType = MotionsetType;
            Bar.Entries.Clear();
            foreach (EntryWrapper entry in EntryWrappers)
            {
                Bar.Entries.Add(entry.Entry);
            }
        }

        public void SaveFile()
        {
            SaveEntriesToBar();
            AvaloniaDialogUtils.DoSaveFilePicker(Bar.GetAsByteArray(), suggestedFileName: "OUT.bar");
        }

        public void ExportEntry(EntryWrapper wrapper)
        {
            AvaloniaDialogUtils.DoSaveFilePicker(wrapper.Entry.File, suggestedFileName: wrapper.Entry.Name + ".bin");
        }

        public void ImportEntry()
        {
            List<string> filePaths = AvaloniaDialogUtils.GetOpenFilePickerPaths();

            if (filePaths.Count == 0)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(filePaths[0]);

            BinaryArchive.Entry entry = new BinaryArchive.Entry();
            entry.Type = BinaryArchive.EntryType.Dummy;
            entry.Name = "DUMM";
            entry.File = byteFile;
            Bar.Entries.Add(entry);

            EntryWrapper wrapper = new EntryWrapper();
            wrapper.Position = EntryWrappers.Count;
            wrapper.Entry = entry;
            EntryWrappers.Add(wrapper);
        }

        public void ReplaceEntry(EntryWrapper wrapper)
        {
            List<string> filePaths = AvaloniaDialogUtils.GetOpenFilePickerPaths(allowMultiple: false);

            if (filePaths.Count == 0)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(filePaths[0]);
            wrapper.Entry.File = byteFile;
            RefreshEntryWrappers();
        }

        /******************************************
         * Wrappers
         ******************************************/
        public class EntryWrapper
        {
            public int Position { get; set; }
            public BinaryArchive.Entry Entry { get; set; }
            public MotionTag MotionTag
            {
                get
                {
                    int motionId = Position / 4;
                    return (MotionTag)motionId;
                }
            }
        }
    }
}
