using Kh2ProjectEditor.Services;
using System.IO;
using Xe.BinaryMapper;

namespace Kh2ProjectEditor.Modules.Tools.EntityList
{
    internal class ToolsEntityList_DataModel
    {
        public StatSheet.Entry LoadedSheet { get; set; }
        public StatSheet.Entry LoadedSheet2 { get; set; }
        public StatSheet.Entry LoadedSheet3 { get; set; }

        public void LoadSheet()
        {
            int firstSheetAddress = 0x2A20C58;

            byte[] sheetBytes = MemSharp_Service.Instance.Read<byte>(firstSheetAddress, 632);
            byte[] sheetBytes2 = MemSharp_Service.Instance.Read<byte>(firstSheetAddress - (632 * 1), 632);
            byte[] sheetBytes3 = MemSharp_Service.Instance.Read<byte>(firstSheetAddress - (632 * 2), 632);

            using (MemoryStream stream = new MemoryStream(sheetBytes))
            {
                LoadedSheet = BinaryMapping.ReadObject<StatSheet.Entry>(stream);
            }
            using (MemoryStream stream = new MemoryStream(sheetBytes2))
            {
                LoadedSheet2 = BinaryMapping.ReadObject<StatSheet.Entry>(stream);
            }
            using (MemoryStream stream = new MemoryStream(sheetBytes3))
            {
                LoadedSheet3 = BinaryMapping.ReadObject<StatSheet.Entry>(stream);
            }
        }
    }
}
