using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Characters
{
    internal partial class JiminyCharacters_Wrapper : ObservableObject
    {
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty] public byte graphic;
        [ObservableProperty] public byte graphicBase;
        [ObservableProperty] public ushort index;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Name))] public ushort nameId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Text))] public ushort textId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(SourceTitle))] public ushort sourceTitleId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ObjectName))] public ushort objectId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Motion))] public ushort motionId;
        [ObservableProperty] public ushort stat;
        [ObservableProperty] public short xpos;
        [ObservableProperty] public short ypos;
        [ObservableProperty] public short yrot;
        [ObservableProperty] public short xpos2;
        [ObservableProperty] public short ypos2;
        [ObservableProperty] public float scale;
        [ObservableProperty] public float scale2;
        public string ObjectName => DataFetcher.GetObjectDescription(objectId);
        public string Name => Message_Service.Instance.GetJmText(NameId);
        public string Text => Message_Service.Instance.GetJmText(TextId);
        public string SourceTitle => Message_Service.Instance.GetJmText(SourceTitleId);
        public string Motion => DataFetcher.GetMotionName((short)motionId);

        public JiminyCharacters_Wrapper(CharactersFile.Entry entry)
        {
            worldId = entry.WorldId;
            graphic = entry.Graphic;
            graphicBase = entry.GraphicBase;
            index = entry.Index;
            nameId = entry.NameId;
            textId = entry.TextId;
            sourceTitleId = entry.SourceTitleId;
            objectId = entry.ObjectId;
            motionId = entry.MotionId;
            stat = entry.Stat;
            xpos = entry.Xpos;
            ypos = entry.Ypos;
            Yrot = entry.Yrot;
            xpos2 = entry.Xpos2;
            ypos2 = entry.Ypos2;
            scale = entry.Scale;
            scale2 = entry.Scale2;
        }

        public CharactersFile.Entry ToEntry()
        {
            return new CharactersFile.Entry
            {
                WorldId = worldId,
                Graphic = graphic,
                GraphicBase = graphicBase,
                Index = index,
                NameId = nameId,
                TextId = textId,
                SourceTitleId = sourceTitleId,
                ObjectId = objectId,
                MotionId = motionId,
                Stat = stat,
                Xpos = xpos,
                Ypos = ypos,
                Yrot = yrot,
                Xpos2 = xpos2,
                Ypos2 = ypos2,
                Scale = scale,
                Scale2 = scale2
            };
        }
    }
}
