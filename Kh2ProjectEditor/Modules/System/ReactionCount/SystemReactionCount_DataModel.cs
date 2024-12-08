using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.KhSystem.ReactionCount
{
    internal class SystemReactionCount_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<SystemReactionCount_Wrapper> LoadedEntries { get; set; }

        public SystemReactionCount_DataModel()
        {
            LoadedEntries = new ObservableCollection<SystemReactionCount_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.RcctFile);
        }

        public void LoadData(ReactionCountFile reactionCountFile)
        {
            LoadedEntries.Clear();
            foreach (ReactionCountFile.Entry entry in reactionCountFile.Entries)
            {
                LoadedEntries.Add(new SystemReactionCount_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.RcctFile.Entries.Clear();
            foreach (SystemReactionCount_Wrapper wrapper in LoadedEntries)
            {
                FileSystem_Service.Instance.RcctFile.Entries.Add(wrapper.ToEntry());
            }

            FileSystem_Service.Instance.SaveBarFile("rcct");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
