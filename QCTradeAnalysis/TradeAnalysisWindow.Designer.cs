namespace QCTradeAnalysis
{
    partial class TradeAnalysisWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.returnCharts = new System.Windows.Forms.FlowLayoutPanel();
            this.positiveReturnsPerSymbolGroup = new System.Windows.Forms.GroupBox();
            this.positiveReturnsPerSymbol = new LiveCharts.WinForms.PieChart();
            this.negativeReturnsPerSymbolGroup = new System.Windows.Forms.GroupBox();
            this.negativeReturnsPerSymbol = new LiveCharts.WinForms.PieChart();
            this.longShortBalanceGroup = new System.Windows.Forms.GroupBox();
            this.longShortBalanceChart = new LiveCharts.WinForms.CartesianChart();
            this.returnsDistributionGroup = new System.Windows.Forms.GroupBox();
            this.returnsDistributionChart = new LiveCharts.WinForms.CartesianChart();
            this.returnsOverTimeGroup = new System.Windows.Forms.GroupBox();
            this.returnsOverTimeChart = new LiveCharts.WinForms.CartesianChart();
            this.tradesOverTimeGroup = new System.Windows.Forms.GroupBox();
            this.tradesOverTimeChart = new LiveCharts.WinForms.CartesianChart();
            this.symbolChoice = new System.Windows.Forms.ComboBox();
            this.longShortChoice = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.startingAccountMask = new System.Windows.Forms.MaskedTextBox();
            this.betChoice = new System.Windows.Forms.ComboBox();
            this.csvOpen = new System.Windows.Forms.OpenFileDialog();
            this.clipboardMonitor1 = new ClipboardAssist.ClipboardMonitor();
            this.mainMenu.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.returnCharts.SuspendLayout();
            this.positiveReturnsPerSymbolGroup.SuspendLayout();
            this.negativeReturnsPerSymbolGroup.SuspendLayout();
            this.longShortBalanceGroup.SuspendLayout();
            this.returnsDistributionGroup.SuspendLayout();
            this.returnsOverTimeGroup.SuspendLayout();
            this.tradesOverTimeGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1330, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainMenu_KeyDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pastecsvToolStripMenuItem,
            this.loadcsvToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // pastecsvToolStripMenuItem
            // 
            this.pastecsvToolStripMenuItem.Name = "pastecsvToolStripMenuItem";
            this.pastecsvToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.pastecsvToolStripMenuItem.Text = "Paste .csv from clipboard";
            this.pastecsvToolStripMenuItem.Click += new System.EventHandler(this.pastecsvToolStripMenuItem_Click);
            // 
            // loadcsvToolStripMenuItem
            // 
            this.loadcsvToolStripMenuItem.Name = "loadcsvToolStripMenuItem";
            this.loadcsvToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.loadcsvToolStripMenuItem.Text = "Load .csv";
            this.loadcsvToolStripMenuItem.Click += new System.EventHandler(this.loadcsvToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Location = new System.Drawing.Point(0, 31);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1330, 963);
            this.mainTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.returnCharts);
            this.tabPage1.Controls.Add(this.symbolChoice);
            this.tabPage1.Controls.Add(this.longShortChoice);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1322, 934);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Returns";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // returnCharts
            // 
            this.returnCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnCharts.Controls.Add(this.positiveReturnsPerSymbolGroup);
            this.returnCharts.Controls.Add(this.negativeReturnsPerSymbolGroup);
            this.returnCharts.Controls.Add(this.longShortBalanceGroup);
            this.returnCharts.Controls.Add(this.returnsDistributionGroup);
            this.returnCharts.Controls.Add(this.returnsOverTimeGroup);
            this.returnCharts.Controls.Add(this.tradesOverTimeGroup);
            this.returnCharts.Location = new System.Drawing.Point(9, 38);
            this.returnCharts.Name = "returnCharts";
            this.returnCharts.Size = new System.Drawing.Size(1305, 890);
            this.returnCharts.TabIndex = 2;
            // 
            // positiveReturnsPerSymbolGroup
            // 
            this.positiveReturnsPerSymbolGroup.Controls.Add(this.positiveReturnsPerSymbol);
            this.positiveReturnsPerSymbolGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positiveReturnsPerSymbolGroup.Location = new System.Drawing.Point(3, 3);
            this.positiveReturnsPerSymbolGroup.Name = "positiveReturnsPerSymbolGroup";
            this.positiveReturnsPerSymbolGroup.Size = new System.Drawing.Size(323, 287);
            this.positiveReturnsPerSymbolGroup.TabIndex = 1;
            this.positiveReturnsPerSymbolGroup.TabStop = false;
            this.positiveReturnsPerSymbolGroup.Text = "Positive Returns";
            // 
            // positiveReturnsPerSymbol
            // 
            this.positiveReturnsPerSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positiveReturnsPerSymbol.Location = new System.Drawing.Point(-3, 21);
            this.positiveReturnsPerSymbol.Name = "positiveReturnsPerSymbol";
            this.positiveReturnsPerSymbol.Size = new System.Drawing.Size(326, 266);
            this.positiveReturnsPerSymbol.TabIndex = 0;
            this.positiveReturnsPerSymbol.Text = "Positive Returns";
            // 
            // negativeReturnsPerSymbolGroup
            // 
            this.negativeReturnsPerSymbolGroup.Controls.Add(this.negativeReturnsPerSymbol);
            this.negativeReturnsPerSymbolGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.negativeReturnsPerSymbolGroup.Location = new System.Drawing.Point(332, 3);
            this.negativeReturnsPerSymbolGroup.Name = "negativeReturnsPerSymbolGroup";
            this.negativeReturnsPerSymbolGroup.Size = new System.Drawing.Size(323, 287);
            this.negativeReturnsPerSymbolGroup.TabIndex = 2;
            this.negativeReturnsPerSymbolGroup.TabStop = false;
            this.negativeReturnsPerSymbolGroup.Text = "Negative Returns";
            // 
            // negativeReturnsPerSymbol
            // 
            this.negativeReturnsPerSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.negativeReturnsPerSymbol.Location = new System.Drawing.Point(-3, 21);
            this.negativeReturnsPerSymbol.Name = "negativeReturnsPerSymbol";
            this.negativeReturnsPerSymbol.Size = new System.Drawing.Size(326, 266);
            this.negativeReturnsPerSymbol.TabIndex = 0;
            this.negativeReturnsPerSymbol.Text = "Negative Returns";
            // 
            // longShortBalanceGroup
            // 
            this.longShortBalanceGroup.Controls.Add(this.longShortBalanceChart);
            this.longShortBalanceGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.longShortBalanceGroup.Location = new System.Drawing.Point(661, 3);
            this.longShortBalanceGroup.Name = "longShortBalanceGroup";
            this.longShortBalanceGroup.Size = new System.Drawing.Size(199, 287);
            this.longShortBalanceGroup.TabIndex = 3;
            this.longShortBalanceGroup.TabStop = false;
            this.longShortBalanceGroup.Text = "Long Short Balance";
            // 
            // longShortBalanceChart
            // 
            this.longShortBalanceChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.longShortBalanceChart.Location = new System.Drawing.Point(6, 21);
            this.longShortBalanceChart.Name = "longShortBalanceChart";
            this.longShortBalanceChart.Size = new System.Drawing.Size(193, 266);
            this.longShortBalanceChart.TabIndex = 0;
            this.longShortBalanceChart.Text = "cartesianChart1";
            // 
            // returnsDistributionGroup
            // 
            this.returnsDistributionGroup.Controls.Add(this.returnsDistributionChart);
            this.returnsDistributionGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnCharts.SetFlowBreak(this.returnsDistributionGroup, true);
            this.returnsDistributionGroup.Location = new System.Drawing.Point(866, 3);
            this.returnsDistributionGroup.Name = "returnsDistributionGroup";
            this.returnsDistributionGroup.Size = new System.Drawing.Size(434, 287);
            this.returnsDistributionGroup.TabIndex = 4;
            this.returnsDistributionGroup.TabStop = false;
            this.returnsDistributionGroup.Text = "Returns Distribution";
            // 
            // returnsDistributionChart
            // 
            this.returnsDistributionChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnsDistributionChart.Location = new System.Drawing.Point(6, 21);
            this.returnsDistributionChart.Name = "returnsDistributionChart";
            this.returnsDistributionChart.Size = new System.Drawing.Size(428, 266);
            this.returnsDistributionChart.TabIndex = 0;
            this.returnsDistributionChart.Text = "cartesianChart1";
            // 
            // returnsOverTimeGroup
            // 
            this.returnsOverTimeGroup.Controls.Add(this.returnsOverTimeChart);
            this.returnsOverTimeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnsOverTimeGroup.Location = new System.Drawing.Point(3, 296);
            this.returnsOverTimeGroup.Name = "returnsOverTimeGroup";
            this.returnsOverTimeGroup.Size = new System.Drawing.Size(1297, 287);
            this.returnsOverTimeGroup.TabIndex = 5;
            this.returnsOverTimeGroup.TabStop = false;
            this.returnsOverTimeGroup.Text = "Returns Over Time";
            // 
            // returnsOverTimeChart
            // 
            this.returnsOverTimeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnsOverTimeChart.Location = new System.Drawing.Point(6, 21);
            this.returnsOverTimeChart.Name = "returnsOverTimeChart";
            this.returnsOverTimeChart.Size = new System.Drawing.Size(1291, 266);
            this.returnsOverTimeChart.TabIndex = 0;
            this.returnsOverTimeChart.Text = "Returns Over Time";
            // 
            // tradesOverTimeGroup
            // 
            this.tradesOverTimeGroup.Controls.Add(this.tradesOverTimeChart);
            this.tradesOverTimeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tradesOverTimeGroup.Location = new System.Drawing.Point(3, 589);
            this.tradesOverTimeGroup.Name = "tradesOverTimeGroup";
            this.tradesOverTimeGroup.Size = new System.Drawing.Size(1297, 287);
            this.tradesOverTimeGroup.TabIndex = 6;
            this.tradesOverTimeGroup.TabStop = false;
            this.tradesOverTimeGroup.Text = "Trades Over Time";
            // 
            // tradesOverTimeChart
            // 
            this.tradesOverTimeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tradesOverTimeChart.Location = new System.Drawing.Point(6, 21);
            this.tradesOverTimeChart.Name = "tradesOverTimeChart";
            this.tradesOverTimeChart.Size = new System.Drawing.Size(1291, 266);
            this.tradesOverTimeChart.TabIndex = 0;
            this.tradesOverTimeChart.Text = "Trades Over Time";
            // 
            // symbolChoice
            // 
            this.symbolChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.symbolChoice.FormattingEnabled = true;
            this.symbolChoice.Location = new System.Drawing.Point(143, 7);
            this.symbolChoice.Name = "symbolChoice";
            this.symbolChoice.Size = new System.Drawing.Size(192, 24);
            this.symbolChoice.TabIndex = 1;
            this.symbolChoice.SelectedIndexChanged += new System.EventHandler(this.symbolChoice_SelectedIndexChanged);
            // 
            // longShortChoice
            // 
            this.longShortChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.longShortChoice.FormattingEnabled = true;
            this.longShortChoice.Location = new System.Drawing.Point(7, 7);
            this.longShortChoice.Name = "longShortChoice";
            this.longShortChoice.Size = new System.Drawing.Size(121, 24);
            this.longShortChoice.TabIndex = 0;
            this.longShortChoice.SelectedIndexChanged += new System.EventHandler(this.longShortChoice_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.startingAccountMask);
            this.tabPage2.Controls.Add(this.betChoice);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1322, 934);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Monte Carlo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Starting account:";
            // 
            // startingAccountMask
            // 
            this.startingAccountMask.Location = new System.Drawing.Point(266, 8);
            this.startingAccountMask.Mask = "$#########.00";
            this.startingAccountMask.Name = "startingAccountMask";
            this.startingAccountMask.PromptChar = ' ';
            this.startingAccountMask.Size = new System.Drawing.Size(100, 22);
            this.startingAccountMask.TabIndex = 3;
            this.startingAccountMask.Text = "1337";
            // 
            // betChoice
            // 
            this.betChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.betChoice.FormattingEnabled = true;
            this.betChoice.Location = new System.Drawing.Point(6, 6);
            this.betChoice.Name = "betChoice";
            this.betChoice.Size = new System.Drawing.Size(121, 24);
            this.betChoice.TabIndex = 2;
            // 
            // csvOpen
            // 
            this.csvOpen.DefaultExt = "csv";
            this.csvOpen.Filter = "CSV Files|*.csv";
            this.csvOpen.RestoreDirectory = true;
            // 
            // clipboardMonitor1
            // 
            this.clipboardMonitor1.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor1.Location = new System.Drawing.Point(358, 0);
            this.clipboardMonitor1.Name = "clipboardMonitor1";
            this.clipboardMonitor1.Size = new System.Drawing.Size(73, 58);
            this.clipboardMonitor1.TabIndex = 2;
            this.clipboardMonitor1.Text = "clipboardMonitor1";
            this.clipboardMonitor1.Visible = false;
            this.clipboardMonitor1.ClipboardChanged += new System.EventHandler<ClipboardAssist.ClipboardChangedEventArgs>(this.clipboardMonitor1_ClipboardChanged);
            // 
            // TradeAnalysisWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 990);
            this.Controls.Add(this.clipboardMonitor1);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "TradeAnalysisWindow";
            this.Text = "QC Trade Analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TradeAnalysisWindow_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainMenu_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.returnCharts.ResumeLayout(false);
            this.positiveReturnsPerSymbolGroup.ResumeLayout(false);
            this.negativeReturnsPerSymbolGroup.ResumeLayout(false);
            this.longShortBalanceGroup.ResumeLayout(false);
            this.returnsDistributionGroup.ResumeLayout(false);
            this.returnsOverTimeGroup.ResumeLayout(false);
            this.tradesOverTimeGroup.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadcsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastecsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox longShortChoice;
        private System.Windows.Forms.ComboBox symbolChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox startingAccountMask;
        private System.Windows.Forms.ComboBox betChoice;
        private System.Windows.Forms.FlowLayoutPanel returnCharts;
        private LiveCharts.WinForms.PieChart positiveReturnsPerSymbol;
        private System.Windows.Forms.GroupBox positiveReturnsPerSymbolGroup;
        private System.Windows.Forms.GroupBox negativeReturnsPerSymbolGroup;
        private LiveCharts.WinForms.PieChart negativeReturnsPerSymbol;
        private System.Windows.Forms.GroupBox longShortBalanceGroup;
        private LiveCharts.WinForms.CartesianChart longShortBalanceChart;
        private System.Windows.Forms.GroupBox returnsDistributionGroup;
        private LiveCharts.WinForms.CartesianChart returnsDistributionChart;
        private System.Windows.Forms.GroupBox returnsOverTimeGroup;
        private LiveCharts.WinForms.CartesianChart returnsOverTimeChart;
        private System.Windows.Forms.GroupBox tradesOverTimeGroup;
        private LiveCharts.WinForms.CartesianChart tradesOverTimeChart;
        private ClipboardAssist.ClipboardMonitor clipboardMonitor1;
        private System.Windows.Forms.OpenFileDialog csvOpen;
    }
}

