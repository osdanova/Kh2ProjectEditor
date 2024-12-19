using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Characters
{
    internal class JiminyCharacters_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyCharacters_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyCharacters_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyCharacters_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.CharFile);
        }

        public void LoadData(CharactersFile khFile)
        {
            LoadedEntries.Clear();
            foreach (CharactersFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyCharacters_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.CharFile.Entries.Clear();
            foreach (JiminyCharacters_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.CharFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("char");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
