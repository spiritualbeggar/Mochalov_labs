using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    [TestClass]
    public class MatrixAdditionTests
    {
        [TestMethod]
        public void TestMatrixAddition()
        {
            // Arrange
            var matrixA = new Matrix<int>(2, 2);
            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[1, 0] = 3;
            matrixA[1, 1] = 4;

            var matrixB = new Matrix<int>(2, 2);
            matrixB[0, 0] = 5;
            matrixB[0, 1] = 6;
            matrixB[1, 0] = 7;
            matrixB[1, 1] = 8;

            // Act
            var result = matrixA + matrixB;

            // Assert
            Assert.AreEqual(6, result[0, 0]);
            Assert.AreEqual(8, result[0, 1]);
            Assert.AreEqual(10, result[1, 0]);
            Assert.AreEqual(12, result[1, 1]);
        }

        [TestMethod]
        public void TestMatrixAddition2()
        {
            // Arrange
            var matrixA = new Matrix<int>(2, 2);
            matrixA[0, 0] = 1;
            matrixA[0, 1] = 1;
            matrixA[1, 0] = 1;
            matrixA[1, 1] = 1;

            var matrixB = new Matrix<int>(2, 2);
            matrixB[0, 0] = 1;
            matrixB[0, 1] = 1;
            matrixB[1, 0] = 1;
            matrixB[1, 1] = 1;

            // Act
            var result = matrixA + matrixB;

            // Assert
            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(2, result[0, 1]);
            Assert.AreEqual(2, result[1, 0]);
            Assert.AreEqual(2, result[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixAdditionDifferentDimensions()
        {
            
            var matrixA = new Matrix<int>(2, 2);
            var matrixB = new Matrix<int>(3, 3);

            
            var result = matrixA + matrixB;

            // Assert - ExpectedException
        }
    }
}