namespace Xertified.ProcessTerminator.Explorer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelFilter = new Label();
            textBoxFilter = new TextBox();
            labelSignal = new Label();
            comboBoxSignal = new ComboBox();
            listViewProcesses = new ListView();
            columnHeaderPID = new ColumnHeader();
            columnHeaderName = new ColumnHeader();
            columnHeaderPath = new ColumnHeader();
            columnHeaderMachine = new ColumnHeader();
            columnHeaderTitle = new ColumnHeader();
            buttonApply = new Button();
            buttonRefresh = new Button();
            buttonReset = new Button();
            SuspendLayout();
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(12, 9);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(45, 20);
            labelFilter.TabIndex = 0;
            labelFilter.Text = "Filter:";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(63, 6);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(185, 27);
            textBoxFilter.TabIndex = 1;
            textBoxFilter.TextChanged += TextBoxFilterChanged;
            // 
            // labelSignal
            // 
            labelSignal.AutoSize = true;
            labelSignal.Location = new Point(254, 9);
            labelSignal.Name = "labelSignal";
            labelSignal.Size = new Size(50, 20);
            labelSignal.TabIndex = 2;
            labelSignal.Text = "Signal";
            // 
            // comboBoxSignal
            // 
            comboBoxSignal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSignal.FormattingEnabled = true;
            comboBoxSignal.Items.AddRange(new object[] { "Terminate", "Interrupt", "Close", "Logoff", "Shutdown" });
            comboBoxSignal.Location = new Point(310, 6);
            comboBoxSignal.Name = "comboBoxSignal";
            comboBoxSignal.Size = new Size(210, 28);
            comboBoxSignal.TabIndex = 3;
            // 
            // listViewProcesses
            // 
            listViewProcesses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewProcesses.CheckBoxes = true;
            listViewProcesses.Columns.AddRange(new ColumnHeader[] { columnHeaderPID, columnHeaderName, columnHeaderPath, columnHeaderMachine, columnHeaderTitle });
            listViewProcesses.Location = new Point(12, 52);
            listViewProcesses.Name = "listViewProcesses";
            listViewProcesses.Size = new Size(758, 354);
            listViewProcesses.TabIndex = 4;
            listViewProcesses.UseCompatibleStateImageBehavior = false;
            listViewProcesses.View = View.Details;
            // 
            // columnHeaderPID
            // 
            columnHeaderPID.Text = "PID";
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            // 
            // columnHeaderPath
            // 
            columnHeaderPath.Text = "Path";
            // 
            // columnHeaderMachine
            // 
            columnHeaderMachine.Text = "Machine";
            // 
            // columnHeaderTitle
            // 
            columnHeaderTitle.Text = "Title";
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonApply.Enabled = false;
            buttonApply.Location = new Point(12, 412);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(94, 29);
            buttonApply.TabIndex = 5;
            buttonApply.Text = "&Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += ButtonApplyClick;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRefresh.Location = new Point(112, 412);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(94, 29);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.Text = "&Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefreshClick;
            // 
            // buttonReset
            // 
            buttonReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReset.Location = new Point(676, 412);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 7;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ButtonResetClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(buttonReset);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonApply);
            Controls.Add(listViewProcesses);
            Controls.Add(comboBoxSignal);
            Controls.Add(labelSignal);
            Controls.Add(textBoxFilter);
            Controls.Add(labelFilter);
            MinimumSize = new Size(550, 400);
            Name = "MainForm";
            Text = "Process Terminator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFilter;
        private TextBox textBoxFilter;
        private Label labelSignal;
        private ComboBox comboBoxSignal;
        private ListView listViewProcesses;
        private ColumnHeader columnHeaderName;
        private Button buttonApply;
        private ColumnHeader columnHeaderPath;
        private ColumnHeader columnHeaderMachine;
        private ColumnHeader columnHeaderTitle;
        private ColumnHeader columnHeaderPID;
        private Button buttonRefresh;
        private Button buttonReset;
    }
}
