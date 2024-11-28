using System;
using System.Diagnostics;
using System.Windows;
using IntegralCalculators.Trapezoidal;
using IntegralCalculators.Simpson;
using IntegralCalculators;

namespace lab_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateIntegrals()
        {
            Function integrand = x => (2 * x - Math.Log(11 * x) - 1);

            double lowerLimit = 1, upperLimit = 100000;
            int steps = 1000000;

            var trapezoidal = new TrapezoidalMethod();
            var simpson = new SimpsonMethod();

            // Последовательное вычисление
            Stopwatch stopwatch = Stopwatch.StartNew();
            double trapezoidalResult = trapezoidal.Calculate(integrand, lowerLimit, upperLimit, steps);
            double simpsonResult = simpson.Calculate(integrand, lowerLimit, upperLimit, steps);
            stopwatch.Stop();
            long sequentialTime = stopwatch.ElapsedMilliseconds;

            // Параллельное вычисление
            stopwatch.Restart();
            double parallelTrapezoidalResult = trapezoidal.ParallelCalculate(integrand, lowerLimit, upperLimit, steps);
            double parallelSimpsonResult = simpson.ParallelCalculate(integrand, lowerLimit, upperLimit, steps);
            stopwatch.Stop();
            long parallelTime = stopwatch.ElapsedMilliseconds;

            // Вывод результатов
            SequentialResult.Text = $"Трапеции (последовательно): {trapezoidalResult}\nСимпсон (последовательно): {simpsonResult}";
            ParallelResult.Text = $"Трапеции (параллельно): {parallelTrapezoidalResult}\nСимпсон (параллельно): {parallelSimpsonResult}";
            TimeComparison.Text = $"Время (последовательно): {sequentialTime} мс, (параллельно): {parallelTime} мс";
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            // Парсинг границ интеграла
            if (!double.TryParse(LowerLimitInput.Text, out double lowerLimit))
            {
                MessageBox.Show("Введите корректное значение для нижней границы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(UpperLimitInput.Text, out double upperLimit))
            {
                MessageBox.Show("Введите корректное значение для верхней границы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (lowerLimit >= upperLimit)
            {
                MessageBox.Show("Нижняя граница должна быть меньше верхней.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Парсинг количества разбиений
            if (!int.TryParse(StepsInput.Text, out int steps) || steps <= 0)
            {
                MessageBox.Show("Введите корректное количество разбиений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Выбор метода решения
            IntegralBase method;
            if (MethodSelector.SelectedIndex == 0)
            {
                method = new TrapezoidalMethod();
            }
            else
            {
                method = new SimpsonMethod();
            }

            // Подынтегральная функция
            Function integrand = x => 2 * x - Math.Log(11 * x) - 1;

            // Последовательное вычисление
            Stopwatch stopwatch = Stopwatch.StartNew();
            double sequentialResult = method.Calculate(integrand, lowerLimit, upperLimit, steps);
            stopwatch.Stop();
            long sequentialTime = stopwatch.ElapsedMilliseconds;

            // Параллельное вычисление
            stopwatch.Restart();
            double parallelResult = method.ParallelCalculate(integrand, lowerLimit, upperLimit, steps);
            stopwatch.Stop();
            long parallelTime = stopwatch.ElapsedMilliseconds;

            // Вывод результатов
            SequentialResult.Text = $"Результат: {sequentialResult}\nВремя: {sequentialTime} мс";
            ParallelResult.Text = $"Результат: {parallelResult}\nВремя: {parallelTime} мс";
            TimeComparison.Text = $"Разница во времени: {sequentialTime - parallelTime} мс";
        }
    }
}

