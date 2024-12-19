using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsType_Converter : BaseEnumStringConverter<AttackType>
    {
        public BattleAttackParamsType_Converter()
        {
            Options = new Dictionary<AttackType, string>
            {
                {AttackType.NormalAttack, "[0] -"},
                {AttackType.PierceArmor, "[1] Pierce Armor"},
                {AttackType.Guard, "[2] Guard"},
                {AttackType.SGuard, "[3] S Guard"},
                {AttackType.Special, "[4] Special"},
                {AttackType.Cure, "[5] Cure"},
                {AttackType.SCure, "[6] S Cure"}
            };
        }
    }
}
