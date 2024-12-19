using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Quests
{
    internal partial class JiminyQuests_Wrapper : ObservableObject
    {
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Category))] public ushort categoryId;
        [ObservableProperty] public ushort stat;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(DrawCondition))] public ushort drawConditionId;
        [ObservableProperty] public ushort minigameId;
        [ObservableProperty] public ushort score;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Category))] public ushort clearConditionId;
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Category => Message_Service.Instance.GetJmText(CategoryId);
        public string DrawCondition => DataFetcher.GetProgressFlagDescription(DrawConditionId);
        public string ClearCondition => DataFetcher.GetProgressFlagDescription(ClearConditionId);

        public JiminyQuests_Wrapper(QuestsFile.Entry entry)
        {
            worldId = (JmWorld_Enum)entry.WorldId;
            titleId = entry.TitleId;
            categoryId = entry.CategoryId;
            stat = entry.Stat;
            drawConditionId = entry.DrawConditionId;
            minigameId = entry.MinigameId;
            score = entry.Score;
            clearConditionId = entry.ClearConditionId;
        }

        public QuestsFile.Entry ToEntry()
        {
            return new QuestsFile.Entry
            {
                WorldId = (ushort)worldId,
                TitleId = titleId,
                CategoryId = categoryId,
                Stat = stat,
                DrawConditionId = drawConditionId,
                MinigameId = minigameId,
                Score = score,
                ClearConditionId = clearConditionId,
            };
        }
    }
}
