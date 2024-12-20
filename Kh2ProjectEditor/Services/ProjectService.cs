using Kh2ProjectEditor.Services.Files;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using System.IO;

namespace Kh2ProjectEditor.Services
{
    public class ProjectService : SingletonBase<ProjectService>
    {
        /******************************************
         * STATE
         ******************************************/
        public string? ProjectPath
        {
            get;
            private set;
        }
        public bool IsProjectLoaded => ProjectPath != null && ProjectPath != "";

        /******************************************
         * Public functions
         ******************************************/
        public void LoadProject(string projectPath)
        {
            if (!Directory.Exists(projectPath))
            {
                throw new System.Exception("[ProjectService] Provided folder doesn't exist");
            }
            ProjectPath = projectPath;

            Message_Service.Instance.LoadFromProject();
            FileSystem_Service.Instance.LoadFromProject();
            FileBattle_Service.Instance.LoadFromProject();
            FileJiminy_Service.Instance.LoadFromProject();
            FileMixData_Service.Instance.LoadFromProject();
            FileObjentry_Service.Instance.LoadFromProject();
        }

        /******************************************
         * Files
         ******************************************/
        public string PathObjentry => Path.Combine(ProjectPath, "00objentry.bin");
        public bool ObjentryExists => IsProjectLoaded && File.Exists(PathObjentry);
        public string PathBattle => Path.Combine(ProjectPath, "00battle.bin");
        public bool BattleExists => IsProjectLoaded && File.Exists(PathBattle);
        public string PathSystem => Path.Combine(ProjectPath, "03system.bin");
        public bool SystemExists => IsProjectLoaded && File.Exists(PathSystem);
        public string PathJiminy => Path.Combine(ProjectPath, "jiminy.bar");
        public bool JiminyExists => IsProjectLoaded && File.Exists(PathJiminy);
        public string PathMixData => Path.Combine(ProjectPath, "mixdata.bar");
        public bool MixDataExists => IsProjectLoaded && File.Exists(PathMixData);

        public string PathMsgSysUs => Path.Combine([ProjectPath, "msg", "us", "sys.bar"]);
        public string PathMsgJmUs => Path.Combine([ProjectPath, "msg", "us", "jm.bar"]);
        public bool MsgSysUsExists => IsProjectLoaded && File.Exists(PathMsgSysUs);
        public bool MsgJmUsExists => IsProjectLoaded && File.Exists(PathMsgJmUs);

        /******************************************
         * Subfiles
         ******************************************/
        // SYSTEM
        public BinaryArchive GetSystemBar()
        {
            if (!SystemExists) {
                throw new System.Exception("Trying to read non-existent file");
            }

            byte[] byteFile = File.ReadAllBytes(PathSystem);
            return BinaryArchive.Read(byteFile);
        }

        // MSG
        public byte[] GetMsgSysUs()
        {
            if (!MsgSysUsExists) {
                throw new System.Exception("Trying to read non-existent file");
            }

            byte[] byteFile = File.ReadAllBytes(PathMsgSysUs);
            return byteFile;
        }
        public byte[] GetMsgJmUs()
        {
            if (!MsgJmUsExists)
            {
                throw new System.Exception("Trying to read non-existent file");
            }

            byte[] byteFile = File.ReadAllBytes(PathMsgJmUs);
            return byteFile;
        }
    }
}
