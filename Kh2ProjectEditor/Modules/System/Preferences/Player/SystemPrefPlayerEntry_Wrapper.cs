using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.Preferences.Player
{
    internal partial class SystemPrefPlayerEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(PlayerName))] public int playerId;
        [ObservableProperty] public int preferenceId;
        public string PlayerName => DataFetcher.GetPlayerName((ushort)playerId);

        public SystemPrefPlayerEntry_Wrapper(PrefPlayerFile.Entry entry)
        {
            playerId = entry.Id;
            preferenceId = entry.PlayerPreferenceId;
        }

        public PrefPlayerFile.Entry ToEntry()
        {
            return new PrefPlayerFile.Entry
            {
                Id = playerId,
                PlayerPreferenceId = preferenceId
            };
        }
    }
}
