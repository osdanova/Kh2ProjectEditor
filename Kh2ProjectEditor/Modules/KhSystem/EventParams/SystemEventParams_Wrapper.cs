using CommunityToolkit.Mvvm.ComponentModel;
using KhLib.Kh2.KhSystem;
using static KhLib.Kh2.KhSystem.EventTypeFile;

namespace Kh2ProjectEditor.Modules.KhSystem.EventParams
{
    internal partial class SystemEventParams_Wrapper : ObservableObject
    {
        [ObservableProperty] public byte id;
        [ObservableProperty] public FadeType fadeType;
        [ObservableProperty] public bool scene;
        [ObservableProperty] public bool stop;
        [ObservableProperty] public bool layer;
        [ObservableProperty] public bool control;
        [ObservableProperty] public bool mask;
        [ObservableProperty] public bool sound;
        [ObservableProperty] public bool lockon;
        [ObservableProperty] public bool hideFriend;
        [ObservableProperty] public float fadeTime;

        public SystemEventParams_Wrapper(EventTypeFile.Entry entry)
        {
            id = entry.Id;
            fadeType = entry.FadeType;
            scene = entry.ConfigScene;
            stop = entry.ConfigStop;
            layer = entry.ConfigLayer;
            control = entry.ConfigControl;
            mask = entry.ConfigMask;
            sound = entry.ConfigSound;
            lockon = entry.ConfigLockon;
            hideFriend = entry.ConfigHideFriend;
            fadeTime = entry.FadeTime;
        }

        public EventTypeFile.Entry ToEntry()
        {
            return new EventTypeFile.Entry
            {
                Id = id,
                FadeType = fadeType,
                ConfigScene = scene,
                ConfigStop = stop,
                ConfigLayer = layer,
                ConfigControl = control,
                ConfigMask = mask,
                ConfigSound = sound,
                ConfigLockon = lockon,
                ConfigHideFriend = hideFriend,
                FadeTime = fadeTime
            };
        }
    }
}
