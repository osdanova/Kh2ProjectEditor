using Kh2ProjectEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsRefact_Converter : BaseEnumStringConverter<RefactType>
    {
        public BattleAttackParamsRefact_Converter()
        {
            Options = new Dictionary<RefactType, string>
            {
                {RefactType.Reflect, "[0] Reflect"},
                {RefactType.Guard, "[1] Guard"},
                {RefactType.Nothing, "[2] Nothing"}
            };
        }
    }
}
