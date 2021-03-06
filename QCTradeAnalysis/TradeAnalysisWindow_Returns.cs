﻿using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QCTradeAnalysis
{
    public partial class TradeAnalysisWindow : Form
    {
        private class LongShortItem
        {
            public readonly bool HasLong;
            public readonly bool HasShort;
            public readonly string Label;

            public LongShortItem(bool hasLong, bool hasShort, string label)
            {
                HasLong = hasLong;
                HasShort = hasShort;
                Label = label;
            }

            public override string ToString()
            {
                return Label;
            }
        }

        private IEnumerable<QCTrade> GetSelectedTrades()
        {
            var trades = (IEnumerable<QCTrade>)_trades;
            if (symbolChoice.SelectedIndex != 0)
            {
                var selectedSymbol = (string)symbolChoice.SelectedItem;
                trades = trades.Where(x => x.Symbol == selectedSymbol);
            }

            return trades;
        }

        private IEnumerable<QCTradeReturn> GetSelectedReturns()
        {
            var returnSeries = _trades.ToReturnSeries(normalizeReturnsCheck.Checked)
                .Where(x => x.DateTime >= startDatePicker.Value && x.DateTime <= endDatePicker.Value);

            if (dailySeriesCheck.Checked)
            {
                returnSeries = returnSeries.ToDailySeries();
            }
            if (symbolChoice.SelectedIndex != 0)
            {
                var selectedSymbol = (string)symbolChoice.SelectedItem;
                returnSeries = returnSeries.Where(x => x.Symbol == selectedSymbol);
            }
            if (longShortChoice.SelectedIndex != 0)
            {
                bool isLong = ((LongShortItem)longShortChoice.SelectedItem).HasLong;
                returnSeries = returnSeries.Where(x => x.IsLong == isLong);
            }

            return returnSeries;
        }

        private void longShortChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReturnCharts();
        }

        private void symbolChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReturnCharts();
        }

        private void UpdateDatePickers()
        {
            if (_trades.Count == 0)
                return;

            var minDate = _trades.Min(x => x.DateTime);
            var maxDate = _trades.Max(x => x.DateTime);
            
            startDatePicker.MinDate = minDate;
            startDatePicker.MaxDate = maxDate;
            startDatePicker.Value = minDate;

            endDatePicker.MinDate = minDate;
            endDatePicker.MaxDate = maxDate;
            endDatePicker.Value = maxDate;
        }

        private void UpdateSymbolList()
        {
            _symbols = _trades.Select(x => x.Symbol).Distinct().ToList();

            symbolChoice.Items.Clear();

            if (_symbols.Count > 0)
            {
                symbolChoice.Items.Add("All symbols");
                symbolChoice.Items.AddRange(_symbols.ToArray());
            }
            else
            {
                symbolChoice.Items.Add("No symbols loaded");
            }

            symbolChoice.SelectedIndex = 0;
        }

        private void UpdateReturnCharts()
        {
            var returns = GetSelectedReturns().ToArray();

            tradesInRangeLabel.Text = returns.Count() + " trades in range";

            var symbols = returns.Select(x => x.Symbol).Distinct();

            if (symbolChoice.SelectedIndex == 0)
            {
                var symbolReturns = symbols.Select(x => new KeyValuePair<string, decimal>(x, returns.Where(y => y.Symbol == x).Sum(z => z.Return)));
                UpdateReturnsPerSymbol(symbolReturns.Where(kv => kv.Value > 0),
                    positiveReturnsPerSymbolGroup, positiveReturnsPerSymbol);
                UpdateReturnsPerSymbol(symbolReturns.Where(kv => kv.Value < 0),
                    negativeReturnsPerSymbolGroup, negativeReturnsPerSymbol);
            }
            else
            {
                positiveReturnsPerSymbolGroup.Visible = false;
                negativeReturnsPerSymbolGroup.Visible = false;
            }
            
            if (longShortChoice.SelectedIndex == 0 && symbols.Any())
            {
                UpdateLongShortBalance(returns, longShortReturnsGroup, longShortReturnsChart, x => x.Return);
                UpdateLongShortBalance(returns, longShortTradesGroup, longShortTradesChart, x => 1);
            }
            else
            {
                longShortReturnsGroup.Visible = false;
                longShortTradesGroup.Visible = false;
            }

            if (symbols.Any())
            {
                UpdateIntradayReturnsDistribution(returns);
                UpdateReturnsDistribution(returns);
                UpdateQuantityOverTime(returns, false, returnsOverTimeGroup, returnsOverTimeChart,
                    (x) => x.Return);
                UpdateQuantityOverTime(returns, true, tradesOverTimeGroup, tradesOverTimeChart,
                    (x) => 1);
            }
            else
            {
                intradayReturnsDistributionGroup.Visible = false;
                returnsDistributionGroup.Visible = false;
                returnsOverTimeGroup.Visible = false;
                tradesOverTimeGroup.Visible = false;
            }
        }

        private void UpdateQuantityOverTime(IEnumerable<QCTradeReturn> returns, bool line, GroupBox group, LiveCharts.WinForms.CartesianChart chart, Func<QCTradeReturn, decimal> quantitySelector)
        {
            var min = returns.First().DateTime;
            var max = returns.Last().DateTime;

            int months = max.Month - min.Month + 1;
            months += (max.Year - min.Year) * 12;

            var labels = new string[months];
            var returnsPerMonth = new decimal[months];
            foreach (var r in returns)
            {
                var date = r.DateTime;
                int index = date.Month - min.Month;
                index += (date.Year - min.Year) * 12;

                returnsPerMonth[index] += quantitySelector(r);
            }

            string[] MONTHS = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int month = min.Month;
            int year = min.Year;
            for (int i = 0; i < labels.Length; ++i)
            {
                labels[i] = MONTHS[month - 1] + " " + year;
                month += 1;
                if (month > 12)
                {
                    month = 1;
                    year += 1;
                }
            }

            var series = new SeriesCollection();
            if (line)
            {
                series.Add(new LineSeries
                {
                    Title = symbolChoice.SelectedText,
                    Values = new ChartValues<decimal>(returnsPerMonth)
                });
            }
            else
            {
                {
                    series.Add(new ColumnSeries
                    {
                        Title = symbolChoice.SelectedText,
                        Values = new ChartValues<decimal>(returnsPerMonth)
                    });
                }
            }
            chart.Series = series;
            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis
            {
                Labels = labels,
            });

            group.Visible = true;
        }

        private void UpdateIntradayReturnsDistribution(IEnumerable<QCTradeReturn> returns)
        {
            if (returns.Count() < 1 || dailySeriesCheck.Checked)
            {
                intradayReturnsDistributionGroup.Visible = false;
                return;
            }

            var sortedReturns = returns.OrderBy(x => x.Return).ToArray();

            int minHour = returns.Min(x => x.DateTime.Hour);
            int maxHour = returns.Max(x => x.DateTime.Hour);

            var frequencies = new int[maxHour - minHour + 1];
            var sums = new decimal[frequencies.Length];

            for (int i = 0; i < sortedReturns.Length; ++i)
            {
                var r = sortedReturns[i];
                int bin = r.DateTime.Hour - minHour;

                frequencies[bin] += 1;
                sums[bin] += r.Return;
            }

            var hours = new int[frequencies.Length];
            for (int i = 0; i < frequencies.Length; ++i)
            {
                hours[i] = i + minHour;
            }

            intradayReturnsDistributionChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = symbolChoice.SelectedText,
                    Values = new ChartValues<decimal>(sums)
                },
            };
            intradayReturnsDistributionChart.AxisX.Clear();
            intradayReturnsDistributionChart.AxisX.Add(new Axis
            {
                Labels = hours.Select(x => x.ToString()).ToArray(),
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });


            intradayReturnsDistributionGroup.Visible = true;
        }

        private void UpdateReturnsDistribution(IEnumerable<QCTradeReturn> returns)
        {
            if (returns.Count() < 2)
            {
                returnsDistributionGroup.Visible = false;
                return;
            }

            var sortedReturns = returns.OrderBy(x => x.Return).ToArray();
            var min = sortedReturns[0].Return;
            var max = sortedReturns[sortedReturns.Length - 1].Return;

            var frequencies = new int[10];
            var sums = new decimal[frequencies.Length];

            for (int i = 0; i < sortedReturns.Length; ++i)
            {
                var r = sortedReturns[i].Return;
                var u = (r - min) / (max - min);

                int bin = (int)(u * frequencies.Length);
                if (bin == frequencies.Length) //should only happen to max value
                    bin = frequencies.Length - 1;

                frequencies[bin] += 1;
                sums[bin] += r;
            }

            var returnInBin = new decimal[frequencies.Length];
            for (int i = 0; i < returnInBin.Length; ++i)
                returnInBin[i] = frequencies[i] != 0? sums[i] / frequencies[i] : returnInBin[i - 1];

            returnsDistributionChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = symbolChoice.SelectedText,
                    Values = new ChartValues<int>(frequencies)
                },
            };
            returnsDistributionChart.AxisX.Clear();
            returnsDistributionChart.AxisX.Add(new Axis
            {
                Labels = returnInBin.Select(x => x.ToString("F2")).ToArray(),
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });


            returnsDistributionGroup.Visible = true;
        }

        private void UpdateLongShortBalance(IEnumerable<QCTradeReturn> returns, GroupBox group, LiveCharts.WinForms.CartesianChart chart, Func<QCTradeReturn, decimal> quantitySelector)
        {
            var quantityLong = returns.Where(x => x.IsLong).Sum(y => quantitySelector(y));
            var quantityShort = returns.Where(x => x.IsShort).Sum(y => quantitySelector(y));
            var min = Math.Min(quantityLong, quantityShort);
            var max = Math.Max(quantityLong, quantityShort);

            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Long",
                    Values = new ChartValues<decimal> { quantityLong }
                },
                new ColumnSeries
                {
                    Title = "Short",
                    Values = new ChartValues<decimal> { quantityShort }
                }
            };
            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis()
            {
                MinValue = (double)Math.Min(0, min),
                MaxValue = (double)Math.Max(0, max),
            });

            group.Visible = true;
        }

        private void UpdateReturnsPerSymbol(IEnumerable<KeyValuePair<string, decimal>> symbols, GroupBox group, LiveCharts.WinForms.PieChart chart)
        {
            if (symbols.Any())
            {
                //positiveReturnsPerSymbol.InnerRadius = 52;
                var series = new SeriesCollection();
                foreach (var kv in symbols)
                {
                    series.Add(new PieSeries
                    {
                        Title = kv.Key,
                        Values = new ChartValues<decimal> { kv.Value },
                        //PushOut = 15,
                        //DataLabels = true
                    });
                }

                chart.Series = series;
                group.Visible = true;
            }
            else
            {
                group.Visible = false;
            }
        }
    }
}
