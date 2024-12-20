using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using KhLib.Kh2.Battle;
using System.IO;

namespace Kh2ProjectEditor.Services.Files
{
    public class FileBattle_Service : SingletonBase<FileBattle_Service>
    {
        public BinaryArchive BattleBar { get; set; }
        public AttackParamsFile AtkpFile { get; set; }
        public PartyAttacksFile PtyaFile { get; set; }
        public PrizeTableFile PrztFile { get; set; }
        public VoiceTableFile VtblFile { get; set; }
        public LevelUpFile LvupFile { get; set; }
        public BonusLevelsFile BonsFile { get; set; }
        public BattleLevelFile BtlvFile { get; set; }
        public LevelParamsFile LvpmFile { get; set; }
        public EnemyParamsFile EnmpFile { get; set; }
        public PatternsFile PatnFile { get; set; }
        public PlayerParamsFile PlrpFile { get; set; }
        public LimitsFile LimtFile { get; set; }
        public SummonsFile SumnFile { get; set; }
        public MagicFile MagcFile { get; set; }
        public FormLevelsFile FmlvFile { get; set; }
        public StopFile StopFile { get; set; }

        public void LoadFromProject()
        {
            if (!ProjectService.Instance.BattleExists)
            {
                return;
            }

            byte[] byteFile = File.ReadAllBytes(ProjectService.Instance.PathBattle);
            BattleBar = BinaryArchive.Read(byteFile);
            foreach (BinaryArchive.Entry entry in BattleBar.Entries)
            {
                switch (entry.Name)
                {
                    case "atkp":
                        AtkpFile = AttackParamsFile.Read(entry.File);
                        break;
                    case "ptya":
                        PtyaFile = PartyAttacksFile.Read(entry.File);
                        break;
                    case "przt":
                        PrztFile = PrizeTableFile.Read(entry.File);
                        break;
                    case "vtbl":
                        VtblFile = VoiceTableFile.Read(entry.File);
                        break;
                    case "lvup":
                        LvupFile = LevelUpFile.Read(entry.File);
                        break;
                    case "bons":
                        BonsFile = BonusLevelsFile.Read(entry.File);
                        break;
                    case "btlv":
                        BtlvFile = BattleLevelFile.Read(entry.File);
                        break;
                    case "lvpm":
                        LvpmFile = LevelParamsFile.Read(entry.File);
                        break;
                    case "enmp":
                        EnmpFile = EnemyParamsFile.Read(entry.File);
                        break;
                    case "patn":
                        PatnFile = PatternsFile.Read(entry.File);
                        break;
                    case "plrp":
                        PlrpFile = PlayerParamsFile.Read(entry.File);
                        break;
                    case "limt":
                        LimtFile = LimitsFile.Read(entry.File);
                        break;
                    case "sumn":
                        SumnFile = SummonsFile.Read(entry.File);
                        break;
                    case "magc":
                        MagcFile = MagicFile.Read(entry.File);
                        break;
                    case "vbrt":
                        //VbrtFile = VibrationFile.Read(entry.File);
                        break;
                    case "fmlv":
                        FmlvFile = FormLevelsFile.Read(entry.File);
                        break;
                    case "stop":
                        StopFile = StopFile.Read(entry.File);
                        break;
                }
            }
        }

        // Saves the given subfile to the system file
        public void SaveBarFile(string filename)
        {
            foreach (BinaryArchive.Entry entry in BattleBar.Entries)
            {
                if (entry.Name == filename)
                {
                    switch (entry.Name)
                    {
                        case "atkp":
                            entry.File = FileBattle_Service.Instance.AtkpFile.GetAsByteArray();
                            break;
                        case "ptya":
                            entry.File = FileBattle_Service.Instance.PtyaFile.GetAsByteArray();
                            break;
                        case "przt":
                            entry.File = FileBattle_Service.Instance.PrztFile.GetAsByteArray();
                            break;
                        case "vtbl":
                            entry.File = FileBattle_Service.Instance.VtblFile.GetAsByteArray();
                            break;
                        case "lvup":
                            entry.File = FileBattle_Service.Instance.LvupFile.GetAsByteArray();
                            break;
                        case "bons":
                            entry.File = FileBattle_Service.Instance.BonsFile.GetAsByteArray();
                            break;
                        case "btlv":
                            entry.File = FileBattle_Service.Instance.BtlvFile.GetAsByteArray();
                            break;
                        case "lvpm":
                            entry.File = FileBattle_Service.Instance.LvpmFile.GetAsByteArray();
                            break;
                        case "enmp":
                            entry.File = FileBattle_Service.Instance.EnmpFile.GetAsByteArray();
                            break;
                        case "patn":
                            entry.File = FileBattle_Service.Instance.PatnFile.GetAsByteArray();
                            break;
                        case "plrp":
                            entry.File = FileBattle_Service.Instance.PlrpFile.GetAsByteArray();
                            break;
                        case "limt":
                            entry.File = FileBattle_Service.Instance.LimtFile.GetAsByteArray();
                            break;
                        case "sumn":
                            entry.File = FileBattle_Service.Instance.SumnFile.GetAsByteArray();
                            break;
                        case "magc":
                            entry.File = FileBattle_Service.Instance.MagcFile.GetAsByteArray();
                            break;
                        case "vbrt":
                            //entry.File = FileBattle_Service.Instance.VbrtFile.GetAsByteArray();
                            break;
                        case "fmlv":
                            entry.File = FileBattle_Service.Instance.FmlvFile.GetAsByteArray();
                            break;
                        case "stop":
                            entry.File = FileBattle_Service.Instance.StopFile.GetAsByteArray();
                            break;
                    }
                }
            }
        }

        // Saves the battle file
        public void SaveBattleFile()
        {
            File.WriteAllBytes(ProjectService.Instance.PathBattle, BattleBar.GetAsByteArray());
        }
    }
}
