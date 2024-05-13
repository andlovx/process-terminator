# Process terminator

Solution bundling the process-terminator assembly containing the class `Xertified.ProcessTerminator.SignalProcess` that can be used for sending "signals" to Windows applications.

```csharp
// 
// Send interrupt signal to first process named myapp.exe:
// 

SignalProcess terminator = new SignalProcess
{
    Process = Process.GetProcessesByName("myapp.exe").First(),
    Signal = SignalType.Interrupt
};
terminator.SendSignal();
```

The main purpose is to support ordered termination of applications by allowing them to run cleanup code contrary to ordinary process kill that makes them exit immediately. This is accomplished i.e. by attaching to the program console and sending a break signal.

```csharp
// 
// Send terminate signal to all child processes:
// 

SignalProcess terminator = new SignalProcess();
terminator.SendSignal();
```

The default process is current process. When sending signal without specifying any process, the signal will be sent to all child processes of current process.

```csharp
// 
// Send terminate signal to named processes:
// 

SignalProcess terminator = new SignalProcess();
terminator.SendSignal(Process.GetProcessesByName("myapp.exe"));
```

This will send default signal (terminate) to all processes named myapp.exe. There's also static functions that accives the same result:

```csharp
// 
// Send terminate signal to named processes:
// 

SignalProcess.SendSignal("myapp.exe", SignalType.Default);
```



## Use case

Suppose you have a cross-platform program with signal handlers running cleanup code on terminate. On Windows, killing the process won't work because the process is immediate terminated. This assembly provides methods for stopping running processes allowing their signal handlers to run.

## Programs

Includes the console and explorer applications for testing purposes. Open two terminals for testing using `console.exe` where the same program acts as both sender and receiver.

### Exampel

Start program as receiver (terminal 1):

```shell
cmd> console.exe
Current process: {
  PID: 21932
  Name: console
}

Waiting for signal............
Received ControlBreak

Finished
```

Send interrupt from terminal 2:

```shell
cmd> console.exe --process=21932 --signal=interrupt
```
