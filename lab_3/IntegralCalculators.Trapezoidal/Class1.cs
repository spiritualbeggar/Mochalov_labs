using System;
using System.Threading.Tasks;
namespace IntegralCalculators.Trapezoidal
{
    public class TrapezoidalMethod : IntegralCalculator.IntegralBase
    {
        public override double Calculate(Function f, double lowerLimit, double upperLimit, int steps)
        {
            double stepSize = (upperLimit - lowerLimit) / steps;
            double result = (f(lowerLimit) + f(upperLimit)) / 2.0;

            for (int i = 1; i < steps; i++)
            {
                double x = lowerLimit + i * stepSize;
                result += f(x);
            }

            result *= stepSize;
            return result;
        }

        // Параллельный расчет
        public double ParallelCalculate(Function f, double lowerLimit, double upperLimit, int steps)
        {
            double stepSize = (upperLimit - lowerLimit) / steps;
            double result = (f(lowerLimit) + f(upperLimit)) / 2.0;

            object lockObj = new object(); // Для синхронизации доступа к result
            Parallel.For(1, steps, () => 0.0, (i, _, localSum) =>
            {
                double x = lowerLimit + i * stepSize;
                localSum += f(x);
                return localSum;
            },
            localSum =>
            {
                lock (lockObj)
                {
                    result += localSum;
                }
            });

            result *= stepSize;
            return result;
        }
    }
}