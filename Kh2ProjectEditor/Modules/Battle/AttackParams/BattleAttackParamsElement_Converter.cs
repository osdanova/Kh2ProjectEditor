using Kh2ProjectEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KhLib.Kh2.Battle.AttackParamsFile;

namespace Kh2ProjectEditor.Modules.Battle.AttackParams
{
    internal class BattleAttackParamsElement_Converter : BaseEnumStringConverter<ElementType>
    {
        public BattleAttackParamsElement_Converter()
        {
            Options = new Dictionary<ElementType, string>
            {
                {ElementType.Neutral, "[0] Neutral"},
                {ElementType.Fire, "[1] Fire"},
                {ElementType.Blizzard, "[2] Blizzard"},
                {ElementType.Thunder, "[3] Thunder"},
                {ElementType.Dark, "[4] Dark"},
                {ElementType.Special, "[5] Special"},
                {ElementType.Absolute, "[6] Absolute"}
            };
        }
    }
}
