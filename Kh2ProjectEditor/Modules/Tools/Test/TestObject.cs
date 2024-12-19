using Xe.BinaryMapper;

namespace Kh2ProjectEditor.Modules.Tools.Test
{
    internal class TestObject
    {
        //[Data(Count=4)] public byte[] padding1 { get; set; }
        [Data] public int id { get; set; }
        //[Data(Count = 7)] public byte[] padding2 { get; set; }
        [Data(Count = 32)] public string name { get; set; }
    }
}
