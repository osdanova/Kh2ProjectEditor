using System.Collections.Generic;
using Kh2ProjectEditor.Utils;
using static KhLib.Kh2.System.CommandsFile;

namespace Kh2ProjectEditor.Modules.System.Commands
{
    public class SystemCommandsIcon_Converter : BaseEnumStringConverter<Icon>
    {
        public SystemCommandsIcon_Converter()
        {
            Options = new Dictionary<Icon, string>
            {
                {Icon.Null, "[0] -"},
                {Icon.Attack, "[1] Attack"},
                {Icon.Magic, "[2] Magic"},
                {Icon.Item, "[3] Item"},
                {Icon.Form, "[4] Form"},
                {Icon.Summon, "[5] Summon"},
                {Icon.Friend, "[6] Friend"},
                {Icon.Limit, "[7] Limit"}
            };
        }
    }
}
