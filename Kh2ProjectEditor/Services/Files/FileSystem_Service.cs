using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.System;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    internal class FileSystem_Service : SingletonBase<FileSystem_Service>
    {
        public BinaryArchive SystemBar {  get; set; }
        public ReactionCountFile RcctFile { get; set; }
        public CommandsFile CmdFile { get; set; }
        public WeaponEntriesFile WentFile { get; set; }
        public WeaponMotionSetsFile WmstFile { get; set; }
        public AreaInfoFile ArifFile { get; set; }
        public ItemsFile ItemFile { get; set; }
        public TreasuresFile TrsrFile { get; set; }
        public MemberTableFile MemtFile { get; set; }
        public FontStyleFile FtstFile { get; set; }
        public ShopsFile ShopFile { get; set; }
        // Skeleton
        // Preferences
        // Event Params
        // Item Picture

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.SystemExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathSystem);
            SystemBar = BinaryArchive.Read(byteFile);
            foreach (BinaryArchive.Entry entry in SystemBar.Entries)
            {
                switch(entry.Name)
                {
                    case "rcct":
                        RcctFile = ReactionCountFile.Read(entry.File);
                        break;
                    case "cmd\0":
                        CmdFile = CommandsFile.Read(entry.File);
                        break;
                    case "went":
                        WentFile = WeaponEntriesFile.Read(entry.File);
                        break;
                    case "wmst":
                        WmstFile = WeaponMotionSetsFile.Read(entry.File);
                        break;
                    case "arif":
                        ArifFile = AreaInfoFile.Read(entry.File);
                        break;
                    case "item":
                        ItemFile = ItemsFile.Read(entry.File);
                        break;
                    case "trsr":
                        TrsrFile = TreasuresFile.Read(entry.File);
                        break;
                    case "memt":
                        MemtFile = MemberTableFile.Read(entry.File);
                        break;
                    case "ftst":
                        FtstFile = FontStyleFile.Read(entry.File);
                        break;
                    case "shop":
                        ShopFile = ShopsFile.Read(entry.File);
                        break;
                    case "sklt":
                        break;
                    case "pref":
                        break;
                    case "evtp":
                        break;
                    case "ipic":
                        break;
                }
            }
        }

        // Saves the given subfile to the system file
        public void SaveBarFile(string filename)
        {
            foreach (BinaryArchive.Entry entry in SystemBar.Entries)
            {
                if (entry.Name == filename)
                {
                    switch (entry.Name)
                    {
                        case "rcct":
                            entry.File = FileSystem_Service.Instance.RcctFile.GetAsByteArray();
                            break;
                        case "cmd\0":
                            entry.File = FileSystem_Service.Instance.CmdFile.GetAsByteArray();
                            break;
                        case "went":
                            entry.File = FileSystem_Service.Instance.WentFile.GetAsByteArray();
                            break;
                        case "wmst":
                            entry.File = FileSystem_Service.Instance.WmstFile.GetAsByteArray();
                            break;
                        case "arif":
                            entry.File = FileSystem_Service.Instance.ArifFile.GetAsByteArray();
                            break;
                        case "item":
                            entry.File = FileSystem_Service.Instance.ItemFile.GetAsByteArray();
                            break;
                        case "trsr":
                            entry.File = FileSystem_Service.Instance.TrsrFile.GetAsByteArray();
                            break;
                        case "memt":
                            entry.File = FileSystem_Service.Instance.MemtFile.GetAsByteArray();
                            break;
                        case "ftst":
                            entry.File = FileSystem_Service.Instance.FtstFile.GetAsByteArray();
                            break;
                        case "shop":
                            entry.File = FileSystem_Service.Instance.ShopFile.GetAsByteArray();
                            break;
                        case "sklt":
                            break;
                        case "pref":
                            break;
                        case "evtp":
                            break;
                        case "ipic":
                            break;
                    }
                }
            }
        }

        // Saves the system file
        public void SaveSystemFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathSystem, SystemBar.GetAsByteArray());
        }
    }
}
