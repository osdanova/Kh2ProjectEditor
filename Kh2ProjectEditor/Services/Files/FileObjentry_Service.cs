using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    internal class FileObjentry_Service : SingletonBase<FileObjentry_Service>
    {
        public ObjectEntryFile ObjentryFile { get; set; }

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.ObjentryExists)
            {
                return;
            }
        
            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathObjentry);
            ObjentryFile = ObjectEntryFile.Read(byteFile);
        }
    }
}
