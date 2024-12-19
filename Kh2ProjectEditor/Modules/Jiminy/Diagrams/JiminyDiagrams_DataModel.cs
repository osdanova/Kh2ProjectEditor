using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Diagrams
{
    internal class JiminyDiagrams_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyDiagramsEntry_Wrapper> LoadedEntries { get; set; }
        internal ObservableCollection<JiminyDiagramsCharacter_Wrapper> LoadedCharacters { get; set; }
        JiminyDiagramsEntry_Wrapper SelectedEntry { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyDiagrams_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyDiagramsEntry_Wrapper>();
            LoadedCharacters = new ObservableCollection<JiminyDiagramsCharacter_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.DiagFile);
        }

        public void LoadData(DiagramsFile khFile)
        {
            LoadedEntries.Clear();
            foreach (DiagramsFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyDiagramsEntry_Wrapper(entry));
            }
        }

        public void LoadCharacters(JiminyDiagramsEntry_Wrapper entry)
        {
            if(SelectedEntry != null)
            {
                SelectedEntry.CharacterList.Clear();
                foreach (JiminyDiagramsCharacter_Wrapper chara in LoadedCharacters)
                {
                    SelectedEntry.CharacterList.Add(chara);
                }
            }

            SelectedEntry = entry;
            LoadedCharacters.Clear();
            foreach (JiminyDiagramsCharacter_Wrapper chara in SelectedEntry.CharacterList)
            {
                LoadedCharacters.Add(chara);
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.DiagFile.Entries.Clear();
            foreach (JiminyDiagramsEntry_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.DiagFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("diag");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
