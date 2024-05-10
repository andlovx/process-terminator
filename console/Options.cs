using System;
using System.Diagnostics;
using System.Linq;

namespace Xertified.ProcessTerminator.Console
{
    readonly struct Option
    {
        public readonly string key;
        public readonly string val;

        public Option(string arg)
        {
            var parts = arg.Split('=');
            if (parts.Length == 2)
            {
                key = parts[0];
                val = parts[1];
            }
            else
            {
                key = parts[0];
                val = "";
            }
        }
    }

    internal class Options
    {
        private readonly SignalProcess terminator;

        public bool IsTester { get; set; }

        public Options(SignalProcess terminator)
        {
            this.terminator = terminator;
        }

        public void Parse(string[] args)
        {
            if (args.Length == 0)
            {
                IsTester = true;
            }

            foreach (string arg in args)
            {
                Option opt = new Option(arg);

                switch (opt.key)
                {
                    case "-h":
                    case "--help":
                    case "/?":
                        Usage();
                        Environment.Exit(0);
                        break;
                    case "--process":
                        terminator.Process = GetProcess(opt.val);
                        break;
                    case "--signal":
                        terminator.Signal = GetSignal(opt.val);
                        break;
                }
            }
        }

        private void Usage()
        {
            System.Console.WriteLine("terminator - send signal to process");
            System.Console.WriteLine();
            System.Console.WriteLine("Usage: terminator --process={id|name} [--signal=type]");
            System.Console.WriteLine("       terminator");
            System.Console.WriteLine();
            System.Console.WriteLine("Options:");
            System.Console.WriteLine("  --process=value:  The target process for signal. The values is either an PID or program name.");
            System.Console.WriteLine("  --signal=type:    Send signal type. The value is either one of terminate, interrupt, close, logoff or shutdown.");
            System.Console.WriteLine();
            System.Console.WriteLine("Notice:");
            System.Console.WriteLine("  1. When started without arguments, the program acts as a test driver that can be signaled.");
            System.Console.WriteLine();
            System.Console.WriteLine("Copyright (C) 2024 Xertified AB");
        }

        private Process GetProcess(string value)
        {
            if (value.All(char.IsNumber))
            {
                return Process.GetProcessById(int.Parse(value));
            }
            else
            {
                return Process.GetProcessesByName(value).First();
            }
        }

        private static SignalType GetSignal(string value)
        {
            switch (value)
            {
                case "terminate":
                    return SignalType.Terminate;
                case "interrupt":
                    return SignalType.Interrupt;
                case "close":
                    return SignalType.Close;
                case "logoff":
                    return SignalType.Close;
                case "shutdown":
                    return SignalType.Shutdown;
                default:
                    throw new ArgumentException("Unknown signal " + value);
            }
        }
    }
}
