using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Worlds
{
    internal partial class JiminyWorlds_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public string name;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Title))] public ushort titleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Menu))] public ushort menuId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(OpenProgress))] public ushort openProgressId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AltTitle))] public ushort altTitleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AltMenu))] public ushort altMenuId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AltProgress))] public ushort altProgressId;
        public string Title => Message_Service.Instance.GetJmText(TitleId);
        public string Menu => Message_Service.Instance.GetJmText(MenuId);
        public string OpenProgress => DataFetcher.GetProgressFlagDescription(OpenProgressId);
        public string AltTitle => Message_Service.Instance.GetJmText(AltTitleId);
        public string AltMenu => Message_Service.Instance.GetJmText(AltMenuId);
        public string AltProgress => DataFetcher.GetProgressFlagDescription(AltProgressId);

        public JiminyWorlds_Wrapper(WorldsFile.Entry entry)
        {
            id = entry.Id;
            name = entry.Name;
            titleId = entry.TitleId;
            menuId = entry.MenuId;
            openProgressId = entry.OpenProgressId;
            altTitleId = entry.AltTitleId;
            altMenuId = entry.AltMenuId;
            altProgressId = entry.AltProgressId;
        }

        public WorldsFile.Entry ToEntry()
        {
            return new WorldsFile.Entry
            {
                Id = id,
                Name = name,
                TitleId = titleId,
                MenuId = menuId,
                OpenProgressId = openProgressId,
                AltTitleId = altTitleId,
                AltMenuId = altMenuId,
                AltProgressId = altProgressId
            };
        }
    }
}
