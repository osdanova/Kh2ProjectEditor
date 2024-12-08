using System.Collections.Generic;
using Kh2ProjectEditor.Utils;
using static KhLib.Kh2.KhSystem.CommandsFile;

namespace Kh2ProjectEditor.Modules.KhSystem.Commands
{
    public class SystemCommandsCamera_Converter : BaseEnumStringConverter<Camera>
    {
        public SystemCommandsCamera_Converter()
        {
            Options = new Dictionary<Camera, string>
            {
                {Camera.Null, "[0] -"},
                {Camera.Watch, "[1] Watch"},
                {Camera.LockOn, "[2] Lock On"},
                {Camera.WatchLockOn, "[3] Watch Lock On"}
            };
        }
    }
}
