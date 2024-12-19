using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;
using KhLib.Kh2.Dictionaries;

namespace Kh2ProjectEditor.Modules.Battle.Magic
{
    public partial class BattleMagic_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public byte level;
        [ObservableProperty] public World_Enum worldId;
        [ObservableProperty] public string filename;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ItemName))] public ushort itemId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CommandName))] public ushort commandId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MotionName))] public short motionId;
        [ObservableProperty] public short blend;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MotionFinishName))] public short motionFinishId;
        [ObservableProperty] public short blendFinish;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MotionAirName))] public short motionAirId;
        [ObservableProperty] public short blendAir;
        [ObservableProperty] public sbyte voiceId;
        [ObservableProperty] public sbyte voiceFinishId;
        [ObservableProperty] public sbyte voiceSelfId;
        public string ItemName => DataFetcher.GetItemName(ItemId);
        public string CommandName => DataFetcher.GetCommandMessage(CommandId);
        public string MotionName => DataFetcher.GetMotionName(MotionId);
        public string MotionFinishName => DataFetcher.GetMotionName(MotionFinishId);
        public string MotionAirName => DataFetcher.GetMotionName(MotionAirId);

        public BattleMagic_Wrapper(MagicFile.Entry entry)
        {
            id = entry.Id;
            level = entry.Level;
            worldId = entry.WorldId;
            filename = entry.Filename;
            itemId = entry.ItemId;
            commandId = entry.CommandId;
            motionId = entry.MotionId;
            blend = entry.Blend;
            motionFinishId = entry.MotionFinishId;
            blendFinish = entry.BlendFinish;
            motionAirId = entry.MotionAirId;
            blendAir = entry.BlendAir;
            voiceId = entry.VoiceId;
            voiceFinishId = entry.VoiceFinishId;
            voiceSelfId = entry.VoiceSelfId;
        }

        public MagicFile.Entry ToEntry()
        {
            return new MagicFile.Entry
            {
                Id = id,
                Level = level,
                WorldId = worldId,
                Filename = filename,
                ItemId = itemId,
                CommandId = commandId,
                MotionId = motionId,
                Blend = blend,
                MotionFinishId = motionFinishId,
                BlendFinish = blendFinish,
                MotionAirId = motionAirId,
                VoiceId = voiceId,
                VoiceFinishId = voiceFinishId,
                VoiceSelfId = voiceSelfId
            };
        }
    }
}
