using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsKind_Converter : BaseEnumStringConverter<KindType>
    {
        public BattleAttackParamsKind_Converter()
        {
            Options = new Dictionary<KindType, string>
            {
                {KindType.None, "[0] -"},
                {KindType.ComboFinisher, "[1] Combo Finisher"},
                {KindType.AirComboFinisher, "[2] Air Combo Finisher"},
                {KindType.ReactionCommand, "[4] Reaction Command"}
            };
        }
    }
}
