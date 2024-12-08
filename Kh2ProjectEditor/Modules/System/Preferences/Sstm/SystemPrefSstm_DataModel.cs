using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.System.Preferences.Sstm
{
    internal class SystemPrefSstm_DataModel
    {
        public PrefSystemFile.Entry SystemPrefs { get; set; }

        public SystemPrefSstm_DataModel()
        {
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            LoadData(FileSystem_Service.Instance.PrefSstmFile);
        }

        public void LoadData(PrefSystemFile prtyFile)
        {
            SystemPrefs = prtyFile.SystemSettings;
        }

        public void SaveFile()
        {
            FileSystem_Service.Instance.SaveBarFile("pref", "sstm");
            FileSystem_Service.Instance.SaveSystemFile();
            FileSystem_Service.Instance.LoadFromProject();
        }
    }
}
