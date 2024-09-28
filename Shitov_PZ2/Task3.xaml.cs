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
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;
            int[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] result = FindLongestDivisibleSubsequence(numbers);
            txtResult.Text = string.Join(" ", result);
        }

        private int[] FindLongestDivisibleSubsequence(int[] numbers)
        {
            int n = numbers.Length;
            int[] dp = new int[n];
            int[] prev = new int[n];
            int maxLen = 0;
            int maxIdx = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] % numbers[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;
                    }
                }
                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    maxIdx = i;
                }
            }

            int[] result = new int[maxLen];
            for (int i = maxLen - 1; i >= 0; i--)
            {
                result[i] = numbers[maxIdx];
                maxIdx = prev[maxIdx];
            }

            return result;
        }
    }
}

