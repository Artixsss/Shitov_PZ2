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
    public partial class Task4 : Window
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = txtInput.Text;
                int[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (int.TryParse(txtB.Text, out int b))
                {
                    int[] result = RearrangeArray(numbers, b);
                    txtResult.Text = PrintArrayWithBorder(result, b);
                }
                else
                {
                    MessageBox.Show("Введите корректное число b.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private int[] RearrangeArray(int[] numbers, int b)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                while (left <= right && numbers[left] <= b)
                {
                    left++;
                }
                while (left <= right && numbers[right] > b)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = numbers[left];
                    numbers[left] = numbers[right];
                    numbers[right] = temp;
                }
            }

            return numbers;
        }

        private string PrintArrayWithBorder(int[] array, int b)
        {
            string result = "";
            bool borderAdded = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    result += " ";
                }
                if (array[i] > b && !borderAdded)
                {
                    result += "| ";
                    borderAdded = true;
                }
                result += array[i];
            }
            return result;
        }
    }
}
