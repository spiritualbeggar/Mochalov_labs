using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    [TestClass]
    public class MatrixMultiplicationTests
    {
        [TestMethod]
        public void TestMatrixMultiplication()
        {
            // Arrange
            var matrixA = new Matrix<int>(2, 3);
            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[0, 2] = 3;
            matrixA[1, 0] = 4;
            matrixA[1, 1] = 5;
            matrixA[1, 2] = 6;

            var matrixB = new Matrix<int>(3, 2);
            matrixB[0, 0] = 7;
            matrixB[0, 1] = 8;
            matrixB[1, 0] = 9;
            matrixB[1, 1] = 10;
            matrixB[2, 0] = 11;
            matrixB[2, 1] = 12;

            // Act
            var result = matrixA * matrixB;

            // Assert
            Assert.AreEqual(58, result[0, 0]);
            Assert.AreEqual(64, result[0, 1]);
            Assert.AreEqual(139, result[1, 0]);
            Assert.AreEqual(154, result[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixMultiplicationInvalidDimensions()
        {
            // Arrange
            var matrixA = new Matrix<int>(2, 3);
            var matrixB = new Matrix<int>(2, 2);

            // Act
            var result = matrixA * matrixB;

            // Assert - ExpectedException
        }
    }
}