using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Story
{
    internal class JiminyStory_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyStory_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyStory_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyStory_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.StorFile);
        }

        public void LoadData(StoryFile khFile)
        {
            LoadedEntries.Clear();
            foreach (StoryFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyStory_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.StorFile.Entries.Clear();
            foreach (JiminyStory_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.StorFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("stor");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
