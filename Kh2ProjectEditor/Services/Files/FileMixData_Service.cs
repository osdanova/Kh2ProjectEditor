using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.Mixdata;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    internal class FileMixData_Service : SingletonBase<FileMixData_Service>
    {
        public BinaryArchive MixDataBar { get; set; }
        public RecipesFile ReciFile { get; set; }
        public ConditionsFile CondFile { get; set; }
        public LevelsFile LeveFile { get; set; }
        public ExperienceFile ExpFile { get; set; }

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.MixDataExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathMixData);
            MixDataBar = BinaryArchive.Read(byteFile);
            foreach (BinaryArchive.Entry entry in MixDataBar.Entries)
            {
                switch (entry.Name)
                {
                    case "reci":
                        ReciFile = RecipesFile.Read(entry.File);
                        break;
                    case "cond":
                        CondFile = ConditionsFile.Read(entry.File);
                        break;
                    case "leve":
                        LeveFile = LevelsFile.Read(entry.File);
                        break;
                    case "exp\0":
                        ExpFile = ExperienceFile.Read(entry.File);
                        break;
                }
            }
        }

        // Saves the given subfile to the mix data file
        public void SaveBarFile(string filename)
        {
            foreach (BinaryArchive.Entry entry in MixDataBar.Entries)
            {
                if (entry.Name == filename)
                {
                    switch (entry.Name)
                    {
                        case "reci":
                            entry.File = FileMixData_Service.Instance.ReciFile.GetAsByteArray();
                            break;
                        case "cond":
                            entry.File = FileMixData_Service.Instance.CondFile.GetAsByteArray();
                            break;
                        case "leve":
                            entry.File = FileMixData_Service.Instance.LeveFile.GetAsByteArray();
                            break;
                        case "exp\0":
                            entry.File = FileMixData_Service.Instance.ExpFile.GetAsByteArray();
                            break;
                    }
                }
            }
        }

        // Saves the mix data file
        public void SaveMixDataFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathMixData, MixDataBar.GetAsByteArray());
        }
    }
}
