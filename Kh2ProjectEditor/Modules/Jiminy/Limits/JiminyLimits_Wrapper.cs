using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Limits
{
    internal partial class JiminyLimits_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Command))] public ushort commandId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Text))] public ushort textId;
        public string Command => DataFetcher.GetCommandMessage(CommandId);
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Text => Message_Service.Instance.GetJmText(TextId);

        public JiminyLimits_Wrapper(LimitsFile.Entry entry)
        {
            commandId = entry.CommandId;
            titleId = entry.TitleId;
            textId = entry.TextId;
        }

        public LimitsFile.Entry ToEntry()
        {
            return new LimitsFile.Entry
            {
                CommandId = commandId,
                TitleId = titleId,
                TextId = textId
            };
        }
    }
}
