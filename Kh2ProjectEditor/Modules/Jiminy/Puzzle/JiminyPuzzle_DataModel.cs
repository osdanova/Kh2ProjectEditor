using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Jiminy.Puzzle
{
    internal class JiminyPuzzle_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyPuzzleEntry_Wrapper> LoadedEntries { get; set; }

        public JiminyPuzzle_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyPuzzleEntry_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.PuzzFile);
        }

        public void LoadData(PuzzleFile puzzleFile)
        {
            LoadedEntries.Clear();
            foreach (PuzzleFile.Entry entry in puzzleFile.Entries)
            {
                LoadedEntries.Add(new JiminyPuzzleEntry_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.PuzzFile.Entries.Clear();
            foreach (JiminyPuzzleEntry_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.PuzzFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("puzz");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}
