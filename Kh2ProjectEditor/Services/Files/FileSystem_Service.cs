using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.KhSystem;
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
        public SkeletonFile SkltFile { get; set; }
        public EventParamsFile EvtpFile { get; set; }
        // Preferences
        public BinaryArchive PrefFile { get; set; }
        public PrefPlayerFile PrefPlyrFile { get; set; }
        public PrefFormAbilitiesFile PrefFmabFile { get; set; }
        public PrefPartyFile PrefPrtyFile { get; set; }
        public PrefSystemFile PrefSstmFile { get; set; }
        public PrefMagicFile PrefMagiFile { get; set; }
        // Item Picture //SEQD file

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
                        SkltFile = SkeletonFile.Read(entry.File);
                        break;
                    case "evtp":
                        EvtpFile = EventParamsFile.Read(entry.File);
                        break;

                    case "pref":
                        PrefFile = BinaryArchive.Read(entry.File);
                        foreach (BinaryArchive.Entry prefEntry in PrefFile.Entries)
                        {
                            switch (prefEntry.Name)
                            {
                                case "plyr":
                                    PrefPlyrFile = PrefPlayerFile.Read(prefEntry.File);
                                    break;
                                case "fmab":
                                    PrefFmabFile = PrefFormAbilitiesFile.Read(prefEntry.File);
                                    break;
                                case "prty":
                                    PrefPrtyFile = PrefPartyFile.Read(prefEntry.File);
                                    break;
                                case "sstm":
                                    PrefSstmFile = PrefSystemFile.Read(prefEntry.File);
                                    break;
                                case "magi":
                                    PrefMagiFile = PrefMagicFile.Read(prefEntry.File);
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        // Saves the given subfile to the system file
        public void SaveBarFile(string filename, string prefFilename = "")
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
                            entry.File = FileSystem_Service.Instance.SkltFile.GetAsByteArray();
                            break;
                        case "evtp":
                            entry.File = FileSystem_Service.Instance.EvtpFile.GetAsByteArray();
                            break;

                        case "pref":
                            foreach (BinaryArchive.Entry prefEntry in PrefFile.Entries)
                            {
                                if (prefEntry.Name == prefFilename)
                                {
                                    switch (prefEntry.Name)
                                    {
                                        case "plyr":
                                            prefEntry.File = FileSystem_Service.Instance.PrefPlyrFile.GetAsByteArray();
                                            break;
                                        case "fmab":
                                            prefEntry.File = FileSystem_Service.Instance.PrefFmabFile.GetAsByteArray();
                                            break;
                                        case "prty":
                                            prefEntry.File = FileSystem_Service.Instance.PrefPrtyFile.GetAsByteArray();
                                            break;
                                        case "sstm":
                                            prefEntry.File = FileSystem_Service.Instance.PrefSstmFile.GetAsByteArray();
                                            break;
                                        case "magi":
                                            prefEntry.File = FileSystem_Service.Instance.PrefMagiFile.GetAsByteArray();
                                            break;
                                    }
                                }
                            }
                            entry.File = FileSystem_Service.Instance.PrefFile.GetAsByteArray();
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
