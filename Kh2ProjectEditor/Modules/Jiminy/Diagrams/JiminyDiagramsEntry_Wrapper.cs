using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kh2ProjectEditor.Modules.Jiminy.Diagrams
{
    internal partial class JiminyDiagramsEntry_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ProgressDraw))] public ushort progressDrawId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(ProgressHide))] public ushort progressHideId;
        [ObservableProperty] public JmWorld_Enum worldId;
        [ObservableProperty] public byte type;
        [ObservableProperty] public ObservableCollection<JiminyDiagramsCharacter_Wrapper> characterList;
        public string ProgressDraw => DataFetcher.GetProgressFlagDescription(ProgressDrawId);
        public string ProgressHide => DataFetcher.GetProgressFlagDescription(ProgressHideId);

        public JiminyDiagramsEntry_Wrapper(DiagramsFile.Entry entry)
        {
            progressDrawId = entry.ProgressDrawId;
            progressHideId = entry.ProgressHideId;
            worldId = entry.WorldId;
            type = entry.Type;

            characterList = new ObservableCollection<JiminyDiagramsCharacter_Wrapper>();
            foreach (DiagramsFile.Character chara in entry.CharacterList)
            {
                characterList.Add(new JiminyDiagramsCharacter_Wrapper(chara));
            }
        }

        public DiagramsFile.Entry ToEntry()
        {
            DiagramsFile.Entry entry = new DiagramsFile.Entry
            {
                ProgressDrawId = progressDrawId,
                ProgressHideId = progressHideId,
                WorldId = worldId,
                Type = type
            };

            entry.CharacterList = new List<DiagramsFile.Character>();
            foreach (JiminyDiagramsCharacter_Wrapper chara in CharacterList)
            {
                entry.CharacterList.Add(chara.ToEntry());
            }

            return entry;
        }
    }
}
