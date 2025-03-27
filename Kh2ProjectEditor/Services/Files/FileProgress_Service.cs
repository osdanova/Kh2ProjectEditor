using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.Progress;
using System.Collections.Generic;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    public class FileProgress_Service : SingletonBase<FileProgress_Service>
    {
        public BinaryArchive BarFile { get; set; }
        public DisableAreaFile DsaFile { get; set; }
        public List<ProgressScript> ProgressScriptFiles { get; set; } = new();

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.ProgressExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathProgress);
            BarFile = BinaryArchive.Read(byteFile);
            foreach (BinaryArchive.Entry entry in BarFile.Entries)
            {
                switch (entry.Name)
                {
                    case "dsa\0":
                        DsaFile = DisableAreaFile.Read(entry.File);
                        break;
                }
            }
            // Progress worlds
            for(int i = 0; i < 19; i++)
            {
                ProgressScriptFiles.Add(ProgressScript.Read(BarFile.Entries[i].File));
            }
        }

        // Saves the given subfile to the system file
        public void SaveBarFile(string filename)
        {
            foreach (BinaryArchive.Entry entry in BarFile.Entries)
            {
                if (entry.Name == filename)
                {
                    switch (entry.Name)
                    {
                        case "dsa\0":
                            entry.File = DsaFile.GetAsByteArray();
                            break;
                    }
                }
            }
        }
        public void SaveScripts()
        {
            for (int i = 0; i < 19; i++)
            {
                BarFile.Entries[i].File = ProgressScriptFiles[i].GetAsByteArray();
            }
        }

        // Saves the battle file
        public void SaveFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathProgress, BarFile.GetAsByteArray());
        }
    }
}
