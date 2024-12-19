using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Ansem
{
    internal partial class JiminyAnsemReports_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item))] public ushort itemId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Text))] public ushort textId;
        public string Item => DataFetcher.GetItemName(ItemId);
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Text => Message_Service.Instance.GetJmText(TextId);

        public JiminyAnsemReports_Wrapper(AnsemReportsFile.Entry entry)
        {
            itemId = entry.ItemId;
            titleId = entry.TitleId;
            textId = entry.TextId;
        }

        public AnsemReportsFile.Entry ToEntry()
        {
            return new AnsemReportsFile.Entry
            {
                ItemId = itemId,
                TitleId = titleId,
                TextId = textId,
            };
        }
    }
}
