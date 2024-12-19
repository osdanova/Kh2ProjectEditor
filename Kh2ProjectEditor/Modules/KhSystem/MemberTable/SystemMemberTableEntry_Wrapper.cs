using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.MemberTable
{
    internal partial class SystemMemberTableEntry_Wrapper : ObservableObject
    {
        //[ObservableProperty][NotifyPropertyChangedFor(nameof(WorldDesc))] public World_Enum worldId;
        [ObservableProperty] public World_Enum worldId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CheckStoryFlagDesc))] public ushort checkStoryFlag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CheckStoryFlagNegationDesc))] public ushort checkStoryFlagNegation;
        [ObservableProperty] public byte checkArea;
        [ObservableProperty] public byte padding;
        [ObservableProperty] public int playerSize;
        [ObservableProperty] public int friendSize;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerDesc))] public ushort player;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Party1Desc))] public ushort party1;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Party2Desc))] public ushort party2;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Party3Desc))] public ushort party3;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ValorDesc))] public ushort valor;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(WisdomDesc))] public ushort wisdom;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LimitDesc))] public ushort limit;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MasterDesc))] public ushort master;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(FinalDesc))] public ushort final;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AntiDesc))] public ushort anti;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MickeyDesc))] public ushort mickey;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerHpDesc))] public ushort playerHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ValorHpDesc))] public ushort valorHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(WisdomHpDesc))] public ushort wisdomHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LimitHpDesc))] public ushort limitHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MasterHpDesc))] public ushort masterHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(FinalHpDesc))] public ushort finalHp;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerHp2Desc))] public ushort playerHp2;

        //public string WorldDesc => Worlds_Dictionary.Instance[(byte)WorldId];
        public string CheckStoryFlagDesc => DataFetcher.GetProgressFlagDescription(CheckStoryFlag);
        public string CheckStoryFlagNegationDesc => DataFetcher.GetProgressFlagDescription(CheckStoryFlagNegation);
        public string PlayerDesc => DataFetcher.GetObjectDescription(player);
        public string Party1Desc => DataFetcher.GetObjectDescription(party1);
        public string Party2Desc => DataFetcher.GetObjectDescription(party2);
        public string Party3Desc => DataFetcher.GetObjectDescription(party3);
        public string ValorDesc => DataFetcher.GetObjectDescription(valor);
        public string WisdomDesc => DataFetcher.GetObjectDescription(wisdom);
        public string LimitDesc => DataFetcher.GetObjectDescription(limit);
        public string MasterDesc => DataFetcher.GetObjectDescription(master);
        public string FinalDesc => DataFetcher.GetObjectDescription(final);
        public string AntiDesc => DataFetcher.GetObjectDescription(anti);
        public string MickeyDesc => DataFetcher.GetObjectDescription(mickey);
        public string PlayerHpDesc => DataFetcher.GetObjectDescription(playerHp);
        public string ValorHpDesc => DataFetcher.GetObjectDescription(valorHp);
        public string WisdomHpDesc => DataFetcher.GetObjectDescription(wisdomHp);
        public string LimitHpDesc => DataFetcher.GetObjectDescription(limitHp);
        public string MasterHpDesc => DataFetcher.GetObjectDescription(masterHp);
        public string FinalHpDesc => DataFetcher.GetObjectDescription(finalHp);
        public string PlayerHp2Desc => DataFetcher.GetObjectDescription(playerHp2);

        public SystemMemberTableEntry_Wrapper(MemberTableFile.Entry entry)
        {
            //worldId = entry.WorldId;
            worldId = (World_Enum)entry.WorldId;
            checkStoryFlag = entry.CheckStoryFlag;
            checkStoryFlagNegation = entry.CheckStoryFlagNegation;
            checkArea = entry.CheckArea;
            padding = entry.Padding;
            playerSize = entry.PlayerSize;
            friendSize = entry.FriendSize;
            player = entry.Player;
            party1 = entry.Party1;
            party2 = entry.Party2;
            party3 = entry.Party3;
            valor = entry.Valor;
            wisdom = entry.Wisdom;
            limit = entry.Limit;
            master = entry.Master;
            final = entry.Final;
            anti = entry.Anti;
            mickey = entry.Mickey;
            playerHp = entry.PlayerHp;
            valorHp = entry.ValorHp;
            wisdomHp = entry.WisdomHp;
            limitHp = entry.LimitHp;
            masterHp = entry.MasterHp;
            finalHp = entry.FinalHp;
            playerHp2 = entry.PlayerHp2;
        }

        public MemberTableFile.Entry ToEntry()
        {
            return new MemberTableFile.Entry
            {
                //WorldId = worldId,
                WorldId = (ushort)worldId,
                CheckStoryFlag = checkStoryFlag,
                CheckStoryFlagNegation = checkStoryFlagNegation,
                CheckArea = checkArea,
                Padding = padding,
                PlayerSize = playerSize,
                FriendSize = friendSize,
                Player = player,
                Party1 = party1,
                Party2 = party2,
                Party3 = party3,
                Valor = valor,
                Wisdom = wisdom,
                Limit = limit,
                Master = master,
                Final = final,
                Anti = anti,
                Mickey = mickey,
                PlayerHp = playerHp,
                ValorHp = valorHp,
                WisdomHp = wisdomHp,
                LimitHp = limitHp,
                MasterHp = masterHp,
                FinalHp = finalHp,
                PlayerHp2 = playerHp2
            };
        }
    }
}
