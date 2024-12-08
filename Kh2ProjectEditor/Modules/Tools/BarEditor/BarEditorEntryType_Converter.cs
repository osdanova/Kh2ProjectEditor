using Kh2ProjectEditor.Utils;
using KhLib.Kh2;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.Tools.BarEditor
{
    internal class BarEditorEntryType_Converter : BaseEnumStringConverter<BinaryArchive.EntryType>
    {
        public BarEditorEntryType_Converter()
        {
            Options = new Dictionary<BinaryArchive.EntryType, string>
            {
                {BinaryArchive.EntryType.Dummy, "[0] Dummy" },
                {BinaryArchive.EntryType.Binary, "[1] Binary Archive" },
                {BinaryArchive.EntryType.List, "[2] List" },
                {BinaryArchive.EntryType.Bdx, "[3] Bdx" },
                {BinaryArchive.EntryType.Model, "[4] Model" },
                {BinaryArchive.EntryType.DrawOctalTree, "[5] Draw Octal Tree" },
                {BinaryArchive.EntryType.CollisionOctalTree, "[6] Collision Octal Tree" },
                {BinaryArchive.EntryType.ModelTexture, "[7] Model Texture" },
                {BinaryArchive.EntryType.Dpx, "[8] Dpx" },
                {BinaryArchive.EntryType.Motion, "[9] Motion" },
                {BinaryArchive.EntryType.Tim2, "[10] Tim2" },
                {BinaryArchive.EntryType.CameraOctalTree, "[11] Camera Octal Tree" },
                {BinaryArchive.EntryType.AreaDataSpawn, "[12] Area Data Spawn" },
                {BinaryArchive.EntryType.AreaDataScript, "[13] Area Data Script" },
                {BinaryArchive.EntryType.FogColor, "[14] Fog Color" },
                {BinaryArchive.EntryType.ColorOctalTree, "[15] Color Octal Tree" },
                {BinaryArchive.EntryType.MotionTriggers, "[16] Motion Triggers" },
                {BinaryArchive.EntryType.Anb, "[17] Anb" },
                {BinaryArchive.EntryType.Pax, "[18] Pax" },
                {BinaryArchive.EntryType.MapCollision2, "[19] Map Collision2" },
                {BinaryArchive.EntryType.Motionset, "[20] Motionset" },
                {BinaryArchive.EntryType.BgObjPlacement, "[21] Bg Obj Placement" },
                {BinaryArchive.EntryType.Event, "[22] Event" },
                {BinaryArchive.EntryType.ModelCollision, "[23] Model Collision" },
                {BinaryArchive.EntryType.Imgd, "[24] Imgd" },
                {BinaryArchive.EntryType.Seqd, "[25] Seqd" },
                {BinaryArchive.EntryType.Unknown26, "[26] Unknown26" },
                {BinaryArchive.EntryType.Unknown27, "[27] Unknown27" },
                {BinaryArchive.EntryType.Layout, "[28] Layout" },
                {BinaryArchive.EntryType.Imgz, "[29] Imgz" },
                {BinaryArchive.EntryType.AnimationMap, "[30] Animation Map" },
                {BinaryArchive.EntryType.Seb, "[31] Seb" },
                {BinaryArchive.EntryType.Wd, "[32] Wd" },
                {BinaryArchive.EntryType.Unknown33, "[33] Unknown33" },
                {BinaryArchive.EntryType.IopVoice, "[34] Iop Voice" },
                {BinaryArchive.EntryType.Unknown35, "[35] Unknown35" },
                {BinaryArchive.EntryType.RawBitmap, "[36] Raw Bitmap" },
                {BinaryArchive.EntryType.MemoryCard, "[37] Memory Card" },
                {BinaryArchive.EntryType.WrappedCollisionData, "[38] Wrapped Collision Data" },
                {BinaryArchive.EntryType.Unknown39, "[39] Unknown39" },
                {BinaryArchive.EntryType.Unknown40, "[40] Unknown40" },
                {BinaryArchive.EntryType.Unknown41, "[41] Unknown41" },
                {BinaryArchive.EntryType.Minigame, "[42] Minigame" },
                {BinaryArchive.EntryType.JimiData, "[43] JimiData" },
                {BinaryArchive.EntryType.Progress, "[44] Progress" },
                {BinaryArchive.EntryType.Synthesis, "[45] Synthesis" },
                {BinaryArchive.EntryType.BarUnknown, "[46] Bar Unknown" },
                {BinaryArchive.EntryType.Vibration, "[47] Vibration" },
                {BinaryArchive.EntryType.Vag, "[48] Vag" }
            };
        }
    }
}
