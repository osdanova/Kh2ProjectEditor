﻿using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using System.Diagnostics;
using System.Linq;

namespace Kh2ProjectEditor.Services
{
    public partial class Process_Service : SingletonBase<Process_Service>
    {
        private static readonly string _processName = "KINGDOM HEARTS II FINAL MIX";

        /******************************************
         * Properties
         ******************************************/

        [ObservableProperty][NotifyPropertyChangedFor(nameof(IsAlive))] public Process gameProcess;
        public bool IsAlive => (GameProcess != null && !GameProcess.HasExited);

        /******************************************
         * Constructor
         ******************************************/
        public Process_Service()
        {
            _timer = new TimerTask(timerInterval, AutoDetect);
            IsAutoDetectEnabled = false;
        }

        /******************************************
         * Functions
         ******************************************/
        public void SetProcess(Process proc)
        {
            GameProcess = proc;
        }
        public void AutoDetect()
        {
            Process proc = Process.GetProcessesByName(_processName).FirstOrDefault();
            SetProcess(proc);
        }

        /******************************************
         * Auto-detect Timer
         ******************************************/
        private TimerTask _timer;
        private double timerInterval = 1000;
        public bool IsAutoDetectEnabled { get; set; }

        public void EnableAutoDetect()
        {
            _timer.Start();
            IsAutoDetectEnabled = true;
        }
        public void DisableAutoDetect()
        {
            _timer.Stop();
            IsAutoDetectEnabled = false;
        }
    }
}
