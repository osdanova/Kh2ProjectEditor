using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;
using KhLib.Kh2.Utils;
using static KhLib.Kh2.KhSystem.CommandsFile;

namespace Kh2ProjectEditor.Modules.KhSystem.Commands
{
    internal partial class SystemCommandsEntry_Wrapper : ObservableObject
    {
        [ObservableProperty] public ushort id;
        [ObservableProperty] public ushort execute;
        [ObservableProperty] public short argument;
        [ObservableProperty] public sbyte subMenu;
        [ObservableProperty] public Icon cmdIcon;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CommandMessage))]
        public int messageId;
        [ObservableProperty] public int flags;
        [ObservableProperty] public float range;
        [ObservableProperty] public float dir;
        [ObservableProperty] public float dirRange;
        [ObservableProperty] public byte cost;
        [ObservableProperty] public Camera cmdCamera;
        [ObservableProperty] public byte priority;
        [ObservableProperty] public Receiver cmdReceiver;
        [ObservableProperty] public ushort time;
        [ObservableProperty] public ushort require;
        [ObservableProperty] public byte mark;
        [ObservableProperty] public Action cmdAction;
        [ObservableProperty] public ushort reactionCount;
        [ObservableProperty] public ushort distRange;
        [ObservableProperty] public ushort score;
        [ObservableProperty] public ushort disableForm;
        [ObservableProperty] public byte group;
        [ObservableProperty] public byte reserve;

        public string CommandMessage => MessageService.Instance.GetEntryText(messageId);

        public bool Cursor
        {
            get => BitUtils.Int.GetBit(Flags, 0);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 0, value);
        }
        public bool Land
        {
            get => BitUtils.Int.GetBit(Flags, 1);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 1, value);
        }
        public bool Force
        {
            get => BitUtils.Int.GetBit(Flags, 2);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 2, value);
        }
        public bool Combo
        {
            get => BitUtils.Int.GetBit(Flags, 3);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 3, value);
        }
        public bool Battle
        {
            get => BitUtils.Int.GetBit(Flags, 4);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 4, value);
        }
        public bool Secure
        {
            get => BitUtils.Int.GetBit(Flags, 5);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 5, value);
        }
        public bool RequireFlag
        {
            get => BitUtils.Int.GetBit(Flags, 6);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 6, value);
        }
        public bool NoCombo
        {
            get => BitUtils.Int.GetBit(Flags, 7);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 7, value);
        }
        public bool Drive
        {
            get => BitUtils.Int.GetBit(Flags, 8);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 8, value);
        }
        public bool Short
        {
            get => BitUtils.Int.GetBit(Flags, 9);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 9, value);
        }
        public bool DisableSora
        {
            get => BitUtils.Int.GetBit(Flags, 10);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 10, value);
        }
        public bool DisableRoxas
        {
            get => BitUtils.Int.GetBit(Flags, 11);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 11, value);
        }
        public bool DisableLionSora
        {
            get => BitUtils.Int.GetBit(Flags, 12);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 12, value);
        }
        public bool DisableLimitForm
        {
            get => BitUtils.Int.GetBit(Flags, 13);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 13, value);
        }
        // Flag bit 14 is unused
        public bool DisableSkateboard
        {
            get => BitUtils.Int.GetBit(Flags, 15);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 15, value);
        }
        public bool InBattleOnly
        {
            get => BitUtils.Int.GetBit(Flags, 16);
            set => Flags = (ushort)BitUtils.Int.SetBit(Flags, 16, value);
        }


        public SystemCommandsEntry_Wrapper(Entry entry)
        {
            id = entry.Id;
            execute = entry.Execute;
            argument = entry.Argument;
            subMenu = entry.SubMenu;
            cmdIcon = entry.CmdIcon;
            messageId = entry.MessageId;
            flags = entry.Flags;
            range = entry.Range;
            dir = entry.Dir;
            dirRange = entry.DirRange;
            cost = entry.Cost;
            cmdCamera = entry.CmdCamera;
            priority = entry.Priority;
            cmdReceiver = entry.CmdReceiver;
            time = entry.Time;
            require = entry.Require;
            mark = entry.Mark;
            cmdAction = entry.CmdAction;
            reactionCount = entry.ReactionCount;
            distRange = entry.DistRange;
            score = entry.Score;
            disableForm = entry.DisableForm;
            group = entry.Group;
            reserve = entry.Reserve;
        }

        public Entry ToEntry()
        {
            return new Entry
            {
                Id = id,
                Execute = execute,
                Argument = argument,
                SubMenu = subMenu,
                CmdIcon = cmdIcon,
                MessageId = messageId,
                Flags = flags,
                Range = range,
                Dir = dir,
                DirRange = dirRange,
                Cost = cost,
                CmdCamera = cmdCamera,
                Priority = priority,
                CmdReceiver = cmdReceiver,
                Time = time,
                Require = require,
                Mark = mark,
                CmdAction = cmdAction,
                ReactionCount = reactionCount,
                DistRange = distRange,
                Score = score,
                DisableForm = disableForm,
                Group = group,
                Reserve = reserve
            };
        }
    }
}
