using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Battle;

namespace Kh2ProjectEditor.Modules.Battle.FormLevels
{
    internal partial class BattleFormLevels_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(FormName))] public byte id;
        [ObservableProperty] public byte level;
        [ObservableProperty] public byte antiRate;
        [ObservableProperty] public byte abilityLevel;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(AbilityName))] public ushort abilityId;
        [ObservableProperty] public int exp;
        public string FormName => GetFormNameFm(Id);
        public string AbilityName => DataFetcher.GetItemName(AbilityId);

        public BattleFormLevels_Wrapper(FormLevelsFile.Entry entry)
        {
            id = entry.Id;
            level = entry.Level;
            antiRate = entry.AntiRate;
            abilityLevel = entry.AbilityLevel;
            abilityId = entry.AbilityId;
            exp = entry.Exp;
        }

        public FormLevelsFile.Entry ToEntry()
        {
            return new FormLevelsFile.Entry
            {
                Id = id,
                Level = level,
                AntiRate = antiRate,
                AbilityLevel = abilityLevel,
                AbilityId = abilityId,
                Exp = exp
            };
        }

        internal string GetFormNameFm(byte formId)
        {
            switch (formId)
            {
                case 0:
                    return "Summon";
                case 1:
                    return "Valor";
                case 2:
                    return "Wisdom";
                case 3:
                    return "Limit";
                case 4:
                    return "Master";
                case 5:
                    return "Final";
                case 6:
                    return "Anti";
                default:
                    return "<INVALID>";
            }
        }
    }
}
