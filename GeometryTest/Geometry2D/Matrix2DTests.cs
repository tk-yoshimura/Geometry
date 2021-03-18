using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Matrix2DTests {
        [TestMethod()]
        public void Matrix2DTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4);
            Matrix2D matrix2 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(matrix1.E11, 1);
            Assert.AreEqual(matrix1.E12, 2);
            Assert.AreEqual(matrix1.E13, 0);
            Assert.AreEqual(matrix1.E21, 3);
            Assert.AreEqual(matrix1.E22, 4);
            Assert.AreEqual(matrix1.E23, 0);
            Assert.AreEqual(matrix1.E31, 0);
            Assert.AreEqual(matrix1.E32, 0);
            Assert.AreEqual(matrix1.E33, 1);

            Assert.AreEqual(matrix2.E11, 1);
            Assert.AreEqual(matrix2.E12, 2);
            Assert.AreEqual(matrix2.E13, 3);
            Assert.AreEqual(matrix2.E21, 4);
            Assert.AreEqual(matrix2.E22, 5);
            Assert.AreEqual(matrix2.E23, 6);
            Assert.AreEqual(matrix2.E31, 7);
            Assert.AreEqual(matrix2.E32, 8);
            Assert.AreEqual(matrix2.E33, 9);
        }

        [TestMethod()]
        public void TransposeTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9).Transpose;

            Assert.AreEqual(matrix1, new Matrix2D(1, 4, 7, 2, 5, 8, 3, 6, 9));
        }

        [TestMethod()]
        public void OperatorTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix2D matrix2 = new Matrix2D(1, 3, 5, 7, 9, 2, 4, 6, 8);
            Matrix2D matrix3 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(+matrix1, new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9));
            Assert.AreEqual(-matrix1, new Matrix2D(-1, -2, -3, -4, -5, -6, -7, -8, -9));
            Assert.AreEqual(matrix1 + matrix2, new Matrix2D(2, 5, 8, 11, 14, 8, 11, 14, 17));
            Assert.AreEqual(matrix1 - matrix2, new Matrix2D(0, -1, -2, -3, -4, 4, 3, 2, 1));
            Assert.AreEqual(matrix2 - matrix1, new Matrix2D(0, 1, 2, 3, 4, -4, -3, -2, -1));
            Assert.AreEqual(matrix1 * matrix2, new Matrix2D(27, 39, 33, 63, 93, 78, 99, 147, 123));
            Assert.AreEqual(matrix2 * matrix1, new Matrix2D(48, 57, 66, 57, 75, 93, 84, 102, 120));
            Assert.AreEqual(2 * matrix1, new Matrix2D(2, 4, 6, 8, 10, 12, 14, 16, 18));
            Assert.AreEqual(matrix1 * 2, new Matrix2D(2, 4, 6, 8, 10, 12, 14, 16, 18));
            Assert.AreEqual(matrix1 / 2, new Matrix2D(0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5));

            Assert.AreEqual(matrix1 == matrix3, true);
            Assert.AreEqual(matrix2 == matrix3, false);
            Assert.AreEqual(matrix1 != matrix2, true);
        }

        [TestMethod()]
        public void EqualsTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix2D matrix2 = new Matrix2D(1, 3, 5, 7, 9, 2, 4, 6, 8);
            Matrix2D matrix3 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(matrix1.Equals(matrix1), true);
            Assert.AreEqual(matrix1.Equals(matrix2), false);
            Assert.AreEqual(matrix1.Equals(matrix3), true);
            Assert.AreEqual(matrix1.Equals(null), false);
        }

        [TestMethod()]
        public void StaticMatrixTest() {
            Matrix2D matrix1 = Matrix2D.Zero;
            Matrix2D matrix2 = Matrix2D.Identity;
            Matrix2D matrix3 = Matrix2D.Invalid;

            Assert.AreEqual(matrix1.E11, 0);
            Assert.AreEqual(matrix1.E12, 0);
            Assert.AreEqual(matrix1.E13, 0);
            Assert.AreEqual(matrix1.E21, 0);
            Assert.AreEqual(matrix1.E22, 0);
            Assert.AreEqual(matrix1.E23, 0);
            Assert.AreEqual(matrix1.E31, 0);
            Assert.AreEqual(matrix1.E32, 0);
            Assert.AreEqual(matrix1.E33, 0);

            Assert.AreEqual(matrix2.E11, 1);
            Assert.AreEqual(matrix2.E12, 0);
            Assert.AreEqual(matrix2.E13, 0);
            Assert.AreEqual(matrix2.E21, 0);
            Assert.AreEqual(matrix2.E22, 1);
            Assert.AreEqual(matrix2.E23, 0);
            Assert.AreEqual(matrix2.E31, 0);
            Assert.AreEqual(matrix2.E32, 0);
            Assert.AreEqual(matrix2.E33, 1);

            Assert.AreEqual(double.IsNaN(matrix3.E11), true);
            Assert.AreEqual(double.IsNaN(matrix3.E12), true);
            Assert.AreEqual(double.IsNaN(matrix3.E13), true);
            Assert.AreEqual(double.IsNaN(matrix3.E21), true);
            Assert.AreEqual(double.IsNaN(matrix3.E22), true);
            Assert.AreEqual(double.IsNaN(matrix3.E23), true);
            Assert.AreEqual(double.IsNaN(matrix3.E31), true);
            Assert.AreEqual(double.IsNaN(matrix3.E32), true);
            Assert.AreEqual(double.IsNaN(matrix3.E33), true);
        }

        [TestMethod()]
        public void RotateTest() {
            Vector2D vector = new Vector2D(1, 2);

            Assert.AreEqual((Matrix2D.Rotate(0) * vector - new Vector2D(1, 2)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix2D.Rotate(Math.PI / 2) * vector - new Vector2D(-2, 1)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix2D.Rotate(Math.PI) * vector - new Vector2D(-1, -2)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix2D.Rotate(Math.PI * 3 / 2) * vector - new Vector2D(2, -1)).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void ScaleTest() {
            Vector2D vector = new Vector2D(1, 2);

            Assert.AreEqual(Matrix2D.Scale(2, 3) * vector, new Vector2D(2, 6));
        }

        [TestMethod()]
        public void MoveTest() {
            Vector2D vector = new Vector2D(1, 2);

            Assert.AreEqual(Matrix2D.Move(2, -3) * vector, new Vector2D(3, -1));
        }

        [TestMethod()]
        public void ToStringTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(matrix1.ToString(), "{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }");
        }
    }
}