using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCTradeAnalysis
{
    public class QCTrade
    {
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int Type { get; set; }
        public string Status { get; set; }
        public decimal Value { get; set; }
        public string Tag { get; set; }

        public static List<QCTrade> LoadFromCSV(string csv)
        {
            var list = new List<QCTrade>();

            try
            {
                using (var reader = new StringReader(csv))
                {
                    for (;;)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                            break;

                        var fields = line.Split(',');
                        if (fields.Length < 8)
                            continue;

                        if (fields[0] == "Time")
                            continue; //skip header

                        var trade = new QCTrade();
                        trade.DateTime = DateTime.Parse(fields[0]);
                        trade.Symbol = fields[1];
                        trade.Price = decimal.Parse(fields[2]);
                        trade.Quantity = decimal.Parse(fields[3]);
                        trade.Type = int.Parse(fields[4]);
                        trade.Status = fields[5];
                        trade.Value = decimal.Parse(fields[6]);
                        trade.Tag = fields[7];

                        list.Add(trade);
                    }
                }
            }
            catch (FormatException)
            {
                list.Clear();
            }
            
            return list;
        }
    }

    public class QCTradeReturn
    {
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
        public decimal Return { get; set; }
        public decimal Quantity { get; set; }

        public bool IsLong
        {
            get { return Quantity < 0; } //selling
        }
        public bool IsShort
        {
            get { return Quantity > 0; } //buying back
        }

        public QCTradeReturn Clone()
        {
            return (QCTradeReturn)MemberwiseClone();
        }
    }

    public static class QCTradeExtensions
    {
        private class Holding
        {
            public decimal AveragePrice;
            public decimal Quantity;
        }

        public static IEnumerable<QCTradeReturn> ToReturnSeries(this IEnumerable<QCTrade> tradeSeries, bool normalize)
        {
            var holdings = new Dictionary<string, Holding>();

            foreach (var trade in tradeSeries)
            {
                Holding holding;
                if (!holdings.TryGetValue(trade.Symbol, out holding))
                {
                    holding = new Holding();
                    holdings[trade.Symbol] = holding;
                }

                if (holding.Quantity != 0 && Math.Sign(holding.Quantity) != Math.Sign(trade.Quantity))
                {
                    //generate new return
                    decimal tradeReturns = (trade.Price - holding.AveragePrice) / holding.AveragePrice;
                    if (holding.Quantity < 0)
                        tradeReturns = -tradeReturns;

                    if (normalize)
                    {
                        tradeReturns *= 100;
                    }
                    else
                    {
                        tradeReturns *= Math.Sign(trade.Quantity) * trade.Value;
                    }

                    var qcReturn = new QCTradeReturn();
                    qcReturn.DateTime = trade.DateTime;
                    qcReturn.Return = tradeReturns;
                    qcReturn.Symbol = trade.Symbol;
                    qcReturn.Quantity = trade.Quantity;

                    yield return qcReturn;
                }
                else
                {
                    //update average price
                    var fraction = trade.Quantity / (trade.Quantity + holding.Quantity);
                    holding.AveragePrice = (1 - fraction) * holding.AveragePrice + fraction * trade.Price;
                }

                holding.Quantity += trade.Quantity;
            }
        }

        public static IEnumerable<QCTradeReturn> ToDailySeries(this IEnumerable<QCTradeReturn> returnSeries)
        {
            var newSeries = new List<QCTradeReturn>();

            foreach (var symbolSeries in returnSeries.GroupBy(x => x.Symbol))
            {
                QCTradeReturn currentDay = null;
                foreach (var r in symbolSeries)
                {
                    if (currentDay == null)
                        currentDay = r.Clone();
                    else
                    {
                        if (currentDay.DateTime.DayOfYear == r.DateTime.DayOfYear) //TODO: technically this is not safe
                        {
                            //merge r into current day
                            currentDay.Quantity += r.Quantity;
                            currentDay.Return += r.Return; //TODO: multiplicative in case of percentage returns
                        }
                        else
                        {
                            newSeries.Add(currentDay);
                            currentDay = r.Clone();
                        }
                    }
                }

                if (currentDay != null)
                    newSeries.Add(currentDay);
            }

            newSeries.Sort((x, y) => x.DateTime.CompareTo(y.DateTime));

            return newSeries;
        }
    }
}
