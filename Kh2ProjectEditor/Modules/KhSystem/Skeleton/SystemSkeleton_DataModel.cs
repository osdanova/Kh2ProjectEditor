using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.Skeleton
{
    internal partial class SystemSkeleton_DataModel : ObservableObject
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemSkeletonEntry_Wrapper> LoadedEntries { get; set; }
        /******************************************
         * View settings
         ******************************************/
        //public List<string> WorldOptions => new World_Converter().Options.Values.ToList();

        public SystemSkeleton_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemSkeletonEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.SkltFile);
        }

        public void LoadData(SkeletonFile skeletonFile)
        {
            LoadedEntries.Clear();
            foreach (SkeletonFile.Entry entry in skeletonFile.Entries)
            {
                LoadedEntries.Add(new SystemSkeletonEntry_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.SkltFile.Entries.Clear();
            foreach (SystemSkeletonEntry_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.SkltFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("sklt");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
