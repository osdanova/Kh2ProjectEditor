using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;
using KhLib.Kh2.Utils;

namespace Kh2ProjectEditor.Modules.Battle.PlayerParams
{
    internal partial class BattlePlayerParams_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort version;
        public string CharacterName => DataFetcher.GetCharacterName(characterId);
        [ObservableProperty][NotifyPropertyChangedFor(nameof(CharacterName))] public byte characterId;
        [ObservableProperty] public byte hp;
        [ObservableProperty] public byte mp;
        [ObservableProperty] public byte ap;
        [ObservableProperty] public byte strength;
        [ObservableProperty] public byte magic;
        [ObservableProperty] public byte defense;
        [ObservableProperty] public byte armorSlots;
        [ObservableProperty] public byte accessorySlots;
        [ObservableProperty] public byte itemSlots;

        public string Item1Name => DataFetcher.GetItemName(item1Id);
        [ObservableProperty] public bool item1Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item1Name))] public ushort item1Id;

        public string Item2Name => DataFetcher.GetItemName(item2Id);
        [ObservableProperty] public bool item2Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item2Name))] public ushort item2Id;

        public string Item3Name => DataFetcher.GetItemName(item3Id);
        [ObservableProperty] public bool item3Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item3Name))] public ushort item3Id;

        public string Item4Name => DataFetcher.GetItemName(item4Id);
        [ObservableProperty] public bool item4Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item4Name))] public ushort item4Id;

        public string Item5Name => DataFetcher.GetItemName(item5Id);
        [ObservableProperty] public bool item5Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item5Name))] public ushort item5Id;

        public string Item6Name => DataFetcher.GetItemName(item6Id);
        [ObservableProperty] public bool item6Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item6Name))] public ushort item6Id;

        public string Item7Name => DataFetcher.GetItemName(item7Id);
        [ObservableProperty] public bool item7Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item7Name))] public ushort item7Id;

        public string Item8Name => DataFetcher.GetItemName(item8Id);
        [ObservableProperty] public bool item8Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item8Name))] public ushort item8Id;

        public string Item9Name => DataFetcher.GetItemName(item9Id);
        [ObservableProperty] public bool item9Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item9Name))] public ushort item9Id;

        public string Item10Name => DataFetcher.GetItemName(item10Id);
        [ObservableProperty] public bool item10Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item10Name))] public ushort item10Id;

        public string Item11Name => DataFetcher.GetItemName(item11Id);
        [ObservableProperty] public bool item11Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item11Name))] public ushort item11Id;

        public string Item12Name => DataFetcher.GetItemName(item12Id);
        [ObservableProperty] public bool item12Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item12Name))] public ushort item12Id;

        public string Item13Name => DataFetcher.GetItemName(item13Id);
        [ObservableProperty] public bool item13Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item13Name))] public ushort item13Id;

        public string Item14Name => DataFetcher.GetItemName(item14Id);
        [ObservableProperty] public bool item14Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item14Name))] public ushort item14Id;

        public string Item15Name => DataFetcher.GetItemName(item15Id);
        [ObservableProperty] public bool item15Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item15Name))] public ushort item15Id;

        public string Item16Name => DataFetcher.GetItemName(item16Id);
        [ObservableProperty] public bool item16Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item16Name))] public ushort item16Id;

        public string Item17Name => DataFetcher.GetItemName(item17Id);
        [ObservableProperty] public bool item17Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item17Name))] public ushort item17Id;

        public string Item18Name => DataFetcher.GetItemName(item18Id);
        [ObservableProperty] public bool item18Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item18Name))] public ushort item18Id;

        public string Item19Name => DataFetcher.GetItemName(item19Id);
        [ObservableProperty] public bool item19Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item19Name))] public ushort item19Id;

        public string Item20Name => DataFetcher.GetItemName(item20Id);
        [ObservableProperty] public bool item20Flag;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item20Name))] public ushort item20Id;


        public BattlePlayerParams_Wrapper(PlayerParamsFile.Entry entry)
        {
            version = entry.Version;
            characterId = entry.CharacterId;
            hp = entry.Hp;
            mp = entry.Mp;
            ap = entry.Ap;
            strength = entry.Strength;
            magic = entry.Magic;
            defense = entry.Defense;
            armorSlots = entry.ArmorSlots;
            accessorySlots = entry.AccessorySlots;
            itemSlots = entry.ItemSlots;

            item1Flag = InventoryHelper.GetFlag(entry.Inventory[0]);
            item1Id = InventoryHelper.GetId(entry.Inventory[0]);

            item2Flag = InventoryHelper.GetFlag(entry.Inventory[1]);
            item2Id = InventoryHelper.GetId(entry.Inventory[1]);

            item3Flag = InventoryHelper.GetFlag(entry.Inventory[2]);
            item3Id = InventoryHelper.GetId(entry.Inventory[2]);

            item4Flag = InventoryHelper.GetFlag(entry.Inventory[3]);
            item4Id = InventoryHelper.GetId(entry.Inventory[3]);

            item5Flag = InventoryHelper.GetFlag(entry.Inventory[4]);
            item5Id = InventoryHelper.GetId(entry.Inventory[4]);

            item6Flag = InventoryHelper.GetFlag(entry.Inventory[5]);
            item6Id = InventoryHelper.GetId(entry.Inventory[5]);

            item7Flag = InventoryHelper.GetFlag(entry.Inventory[6]);
            item7Id = InventoryHelper.GetId(entry.Inventory[6]);

            item8Flag = InventoryHelper.GetFlag(entry.Inventory[7]);
            item8Id = InventoryHelper.GetId(entry.Inventory[7]);

            item9Flag = InventoryHelper.GetFlag(entry.Inventory[8]);
            item9Id = InventoryHelper.GetId(entry.Inventory[8]);

            item10Flag = InventoryHelper.GetFlag(entry.Inventory[9]);
            item10Id = InventoryHelper.GetId(entry.Inventory[9]);

            item11Flag = InventoryHelper.GetFlag(entry.Inventory[10]);
            item11Id = InventoryHelper.GetId(entry.Inventory[10]);

            item12Flag = InventoryHelper.GetFlag(entry.Inventory[11]);
            item12Id = InventoryHelper.GetId(entry.Inventory[11]);

            item13Flag = InventoryHelper.GetFlag(entry.Inventory[12]);
            item13Id = InventoryHelper.GetId(entry.Inventory[12]);

            item14Flag = InventoryHelper.GetFlag(entry.Inventory[13]);
            item14Id = InventoryHelper.GetId(entry.Inventory[13]);

            item15Flag = InventoryHelper.GetFlag(entry.Inventory[14]);
            item15Id = InventoryHelper.GetId(entry.Inventory[14]);

            item16Flag = InventoryHelper.GetFlag(entry.Inventory[15]);
            item16Id = InventoryHelper.GetId(entry.Inventory[15]);

            item17Flag = InventoryHelper.GetFlag(entry.Inventory[16]);
            item17Id = InventoryHelper.GetId(entry.Inventory[16]);

            item18Flag = InventoryHelper.GetFlag(entry.Inventory[17]);
            item18Id = InventoryHelper.GetId(entry.Inventory[17]);

            item19Flag = InventoryHelper.GetFlag(entry.Inventory[18]);
            item19Id = InventoryHelper.GetId(entry.Inventory[18]);

            item20Flag = InventoryHelper.GetFlag(entry.Inventory[19]);
            item20Id = InventoryHelper.GetId(entry.Inventory[19]);
        }

        public PlayerParamsFile.Entry ToEntry()
        {
            PlayerParamsFile.Entry entry = new PlayerParamsFile.Entry
            {
                Version = version,
                CharacterId = characterId,
                Hp = hp,
                Mp = mp,
                Ap = ap,
                Strength = strength,
                Magic = magic,
                Defense = defense,
                ArmorSlots = armorSlots,
                AccessorySlots = accessorySlots,
                ItemSlots = itemSlots,
            };

            InventoryHelper.SetFlag(ref entry.Inventory[0], item1Flag);
            InventoryHelper.SetId(ref entry.Inventory[0], item1Id);

            InventoryHelper.SetFlag(ref entry.Inventory[1], item2Flag);
            InventoryHelper.SetId(ref entry.Inventory[1], item2Id);

            InventoryHelper.SetFlag(ref entry.Inventory[2], item3Flag);
            InventoryHelper.SetId(ref entry.Inventory[2], item3Id);

            InventoryHelper.SetFlag(ref entry.Inventory[3], item4Flag);
            InventoryHelper.SetId(ref entry.Inventory[3], item4Id);

            InventoryHelper.SetFlag(ref entry.Inventory[4], item5Flag);
            InventoryHelper.SetId(ref entry.Inventory[4], item5Id);

            InventoryHelper.SetFlag(ref entry.Inventory[5], item6Flag);
            InventoryHelper.SetId(ref entry.Inventory[5], item6Id);

            InventoryHelper.SetFlag(ref entry.Inventory[6], item7Flag);
            InventoryHelper.SetId(ref entry.Inventory[6], item7Id);

            InventoryHelper.SetFlag(ref entry.Inventory[7], item8Flag);
            InventoryHelper.SetId(ref entry.Inventory[7], item8Id);

            InventoryHelper.SetFlag(ref entry.Inventory[8], item9Flag);
            InventoryHelper.SetId(ref entry.Inventory[8], item9Id);

            InventoryHelper.SetFlag(ref entry.Inventory[9], item10Flag);
            InventoryHelper.SetId(ref entry.Inventory[9], item10Id);

            InventoryHelper.SetFlag(ref entry.Inventory[10], item11Flag);
            InventoryHelper.SetId(ref entry.Inventory[10], item11Id);

            InventoryHelper.SetFlag(ref entry.Inventory[11], item12Flag);
            InventoryHelper.SetId(ref entry.Inventory[11], item12Id);

            InventoryHelper.SetFlag(ref entry.Inventory[12], item13Flag);
            InventoryHelper.SetId(ref entry.Inventory[12], item13Id);

            InventoryHelper.SetFlag(ref entry.Inventory[13], item14Flag);
            InventoryHelper.SetId(ref entry.Inventory[13], item14Id);

            InventoryHelper.SetFlag(ref entry.Inventory[14], item15Flag);
            InventoryHelper.SetId(ref entry.Inventory[14], item15Id);

            InventoryHelper.SetFlag(ref entry.Inventory[15], item16Flag);
            InventoryHelper.SetId(ref entry.Inventory[15], item16Id);

            InventoryHelper.SetFlag(ref entry.Inventory[16], item17Flag);
            InventoryHelper.SetId(ref entry.Inventory[16], item17Id);

            InventoryHelper.SetFlag(ref entry.Inventory[17], item18Flag);
            InventoryHelper.SetId(ref entry.Inventory[17], item18Id);

            InventoryHelper.SetFlag(ref entry.Inventory[18], item19Flag);
            InventoryHelper.SetId(ref entry.Inventory[18], item19Id);

            InventoryHelper.SetFlag(ref entry.Inventory[19], item20Flag);
            InventoryHelper.SetId(ref entry.Inventory[19], item20Id);

            return entry;
        }
    }
}
