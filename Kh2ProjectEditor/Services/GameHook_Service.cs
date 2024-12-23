using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using System.Diagnostics;
using System.Linq;

namespace Kh2ProjectEditor.Services
{
    public partial class GameHook_Service : SingletonBase<GameHook_Service>
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(IsHooked))] Process gameProcess;
        public bool IsHooked => gameProcess != null;

        public void HookProcess(Process gameProc)
        {
            GameProcess = gameProc;
        }

        public void DetectAndHook()
        {
            Process proc = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
            HookProcess(proc);
        }
    }
}
