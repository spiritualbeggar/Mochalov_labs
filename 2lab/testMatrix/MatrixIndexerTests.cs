using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixLibraryTests
{
    [TestClass]
    public class MatrixIndexerTests
    {
        [TestMethod]
        public void TestMatrixIndexer()
        {
            // Arrange
            var matrix = new Matrix<int>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            // Assert
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(2, matrix[0, 1]);
            Assert.AreEqual(3, matrix[1, 0]);
            Assert.AreEqual(4, matrix[1, 1]);
        }
    }
}