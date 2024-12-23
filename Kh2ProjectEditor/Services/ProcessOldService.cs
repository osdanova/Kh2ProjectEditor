using System;
using System.Diagnostics;
using System.Threading;

namespace Kh2ProjectEditor.Services
{
    public class ProcessOldService
    {
        private static readonly string PROCESS_NAME = "KINGDOM HEARTS II FINAL MIX";
        public static Process ThisProcess;

        //-----------------------------------------------------------------------------------------------------------
        // TIMER
        //-----------------------------------------------------------------------------------------------------------
        private static PeriodicTimer PTimer;
        private static int Frecuency = 100; // In milliseconds
        private static async void startTimer()
        {
            // Only one timer can be running
            if (PTimer != null)
                return;
            
            PTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(Frecuency));
            while (await PTimer.WaitForNextTickAsync())
            {
                checkProcess();
                //if(MessageService.Instance.MsgEntries == null)
                //{
                //    MessageService.Read();
                //}
            }
        }
        //-----------------------------------------------------------------------------------------------------------

        public static async void startService()
        {
            startTimer();
        }

        // Checks if the process is alive and sets or unsets the variable
        private static void checkProcess()
        {
            Process searchedProcess = searchProcess();
            //Debug.WriteLine("Checking");

            if (ThisProcess != null && searchedProcess == null)
            {
                ThisProcess = null;
            }
            else if(ThisProcess == null && searchedProcess != null)
            {
                ThisProcess = searchedProcess;
                //Debug.WriteLine("Process address: " + ThisProcess.MainModule.BaseAddress);
            }
        }

        // Searches for the process
        private static Process searchProcess()
        {
            Process[] processes = Process.GetProcessesByName(PROCESS_NAME);
            if(processes.Length > 0)
            {
                return processes[0];
            }
            else
            {
                return null;
            }
        }
    }
}
