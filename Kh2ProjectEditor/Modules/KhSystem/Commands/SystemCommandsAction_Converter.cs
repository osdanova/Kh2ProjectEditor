﻿using System.Collections.Generic;
using Kh2ProjectEditor.Utils;
using static KhLib.Kh2.KhSystem.CommandsFile;

namespace Kh2ProjectEditor.Modules.KhSystem.Commands
{
    public class SystemCommandsAction_Converter : BaseEnumStringConverter<Action>
    {
        public SystemCommandsAction_Converter()
        {
            Options = new Dictionary<Action, string>
            {
                {Action.Null, "[0] -"},
                {Action.Idle, "[1] Idle"},
                {Action.Jump, "[2] Jump"}
            };
        }
    }
}
