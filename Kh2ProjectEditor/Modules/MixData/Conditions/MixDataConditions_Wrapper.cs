using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Mixdata;
using static KhLib.Kh2.Mixdata.ConditionsFile;

namespace Kh2ProjectEditor.Modules.MixData.Conditions
{
    internal partial class MixDataConditions_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Message))] public ushort messageId;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Reward))] public ushort rewardId;
        [ObservableProperty] public RewardType rewardType;
        [ObservableProperty] public byte conditionType;
        [ObservableProperty] public byte rank;
        [ObservableProperty] public CountType countType;
        [ObservableProperty] public ushort count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(MenuFlag))] public short menuFlagId;
        public string Message => Message_Service.Instance.GetSysText(MessageId);
        public string Reward => GetRewardName();
        public string MenuFlag => DataFetcher.GetMenuFlagName((sbyte)MenuFlagId);

        public MixDataConditions_Wrapper(ConditionsFile.Entry entry)
        {
            messageId = entry.MessageId;
            rewardId = entry.RewardId;
            rewardType = entry.RewardType;
            conditionType = entry.ConditionType;
            rank = entry.Rank;
            countType = entry.CountType;
            count = entry.Count;
            menuFlagId = entry.MenuFlagId;
        }

        public ConditionsFile.Entry ToEntry()
        {
            return new ConditionsFile.Entry
            {
                MessageId = messageId,
                RewardId = rewardId,
                RewardType = rewardType,
                ConditionType = conditionType,
                Rank = rank,
                CountType = countType,
                Count = count,
                MenuFlagId = menuFlagId
            };
        }

        string GetRewardName()
        {
            if(RewardType == RewardType.Upgrade)
            {
                return "<???>";
            }

            return DataFetcher.GetItemName(RewardId);
        }
    }
}
