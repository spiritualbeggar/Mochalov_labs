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

namespace MatrixLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace MatrixLibrary
    {
        public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            private T[,] data;

            public int Rows { get; }
            public int Columns { get; }

            public Matrix(int rows, int columns)
            {
                Rows = rows;
                Columns = columns;
                data = new T[rows, columns];
            }

            public T this[int i, int j]
            {
                get => data[i, j];
                set => data[i, j] = value;
            }

            public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
            {
                if (a.Rows != b.Rows || a.Columns != b.Columns)
                    throw new ArgumentException("Matrices must have the same dimensions.");

                var result = new Matrix<T>(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result[i, j] = (dynamic)a[i, j] + b[i, j];
                    }
                }
                return result;
            }

            public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
            {
                if (a.Columns != b.Rows)
                    throw new ArgumentException("The number of columns in the first matrix must equal the number of rows in the second matrix.");

                var result = new Matrix<T>(a.Rows, b.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        result[i, j] = default(T);
                        for (int k = 0; k < a.Columns; k++)
                        {
                            result[i, j] = (dynamic)result[i, j] + (dynamic)a[i, k] * b[k, j];
                        }
                    }
                }
                return result;
            }

            public static Matrix<T> Generate(int rows, int columns, Func<int, int, T> generator)
            {
                var matrix = new Matrix<T>(rows, columns);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = generator(i, j);
                    }
                }
                return matrix;
            }

            public override string ToString()
            {
                var sb = new System.Text.StringBuilder();
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        sb.Append(data[i, j]).Append(" ");
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
        }
    }
}
