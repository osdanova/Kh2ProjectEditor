using Xe.BinaryMapper;

namespace Kh2ProjectEditor.Modules.Tools.Test
{
    internal class TestObject
    {
        public string FileName { get; set; }
        //[Data(Count=4)] public byte[] padding1 { get; set; }
        [Data] public int Id { get; set; }
        [Data] public int Unk { get; set; }
        //[Data(Count = 7)] public byte[] padding2 { get; set; }
        [Data(Count = 32)] public string Name { get; set; }
    }
}
