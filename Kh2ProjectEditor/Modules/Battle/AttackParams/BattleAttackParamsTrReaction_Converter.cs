using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsTrReaction_Converter : BaseEnumStringConverter<TrReactionType>
    {
        public BattleAttackParamsTrReaction_Converter()
        {
            Options = new Dictionary<TrReactionType, string>
            {
                {TrReactionType.Attack, "[0] -"},
                {TrReactionType.Charge, "[1] Charge"},
                {TrReactionType.Crash, "[2] Crash"},
                {TrReactionType.Wall, "[3] Wall"},
            };
        }
    }
}
