using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.Jiminy;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    internal class FileJiminy_Service : SingletonBase<FileJiminy_Service>
    {
        public BinaryArchive JiminyBar { get; set; }
        public WorldsFile WorlFile { get; set; }
        public StoryFile StorFile { get; set; }
        public AlbumFile AlbuFile { get; set; }
        public CharactersFile CharFile { get; set; }
        public AnsemReportsFile AnseFile { get; set; }
        public DiagramsFile DiagFile { get; set; }
        public LimitsFile LimiFile { get; set; }
        public MinigamesFile MiniFile { get; set; }
        public QuestsFile QuesFile { get; set; }
        public PuzzleFile PuzzFile { get; set; }

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathJiminy);
            JiminyBar = BinaryArchive.Read(byteFile);
            foreach (BinaryArchive.Entry entry in JiminyBar.Entries)
            {
                switch (entry.Name)
                {
                    case "worl":
                        WorlFile = WorldsFile.Read(entry.File);
                        break;
                    case "stor":
                        StorFile = StoryFile.Read(entry.File);
                        break;
                    case "albu":
                        AlbuFile = AlbumFile.Read(entry.File);
                        break;
                    case "char":
                        CharFile = CharactersFile.Read(entry.File);
                        break;
                    case "anse":
                        AnseFile = AnsemReportsFile.Read(entry.File);
                        break;
                    case "diag":
                        DiagFile = DiagramsFile.Read(entry.File);
                        break;
                    case "limi":
                        LimiFile = LimitsFile.Read(entry.File);
                        break;
                    case "mini":
                        MiniFile = MinigamesFile.Read(entry.File);
                        break;
                    case "ques":
                        QuesFile = QuestsFile.Read(entry.File);
                        break;
                    case "puzz":
                        PuzzFile = PuzzleFile.Read(entry.File);
                        break;
                }
            }
        }

        // Saves the given subfile to the jiminy file
        public void SaveBarFile(string filename, string prefFilename = "")
        {
            foreach (BinaryArchive.Entry entry in JiminyBar.Entries)
            {
                if (entry.Name == filename)
                {
                    switch (entry.Name)
                    {
                        case "worl":
                            entry.File = FileJiminy_Service.Instance.WorlFile.GetAsByteArray();
                            break;
                        case "stor":
                            entry.File = FileJiminy_Service.Instance.StorFile.GetAsByteArray();
                            break;
                        case "albu":
                            entry.File = FileJiminy_Service.Instance.AlbuFile.GetAsByteArray();
                            break;
                        case "char":
                            entry.File = FileJiminy_Service.Instance.CharFile.GetAsByteArray();
                            break;
                        case "anse":
                            entry.File = FileJiminy_Service.Instance.AnseFile.GetAsByteArray();
                            break;
                        case "diag":
                            entry.File = FileJiminy_Service.Instance.DiagFile.GetAsByteArray();
                            break;
                        case "limi":
                            entry.File = FileJiminy_Service.Instance.LimiFile.GetAsByteArray();
                            break;
                        case "mini":
                            entry.File = FileJiminy_Service.Instance.MiniFile.GetAsByteArray();
                            break;
                        case "ques":
                            entry.File = FileJiminy_Service.Instance.QuesFile.GetAsByteArray();
                            break;
                        case "puzz":
                            entry.File = FileJiminy_Service.Instance.PuzzFile.GetAsByteArray();
                            break;
                    }
                }
            }
        }

        // Saves the jiminy file
        public void SaveJiminyFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathJiminy, JiminyBar.GetAsByteArray());
        }
    }
}
