using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Story
{
    internal partial class JiminyStory_Wrapper : ObservableObject
    {
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(LogText))] public ushort logTextId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(NextText))] public ushort nextTextId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(StoryText))] public ushort storyTextId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Progress))] public ushort progressId;
        public string LogText => Message_Service.Instance.GetJmText(LogTextId);
        public string NextText => Message_Service.Instance.GetJmText(NextTextId);
        public string StoryText => Message_Service.Instance.GetJmText(StoryTextId);
        public string Progress => DataFetcher.GetProgressFlagDescription(ProgressId);

        public JiminyStory_Wrapper(StoryFile.Entry entry)
        {
            worldId = entry.WorldId;
            logTextId = entry.LogTextId;
            nextTextId = entry.NextTextId;
            storyTextId = entry.StoryTextId;
            progressId = entry.ProgressId;
        }

        public StoryFile.Entry ToEntry()
        {
            return new StoryFile.Entry
            {
                WorldId = worldId,
                LogTextId = logTextId,
                NextTextId = nextTextId,
                StoryTextId = storyTextId,
                ProgressId = progressId
            };
        }
    }
}
