using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Minigames
{
    internal partial class JiminyMinigames_Wrapper : ObservableObject
    {
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Unit))] public ushort unitId;
        [ObservableProperty] public ushort index;
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Unit => Message_Service.Instance.GetJmText(UnitId);

        public JiminyMinigames_Wrapper(MinigamesFile.Entry entry)
        {
            worldId = (JmWorld_Enum)entry.WorldId;
            TitleId = entry.TitleId;
            unitId = entry.UnitId;
            index = entry.Index;
        }

        public MinigamesFile.Entry ToEntry()
        {
            return new MinigamesFile.Entry
            {
                WorldId = (ushort)worldId,
                TitleId = titleId,
                UnitId = unitId,
                Index = index
            };
        }
    }
}
