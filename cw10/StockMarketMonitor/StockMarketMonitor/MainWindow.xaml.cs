using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StockMarketMonitor
{
    public partial class MainWindow : Window
    {
        private static DispatcherTimer timer = new();

        private void ActivateTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += UpdateData;
            timer.Start();
        }

        private void UpdateData(object sender, EventArgs e)
        {
            Random random = new Random();
            double[] changes = new double[4];

            var sign = new[] { -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                changes[i] = Math.Round(random.NextDouble() * sign[random.Next(2)], 2);
            }

            SetPrices(changes);
            SetColors(changes);
        }

        private void SetPrices(double[] changes)
        {
            // Company price change
            Company0Change.Text = changes[0].ToString(CultureInfo.InvariantCulture);
            Company1Change.Text = changes[1].ToString(CultureInfo.InvariantCulture);
            Company2Change.Text = changes[2].ToString(CultureInfo.InvariantCulture);
            Company3Change.Text = changes[3].ToString(CultureInfo.InvariantCulture);

            // Company updated price
            Company0Price.Text = Math.Round(Convert.ToDouble(Company0Price.Text) + changes[0], 2).ToString(CultureInfo.InvariantCulture);
            Company1Price.Text = Math.Round(Convert.ToDouble(Company1Price.Text) + changes[1], 2).ToString(CultureInfo.InvariantCulture);
            Company2Price.Text = Math.Round(Convert.ToDouble(Company2Price.Text) + changes[2], 2).ToString(CultureInfo.InvariantCulture);
            Company3Price.Text = Math.Round(Convert.ToDouble(Company3Price.Text) + changes[3], 2).ToString(CultureInfo.InvariantCulture);
        }

        private void SetColors(double[] changes)
        {
            // Company styles
            Style greenStyle = FindResource("CompanyGreen") as Style;
            Style redStyle = FindResource("CompanyRed") as Style;
            Style grayStyle = FindResource("CompanyGray") as Style;

            Style greenBorderStyle = FindResource("CompanyBorderGreen") as Style;
            Style redBorderStyle = FindResource("CompanyBorderRed") as Style;
            Style grayBorderStyle = FindResource("CompanyBorderGray") as Style;

            // Company0
            if (changes[0] > 0)
            {
                Company0.Style = greenStyle;
                Company0Border.Style = greenBorderStyle;
            }
            else if (changes[0] < 0)
            {
                Company0.Style = redStyle;
                Company0Border.Style = redBorderStyle;
            }
            else
            {
                Company0.Style = grayStyle;
                Company0Border.Style = grayBorderStyle;
            }

            // Company1
            if (changes[1] > 0)
            {
                Company1.Style = greenStyle;
                Company1Border.Style = greenBorderStyle;
            }
            else if (changes[1] < 0)
            {
                Company1.Style = redStyle;
                Company1Border.Style = redBorderStyle;
            }
            else
            {
                Company1.Style = grayStyle;
                Company1Border.Style = grayBorderStyle;
            }

            // Company2
            if (changes[2] > 0)
            {
                Company2.Style = greenStyle;
                Company2Border.Style = greenBorderStyle;
            }
            else if (changes[2] < 0)
            {
                Company2.Style = redStyle;
                Company2Border.Style = redBorderStyle;
            }
            else
            {
                Company2.Style = grayStyle;
                Company2Border.Style = grayBorderStyle;
            }

            // Company3
            if (changes[3] > 0)
            {
                Company3.Style = greenStyle;
                Company3Border.Style = greenBorderStyle;
            }
            else if (changes[3] < 0)
            {
                Company3.Style = redStyle;
                Company3Border.Style = redBorderStyle;
            }
            else
            {
                Company3.Style = grayStyle;
                Company3Border.Style = grayBorderStyle;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            ActivateTimer();
        }
    }
}
