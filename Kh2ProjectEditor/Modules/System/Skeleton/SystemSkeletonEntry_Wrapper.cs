using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.KhSystem;

namespace Kh2ProjectEditor.Modules.KhSystem.Skeleton
{
    internal partial class SystemSkeletonEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CharacterName))] public int id;
        [ObservableProperty] public short handRightBoneId;
        [ObservableProperty] public short handLeftBoneId;
        public string CharacterName => DataFetcher.GetCharacterName((ushort)id);

        public SystemSkeletonEntry_Wrapper(SkeletonFile.Entry entry)
        {
            id = entry.Id;
            handRightBoneId = entry.HandRightBoneId;
            handLeftBoneId = entry.HandLeftBoneId;
        }

        public SkeletonFile.Entry ToEntry()
        {
            return new SkeletonFile.Entry
            {
                Id = id,
                HandRightBoneId = handRightBoneId,
                HandLeftBoneId = handLeftBoneId
            };
        }
    }
}
