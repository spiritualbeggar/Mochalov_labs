namespace IntegralCalculators
{
    public delegate double Function(double x);
    public abstract class IntegralBase
    {
        // Абстрактный метод для последовательного расчета
        public abstract double Calculate(Function f, double lowerLimit, double upperLimit, int steps);

        // Общий метод для параллельного расчета
        public virtual double ParallelCalculate(Function f, double lowerLimit, double upperLimit, int steps)
        {
            double result = 0.0;
            double stepSize = (upperLimit - lowerLimit) / steps;
            object lockObj = new object(); // Для синхронизации доступа к result

            Parallel.For(0, Environment.ProcessorCount, () => 0.0, (chunk, _, localSum) =>
            {
                int chunkSize = steps / Environment.ProcessorCount;
                int start = chunk * chunkSize;
                int end = (chunk == Environment.ProcessorCount - 1) ? steps : start + chunkSize;

                for (int i = start; i < end; i++)
                {
                    double x = lowerLimit + i * stepSize;
                    localSum += PartialSum(f, x, stepSize, i);
                }
                return localSum;
            },
            localSum =>
            {
                lock (lockObj)
                {
                    result += localSum;
                }
            });

            return result;
        }

        // Виртуальный метод для подсчета частичных сумм, реализуется в дочерних классах
        protected virtual double PartialSum(Function f, double x, double stepSize, int index) => f(x);
    }
}