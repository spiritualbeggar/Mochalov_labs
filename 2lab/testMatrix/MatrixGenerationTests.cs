using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    [TestClass]
    public class MatrixGenerationTests
    {
        [TestMethod]
        public void TestMatrixGeneration()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            var generator = new Func<int, int, int>((i, j) => i + j);

            // Act
            var matrix = Matrix<int>.Generate(rows, columns, generator);

            // Assert
            Assert.AreEqual(0, matrix[0, 0]);
            Assert.AreEqual(1, matrix[0, 1]);
            Assert.AreEqual(1, matrix[1, 0]);
            Assert.AreEqual(2, matrix[1, 1]);
        }
    }
}