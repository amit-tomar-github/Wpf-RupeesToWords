using System;
using System.Collections.Generic;
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

namespace RupeesToWords
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sValue = "";
            long rupee = long.Parse(txtRupees.Text.Split('.')[0]);
            sValue = ConvertNumbertoWords(rupee) + " Rupees";
            if (txtRupees.Text.Split('.').Length == 2)
            {
                long paisa = long.Parse(txtRupees.Text.Split('.')[1]);
                sValue += " And " + ConvertNumbertoWords(paisa) + " Paise";
            }
            MessageBox.Show(sValue);
        }

        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " Lakh ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " Hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "") words += "";
                var unitsMap = new[]
                {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };
                var tensMap = new[]
                {
            "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}
