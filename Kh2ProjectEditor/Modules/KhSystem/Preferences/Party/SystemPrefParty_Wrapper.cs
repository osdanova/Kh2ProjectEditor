using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.System.Preferences.Party
{
    internal partial class SystemPrefParty_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerName))] public int playerId;
        [ObservableProperty] public int partyEntryId;
        public string PlayerName => DataFetcher.GetPlayerName((ushort)playerId);

        public SystemPrefParty_Wrapper(PrefPartyFile.Entry entry)
        {
            playerId = entry.Id;
            partyEntryId = entry.PartyEntryId;
        }

        public PrefPartyFile.Entry ToEntry()
        {
            return new PrefPartyFile.Entry
            {
                Id = playerId,
                PartyEntryId = partyEntryId
            };
        }
    }
}
