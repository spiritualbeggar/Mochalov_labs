using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;
using System;

namespace MatrixLibraryTests
{
    [TestClass]
    public class MatrixSizeTests
    {
        [TestMethod]
        public void TestMatrixSizeGreaterThanOrEqualToTwo()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            var generator = new Func<int, int, int>((i, j) => i + j);

            // Act
            var matrix = Matrix<int>.Generate(rows, columns, generator);

            // Assert
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(2, matrix.Columns);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixSizeLessThanTwo()
        {
            // Arrange
            int rows = 1;
            int columns = 1;
            var generator = new Func<int, int, int>((i, j) => i + j);

            // Act
            var matrix = Matrix<int>.Generate(rows, columns, generator);

            // Assert - ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixSizeLessThanTwo2()
        {
            // Arrange
            int rows = 0;
            int columns = 0;
            var generator = new Func<int, int, int>((i, j) => i + j);

            // Act
            var matrix = Matrix<int>.Generate(rows, columns, generator);

            // Assert - ExpectedException
        }
    }
}