using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Puzzle
{
    internal partial class JiminyPuzzleEntry_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public bool typeBorder;
        [ObservableProperty] public bool typeRotation;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        [ObservableProperty] public string name;
        public string TitleName => Message_Service.Instance.GetJmText(titleId);
        public string ItemName => ProjectService.Instance.SystemExists ? DataFetcher.GetItemName(itemId) : null;

        public JiminyPuzzleEntry_Wrapper(PuzzleFile.Entry entry)
        {
            id = entry.Id;
            typeBorder = entry.TypeBorder;
            typeRotation = entry.TypeRotation;
            titleId = entry.Title;
            itemId = entry.Item;
            name = entry.Name;
        }

        public PuzzleFile.Entry ToEntry()
        {
            return new PuzzleFile.Entry
            {
                Id = id,
                TypeBorder = typeBorder,
                TypeRotation = typeRotation,
                Title = titleId,
                Item = itemId,
                Name = name,
            };
        }
    }
}
