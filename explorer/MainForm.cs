using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Xertified.ProcessTerminator.Explorer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            comboBoxSignal.SelectedIndex = 0;
            textBoxFilter.Text = "";

            listViewProcesses.ItemChecked += ListViewProcessesItemChecked;

            UpdateProcessView();
        }

        private void ListViewProcessesItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            buttonApply.Enabled = listViewProcesses.CheckedItems.Count > 0;
        }

        private void UpdateProcessView()
        {
            UpdateProcessView(textBoxFilter.Text);
        }

        private void UpdateProcessView(string processName)
        {
            Regex regex = new(".*" + processName + ".*");

            listViewProcesses.BeginUpdate();
            listViewProcesses.Items.Clear();

            foreach (var process in Process.GetProcesses())
            {
                if (regex.IsMatch(process.ProcessName))
                {
                    ListViewItem item = new(process.Id.ToString()); // PID
                    item.SubItems.Add(process.ProcessName);         // Name
                    item.SubItems.Add(GetProcessPath(process));     // Path
                    item.SubItems.Add(GetProcessHost(process));     // Machine
                    item.SubItems.Add(process.MainWindowTitle);     // Title

                    listViewProcesses.Items.Add(item);
                }
            }

            listViewProcesses.EndUpdate();
        }

        private void TextBoxFilterChanged(object sender, EventArgs e)
        {
            UpdateProcessView();
        }

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            SignalType signal = GetSignal(comboBoxSignal.Items[comboBoxSignal.SelectedIndex].ToString());

            foreach (ListViewItem item in listViewProcesses.CheckedItems)
            {
                int pid = int.Parse(item.SubItems[0].Text);
                SignalProcess.SendSignal(pid, signal);
            }
        }

        private void ButtonResetClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            UpdateProcessView();
        }

        private static SignalType GetSignal(string value)
        {
            switch (value)
            {
                case "Terminate":
                    return SignalType.Terminate;
                case "Interrupt":
                    return SignalType.Interrupt;
                case "Close":
                    return SignalType.Close;
                case "Logoff":
                    return SignalType.Close;
                case "Shutdown":
                    return SignalType.Shutdown;
                default:
                    throw new ArgumentException("Unknown signal " + value);
            }
        }

        private static string GetProcessPath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return "";
            }
        }

        private static string GetProcessHost(Process process)
        {
            return process.MachineName == "." ? "LOCALHOST" : process.MachineName;
        }
    }
}
