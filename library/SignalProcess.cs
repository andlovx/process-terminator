using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Xertified.ProcessTerminator
{
    public enum SignalType
    {
        Terminate = 0,
        Interrupt = 1,
        Break = 1,
        Close = 2,
        Logoff = 5,
        Shutdown = 6,
        Default = Terminate
    }

    /// <summary>
    /// Sends signal to process by attaching to its console.
    /// </summary>
    /// <see cref="https://stackoverflow.com/questions/813086/can-i-send-a-ctrl-c-sigint-to-an-application-on-windows"/>
    public class SignalProcess
    {
        [DllImport("kernel32.dll")]
        static extern int GetLastError();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);

        delegate bool ConsoleCtrlDelegate(SignalType dwCtrlEvent);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GenerateConsoleCtrlEvent(SignalType dwCtrlEvent, uint dwProcessGroupId);

        public SignalProcess()
        {
            Process = Process.GetCurrentProcess();
            Signal = SignalType.Default;
        }

        public SignalProcess(SignalType signal)
        {
            Process = Process.GetCurrentProcess();
            Signal = signal;
        }

        public SignalProcess(Process process)
        {
            Process = process;
            Signal = SignalType.Default;
        }

        public SignalProcess(Process process, SignalType signal)
        {
            Process = process;
            Signal = signal;
        }

        public SignalType Signal { get; set; }
        public Process Process { get; set; }

        public void SendInterrupt()
        {
            SendInterrupt(Process);
        }

        public void SendInterrupt(int pid)
        {
            SendInterrupt(Process.GetProcessById(pid));
        }

        public void SendInterrupt(Process process)
        {
            SendSignal(process, SignalType.Terminate);
        }

        public void SendInterrupt(Process[] processes)
        {
            SendSignal(processes, SignalType.Terminate);
        }

        public void SendInterrupt(string process)
        {
            SendSignal(process, SignalType.Terminate);
        }

        public void SendTerminate()
        {
            SendTerminate(Process);
        }

        public void SendTerminate(int pid)
        {
            SendInterrupt(Process.GetProcessById(pid));
        }

        public void SendTerminate(Process process)
        {
            SendSignal(process, SignalType.Terminate);
        }

        public void SendTerminate(Process[] processes)
        {
            SendSignal(processes, SignalType.Terminate);
        }

        public void SendTerminate(string process)
        {
            SendSignal(process, SignalType.Terminate);
        }

        public void SendSignal()
        {
            SendSignal(Process, Signal);
        }

        public void SendSignal(int pid)
        {
            SendSignal(Process.GetProcessById(pid));
        }

        public void SendSignal(Process process)
        {
            SendSignal(process, Signal);
        }

        public void SendSignal(Process[] processes)
        {
            SendSignal(processes, Signal);
        }

        public void SendSignal(string process)
        {
            SendSignal(process, Signal);
        }

        public void SendSignal(SignalType signal)
        {
            SendSignal(Process, signal);
        }

        public static void SendSignal(int pid, SignalType signal)
        {
            SendSignal(Process.GetProcessById(pid), signal);
        }

        public static void SendSignal(Process[] processes, SignalType signal)
        {
            foreach (var p in processes)
            {
                SendSignal(p, signal);
            }
        }

        public static void SendSignal(string process, SignalType signal)
        {
            foreach (var p in Process.GetProcessesByName(process))
            {
                SendSignal(p, signal);
            }
        }

        public static void SendSignal(Process process, SignalType signal)
        {
            Process current = Process.GetCurrentProcess();
            bool isDetached = FreeConsole();

            if (AttachConsole((uint)process.Id))
            {
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(signal, 0);
                FreeConsole();

                process.WaitForExit(2000);
                SetConsoleCtrlHandler(null, false);
            }

            if (isDetached)
            {
                if (!AttachConsole((uint)current.Id))
                {
                    if (GetLastError() == 31) // ERROR_GEN_FAILURE
                    {
                        AllocConsole();
                    }
                }
            }
        }
    }
}
