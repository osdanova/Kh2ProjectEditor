using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Album
{
    internal partial class JiminyAlbum_Wrapper : ObservableObject
    {
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty] public byte graphic1Id;
        [ObservableProperty] public byte graphic2Id;
        [ObservableProperty] public byte graphic3Id;
        [ObservableProperty] public byte graphic4Id;
        [ObservableProperty] public byte graphic5Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Progress))] public ushort progressId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Text))] public ushort textId;
        public string Progress => DataFetcher.GetProgressFlagDescription(ProgressId);
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Text => Message_Service.Instance.GetJmText(TextId);

        public JiminyAlbum_Wrapper(AlbumFile.Entry entry)
        {
            worldId = entry.WorldId;
            graphic1Id = entry.Graphic1Id;
            graphic2Id = entry.Graphic2Id;
            graphic3Id = entry.Graphic3Id;
            graphic4Id = entry.Graphic4Id;
            graphic5Id = entry.Graphic5Id;
            progressId = entry.ProgressId;
            TitleId = entry.TitleId;
            TextId = entry.TextId;
        }

        public AlbumFile.Entry ToEntry()
        {
            return new AlbumFile.Entry
            {
                WorldId = worldId,
                Graphic1Id = graphic1Id,
                Graphic2Id = graphic2Id,
                Graphic3Id = graphic3Id,
                Graphic4Id = graphic4Id,
                Graphic5Id = graphic5Id,
                ProgressId = progressId,
                TitleId = titleId,
                TextId = textId
            };
        }
    }
}
