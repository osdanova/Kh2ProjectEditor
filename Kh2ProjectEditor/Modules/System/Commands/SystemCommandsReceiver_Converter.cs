using System.Collections.Generic;
using Kh2ProjectEditor.Utils;
using static KhLib.Kh2.System.CommandsFile;

namespace Kh2ProjectEditor.Modules.System.Commands
{
    public class SystemCommandsReceiver_Converter : BaseEnumStringConverter<Receiver>
    {
        public SystemCommandsReceiver_Converter()
        {
            Options = new Dictionary<Receiver, string>
            {
                {Receiver.Player, "[0] Player"},
                {Receiver.Target, "[1] Target"},
                {Receiver.Both, "[2] Both"}
            };
        }
    }
}
