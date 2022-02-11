using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using TicketSystem.Classes;
using InteractiveDataDisplay.WPF;
using TicketSystem.Classes.Database;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for ChartsView.xaml
    /// </summary>
    public partial class ChartsView : UserControl
    {
        public ChartsView()
        {
            InitializeComponent();

            var data = DbHelper.GetProfits();
            if (data.Count == 0) return;
           /* var data = new[]
            {
                new {TotalPrice = 100, VAT = 5},
                new {TotalPrice = 200, VAT = 5},
                new {TotalPrice = 300, VAT = 5},
                new {TotalPrice = 160, VAT = 10},
            };*/
            var netList = new List<decimal>();
            var yList = new List<int>();
            var grossList = new List<decimal>();

            var netFlow = 0m;
            var grossFlow = 0m;
            DateTime startTime = data[0].EntryTime;
            foreach (var item in data)
            {
                var net = ((decimal)item.ActualPrice).SubtractPerc((decimal)item.VAT);
                netFlow += net;
                grossFlow += item.ActualPrice;
                netList.Add(netFlow);
                grossList.Add(grossFlow);
                yList.Add((int)(item.EntryTime - startTime).TotalMinutes);
            }

            var lg = new LineGraph();
            lines.Children.Add(lg);
            lg.Stroke = new SolidColorBrush(Colors.Green);
            lg.Description = "Net Income";
            lg.StrokeThickness = 2;
            lg.Plot(yList, netList);

            lg = new LineGraph();
            lines.Children.Add(lg);
            lg.Stroke = new SolidColorBrush(Colors.Blue);
            lg.Description = "Gross Income";
            lg.StrokeThickness = 2;
            lg.Plot(yList, grossList);

        }
    }
}
