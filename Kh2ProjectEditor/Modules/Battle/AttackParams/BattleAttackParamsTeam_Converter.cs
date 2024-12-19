using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsTeam_Converter : BaseEnumStringConverter<TeamType>
    {
        public BattleAttackParamsTeam_Converter()
        {
            Options = new Dictionary<TeamType, string>
            {
                {TeamType.Unk0, "[0] -"},
                {TeamType.Player, "[1] Player"},
                {TeamType.Unk2, "[2] ???"},
                {TeamType.Unk3, "[3] ???"},
                {TeamType.Unk4, "[4] ???"}
            };
        }
    }
}
