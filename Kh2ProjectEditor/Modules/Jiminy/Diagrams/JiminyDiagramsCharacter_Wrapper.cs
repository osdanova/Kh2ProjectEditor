using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.Jiminy;

namespace Kh2ProjectEditor.Modules.Jiminy.Diagrams
{
    internal partial class JiminyDiagramsCharacter_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort labelId;
        [ObservableProperty] public short xpos;
        [ObservableProperty] public short ypos;
        [ObservableProperty] public byte draw;

        public JiminyDiagramsCharacter_Wrapper(DiagramsFile.Character entry)
        {
            labelId = entry.LabelId;
            xpos = entry.Xpos;
            ypos = entry.Ypos;
            draw = entry.Draw;
        }

        public DiagramsFile.Character ToEntry()
        {
            return new DiagramsFile.Character
            {
                LabelId = labelId,
                Xpos = xpos,
                Ypos = ypos,
                Draw = draw
            };
        }
    }
}
