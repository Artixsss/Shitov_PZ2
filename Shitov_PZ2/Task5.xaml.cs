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
    public partial class Task5 : Window
    {
        public Task5()
        {
            InitializeComponent();
        }

        private void btnGenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text;
            int[] dimensions = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if (dimensions.Length == 2)
            {
                int M = dimensions[0];
                int N = dimensions[1];
                int[,] array = GenerateArray(M, N);
                int[] flattenedArray = FlattenArray(array);
                Array.Sort(flattenedArray);
                int[] sortedDescArray = flattenedArray.Reverse().ToArray();

                txtResult.Text = "Начальный массив:\n" + PrintArray(array) +
                                 "\nОтсортированный массив по возрастанию:\n" + PrintArray(ConvertTo2DArray(flattenedArray, M, N)) +
                                 "\nОтсортированный массив по убыванию:\n" + PrintArray(ConvertTo2DArray(sortedDescArray, M, N));

                int min = flattenedArray.Min();
                int max = flattenedArray.Max();
                txtMinMax.Text = $"Минимальный элемент: {min}, Максимальный элемент: {max}";
            }
            else
            {
                MessageBox.Show("Введите корректные размеры массива (M и N).");
            }
        }

        private int[,] GenerateArray(int M, int N)
        {
            int[,] array = new int[M, N];
            Random rand = new Random();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    array[i, j] = rand.Next(-10, 11);
                }
            }
            return array;
        }

        private int[] FlattenArray(int[,] array)
        {
            int M = array.GetLength(0);
            int N = array.GetLength(1);
            int[] flattenedArray = new int[M * N];
            int index = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    flattenedArray[index++] = array[i, j];
                }
            }
            return flattenedArray;
        }

        private int[,] ConvertTo2DArray(int[] array, int M, int N)
        {
            int[,] result = new int[M, N];
            int index = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i, j] = array[index++];
                }
            }
            return result;
        }

        private string PrintArray(int[,] array)
        {
            int M = array.GetLength(0);
            int N = array.GetLength(1);
            string result = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result += array[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
