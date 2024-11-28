namespace IntegralCalculators.Simpson
{
    public class SimpsonMethod : IntegralCalculator.IntegralBase
    {
        public override double Calculate(Function f, double lowerLimit, double upperLimit, int steps)
        {
            if (steps % 2 != 0)
                throw new ArgumentException("Число шагов для метода Симпсона должно быть четным.");

            double stepSize = (upperLimit - lowerLimit) / steps;
            double result = f(lowerLimit) + f(upperLimit);

            for (int i = 1; i < steps; i++)
            {
                double x = lowerLimit + i * stepSize;
                result += (i % 2 == 0 ? 2 : 4) * f(x);
            }

            result *= stepSize / 3.0;
            return result;
        }

        // Параллельный расчет
        public double ParallelCalculate(Function f, double lowerLimit, double upperLimit, int steps)
        {
            if (steps % 2 != 0)
                throw new ArgumentException("Число шагов для метода Симпсона должно быть четным.");

            double stepSize = (upperLimit - lowerLimit) / steps;
            double result = f(lowerLimit) + f(upperLimit);

            object lockObj = new object(); // Для синхронизации доступа к result
            Parallel.For(1, steps, () => 0.0, (i, _, localSum) =>
            {
                double x = lowerLimit + i * stepSize;
                localSum += (i % 2 == 0 ? 2 : 4) * f(x);
                return localSum;
            },
            localSum =>
            {
                lock (lockObj)
                {
                    result += localSum;
                }
            });

            result *= stepSize / 3.0;
            return result;
        }
    }
}