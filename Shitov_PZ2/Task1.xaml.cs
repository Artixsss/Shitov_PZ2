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

namespace Shitov_PZ2
{
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtInput.Text, out int n) && n <= 100)
            {
                int result = 2*Factorial(n);
                txtResult.Text = $"2*{n}! = {result}";
            }
            else
            {
                MessageBox.Show("Введите корректное число (n <= 100).");
            }
        }

        private int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}
