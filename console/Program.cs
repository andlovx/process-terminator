using System;
using System.Diagnostics;
using System.Threading;

namespace Xertified.ProcessTerminator.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SignalProcess signalProcess = new SignalProcess();

                Options options = new Options(signalProcess);
                options.Parse(args);

                if (options.IsTester)
                {
                    WaitForSignal();
                }
                else
                {
                    signalProcess.SendSignal();
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
            }
        }

        static void WaitForSignal()
        {
            Process current = Process.GetCurrentProcess();
            bool finished = false;

            System.Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                finished = true;

                System.Console.WriteLine();
                System.Console.WriteLine("Received {0}", e.SpecialKey.ToString());
            };

            System.Console.WriteLine(
                "Current process: {{\n" +
                "  PID: {0}\n" +
                "  Name: {1}\n" +
                "}}\n", current.Id, current.ProcessName);

            System.Console.Write("Waiting for signal");
            while (!finished)
            {
                System.Console.Write(".");
                Thread.Sleep(1000);
            }

            System.Console.Write("Finished");
        }
    }
}
