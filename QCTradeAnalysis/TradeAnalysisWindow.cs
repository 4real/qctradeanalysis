using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;
using static QCTradeAnalysis.QCTradeExtensions;

namespace QCTradeAnalysis
{
    public partial class TradeAnalysisWindow : Form
    {
        private class BetItem
        {
            public readonly bool Scaled;
            public readonly string Label;

            public BetItem(bool scaled, string label)
            {
                Scaled = scaled;
                Label = label;
            }

            public override string ToString()
            {
                return Label;
            }
        }

        private List<QCTrade> _trades = new List<QCTrade>();
        private List<string> _symbols = new List<string>();

        public TradeAnalysisWindow()
        {
            InitializeComponent();

            longShortChoice.Items.Add(new LongShortItem(true, true, "Long/Short"));
            longShortChoice.Items.Add(new LongShortItem(true, false, "Long Only"));
            longShortChoice.Items.Add(new LongShortItem(false, true, "Short Only"));
            longShortChoice.SelectedIndex = 0;

            betChoice.Items.Add(new BetItem(false, "Fixed Bets"));
            betChoice.Items.Add(new BetItem(true, "Scaled Bets"));
            betChoice.SelectedIndex = Properties.Settings.Default.ScaledBets ? 1 : 0;

            startingAccountMask.Text = Properties.Settings.Default.StartingAccount;

            LoadCSV(Clipboard.GetText());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private bool AreBetsScaled()
        {
            return ((BetItem)betChoice.SelectedItem).Scaled;
        }

        private decimal GetStartingAccount()
        {
            var startingAccount = new string(startingAccountMask.Text.Skip(1).Where(x => x != ' ').ToArray());
            if (startingAccount.Last() == '.')
                startingAccount = startingAccount.Substring(0, startingAccount.Length - 1);
            return decimal.Parse(startingAccount);
        }

        private void Exit()
        {
            Properties.Settings.Default.StartingAccount = startingAccountMask.Text;
            Properties.Settings.Default.ScaledBets = AreBetsScaled();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void mainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Exit();
        }

        private void LoadCSV(string text)
        {
            _trades = QCTrade.LoadFromCSV(text);

            UpdateSymbolList();
            UpdateReturnCharts();
        }

        private void pastecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCSV(Clipboard.GetText());
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pastecsvToolStripMenuItem.Enabled = Clipboard.ContainsText() &&
                QCTrade.LoadFromCSV(Clipboard.GetText()).Count > 0;
        }

        private void TradeAnalysisWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        private void clipboardMonitor1_ClipboardChanged(object sender, ClipboardAssist.ClipboardChangedEventArgs e)
        {
            if (_trades.Count == 0 && Clipboard.ContainsText())
            {
                LoadCSV(Clipboard.GetText());
            }
        }

        private void loadcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (csvOpen.ShowDialog() != DialogResult.OK)
                return;

            LoadCSV(System.IO.File.ReadAllText(csvOpen.FileName));
        }
    }
}
