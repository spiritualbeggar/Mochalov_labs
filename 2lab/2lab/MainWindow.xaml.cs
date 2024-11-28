using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MatrixLibrary;

namespace MatrixLibrary
{
    public partial class MainWindow : Window
    {
        public Matrix<int> matrixA;
        public Matrix<int> matrixB;
        public Matrix<int> matrixC;
        private Random random = new Random(); // Создаем один объект Random

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int rows = int.Parse(txtRows.Text);
            int columns = int.Parse(txtColumns.Text);

            // Генерация матриц с числами в диапазоне от -100 до 100
            matrixA = Matrix<int>.Generate(rows, columns, (i, j) => random.Next(-100, 101));
            matrixB = Matrix<int>.Generate(rows, columns, (i, j) => random.Next(-100, 101));

            DisplayMatrix(matrixA, dataGridA);
            DisplayMatrix(matrixB, dataGridB);
        }

        public void DisplayMatrix(Matrix<int> matrix, DataGrid dataGrid)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Columns.Clear();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.GridLinesVisibility= DataGridGridLinesVisibility.None;
            dataGrid.HeadersVisibility= DataGridHeadersVisibility.None;
            dataGrid.RowHeight = 40;

            for (int j = 0; j < matrix.Columns; j++)
            {
                dataGrid.Columns.Add(new DataGridTextColumn { Header = $"Column {j}", Binding = new System.Windows.Data.Binding($"[{j}]") });
            }

            var rows = new int[matrix.Rows][];
            for (int i = 0; i < matrix.Rows; i++)
            {
                rows[i] = new int[matrix.Columns];
                for (int j = 0; j < matrix.Columns; j++)
                {
                    rows[i][j] = matrix[i, j];
                }
            }

            dataGrid.ItemsSource = rows;
        }

        public void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (matrixA == null || matrixB == null)
            {
                MessageBox.Show("Сначала сгенерируйте матрицы");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (radioButtonAdd.IsChecked == true)
            {
                matrixC = matrixA + matrixB;
            }
            else if (radioButtonMultiply.IsChecked == true)
            {
                matrixC = matrixA * matrixB;
            }

            stopwatch.Stop();
            labelTime.Content = $"Время: {stopwatch.ElapsedMilliseconds} ms";

            DisplayMatrix(matrixC, dataGridC);
        }

        public void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (matrixC == null)
            {
                MessageBox.Show("Сначала посчитайте результат");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "result.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < matrixC.Rows; i++)
                    {
                        for (int j = 0; j < matrixC.Columns; j++)
                        {
                            writer.Write(matrixC[i, j]);
                            if (j < matrixC.Columns - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();
                    }
                }
                MessageBox.Show("Результат успешно сохранен!");
            }
        }
    }
}
