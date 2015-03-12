namespace TestMatrix
{
    using System;
    using Matrix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMatrixWithZeroSize()
        {
            int[,] generatedMatrix = Matrix.FillMatrix(0);
        }

        [TestMethod]
        public void TestMatrixWithSizeOfOne()
        {
            int[,] expectedMatrix = 
            {
                { 1 }
            };

            int[,] generatedMatrix = Matrix.FillMatrix(1);

            CollectionAssert.AreEqual(expectedMatrix, generatedMatrix);
        }

        [TestMethod]
        public void TestMatrixWithSizeOfThree()
        {
            int[,] expectedMatrix = 
            {
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            int[,] generatedMatrix = Matrix.FillMatrix(3);

            CollectionAssert.AreEqual(expectedMatrix, generatedMatrix);
        }

        [TestMethod]
        public void TestMatrixWithSizeOfFive()
        {
            int[,] expectedMatrix = 
            {
                { 1, 13, 14, 15, 16 },
                { 12, 2,  21, 22, 17 },
                { 11, 23, 3, 20, 18 },
                { 10, 25, 24, 4, 19 },
                { 9, 8, 7, 6, 5 }
            };

            int[,] generatedMatrix = Matrix.FillMatrix(5);

            CollectionAssert.AreEqual(expectedMatrix, generatedMatrix);
        }

        [TestMethod]
        public void TestMatrixWithSizeOfSix()
        {
            int[,] expectedMatrix = 
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            int[,] generatedMatrix = Matrix.FillMatrix(6);

            CollectionAssert.AreEqual(expectedMatrix, generatedMatrix);
        }
    }
}
