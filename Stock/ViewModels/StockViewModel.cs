using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Stock.Helpers;
using Stock.Models;
using System.Linq;

namespace Stock.ViewModels
{
    public class StockViewModel : DependencyObject
    {
        private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);

        public ObservableCollection<StockQuote> StockQuotes { get; set; }

        public StockViewModel(ObservableCollection<StockQuote> quotes, string sortBy)
        {
            StockQuotes = quotes;

            /*
            //Some example tickers
            StockQuotes.Add(new StockQuote("AAPL"));
            StockQuotes.Add(new StockQuote("MSFT"));
            StockQuotes.Add(new StockQuote("INTC"));
            StockQuotes.Add(new StockQuote("IBM"));
            StockQuotes.Add(new StockQuote("AMZN"));
            StockQuotes.Add(new StockQuote("BIDU"));
            StockQuotes.Add(new StockQuote("SINA"));
            StockQuotes.Add(new StockQuote("NVDA"));
            StockQuotes.Add(new StockQuote("AMD"));
            StockQuotes.Add(new StockQuote("WMT"));
             */

            //get the data
            StockEngine.Fetch(StockQuotes);

            if (sortBy == "Symbol")
                StockQuotes = new ObservableCollection<StockQuote>(StockQuotes.OrderBy(i => i.Symbol));
            if (sortBy == "Change")
                StockQuotes = new ObservableCollection<StockQuote>(StockQuotes.OrderBy(i => i.Change));


            //poll every 5 seconds
            timer.Interval = new TimeSpan(0, 0, 5); 
            timer.Tick += (o, e) => StockEngine.Fetch(StockQuotes);
                              
            timer.Start();
        }
    }
}