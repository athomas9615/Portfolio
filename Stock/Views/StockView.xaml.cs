using System.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Stock.Models;
using Stock.ViewModels;

namespace Stock.Views
{
    public partial class StockView : Window
    {
        public ObservableCollection<StockQuote> StockQuotes { get; set; }

        public StockView()
        {
            InitializeComponent();

            StockQuotes = new ObservableCollection<StockQuote>();

            StockQuotes.Add(new StockQuote("CSCO"));
            StockQuotes.Add(new StockQuote("MSFT"));
            StockQuotes.Add(new StockQuote("INTC"));
            StockQuotes.Add(new StockQuote("SIMO"));
            StockQuotes.Add(new StockQuote("MU"));
            StockQuotes.Add(new StockQuote("BIDU"));
            
            DataContext = new StockViewModel(StockQuotes, "");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StockViewModel(StockQuotes, "Symbol");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new StockViewModel(StockQuotes, "Change");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StockQuotes.Add(new StockQuote(TextBox.Text.ToUpper()));

            DataContext = new StockViewModel(StockQuotes, "");
        }


    }
}