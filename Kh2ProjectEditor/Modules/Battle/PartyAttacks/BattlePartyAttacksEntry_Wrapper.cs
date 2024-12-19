using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.PartyAttacks
{
    internal partial class BattlePartyAttacksEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerName))] public int id;
        [ObservableProperty] public int setId;
        public string PlayerName => DataFetcher.GetPlayerName((ushort)id);

        public BattlePartyAttacksEntry_Wrapper(PartyAttacksFile.Entry entry)
        {
            id = entry.Id;
            SetId = entry.AttackSetId;
        }

        public PartyAttacksFile.Entry ToEntry()
        {
            return new PartyAttacksFile.Entry
            {
                Id = id,
                AttackSetId = setId
            };
        }
    }
}
