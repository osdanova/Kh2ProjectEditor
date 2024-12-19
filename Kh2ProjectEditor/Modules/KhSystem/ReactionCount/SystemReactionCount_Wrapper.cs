using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.ReactionCount
{
    internal partial class SystemReactionCount_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName1))] public ushort commandId1;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName2))] public ushort commandId2;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName3))] public ushort commandId3;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName4))] public ushort commandId4;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName5))] public ushort commandId5;

        public string CommandName1 => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(commandId1) : null;
        public string CommandName2 => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(commandId2) : null;
        public string CommandName3 => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(commandId3) : null;
        public string CommandName4 => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(commandId4) : null;
        public string CommandName5 => ProjectService.Instance.SystemExists ? DataFetcher.GetCommandMessage(commandId5) : null;

        public SystemReactionCount_Wrapper(ReactionCountFile.Entry entry)
        {
            id = entry.Id;
            commandId1 = entry.CommandId1;
            commandId2 = entry.CommandId2;
            commandId3 = entry.CommandId3;
            commandId4 = entry.CommandId4;
            commandId5 = entry.CommandId5;
        }

        public ReactionCountFile.Entry ToEntry()
        {
            return new ReactionCountFile.Entry
            {
                Id = id,
                CommandId1 = commandId1,
                CommandId2 = commandId2,
                CommandId3 = commandId3,
                CommandId4 = commandId4,
                CommandId5 = commandId5
            };
        }
    }
}
