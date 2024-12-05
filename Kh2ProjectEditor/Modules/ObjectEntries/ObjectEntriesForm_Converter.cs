using Kh2ProjectEditor.Utils;
using System.Collections.Generic;
using static KhLib.Kh2.ObjectEntryFile;

namespace Kh2ProjectEditor.Modules.ObjectEntries
{
    public class ObjectEntriesForm_Converter : BaseEnumStringConverter<Form>
    {
        public ObjectEntriesForm_Converter()
        {
            Options = new Dictionary<Form, string>
            {
                {Form.SoraRoxasDefault, "[0] Sora/Roxas"},
                {Form.ValorForm, "[1] Valor"},
                {Form.WisdomForm, "[2] Wisdom"},
                {Form.LimitForm, "[3] Limit"},
                {Form.MasterForm, "[4] Master"},
                {Form.FinalForm, "[5] Final"},
                {Form.AntiForm, "[6] Antiform"},
                {Form.LionKingSora, "[7] Lion"},
                {Form.AtlanticaSora, "[8] Mermaid"},
                {Form.SoraCarpet, "[9] Carpet"},
                {Form.RoxasDualWield, "[10] Roxas dual wield"},
                {Form.Default, "[11] Default"},
                {Form.CubeCardForm, "[12] Cube/Card"},
            };
        }
    }
}
