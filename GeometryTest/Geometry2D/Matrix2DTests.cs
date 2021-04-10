using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Matrix2DTests {
        [TestMethod()]
        public void Matrix2DTest() {
            Matrix2D matrix1 = new(1, 2, 3, 4);
            Matrix2D matrix2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(1, matrix1.E11);
            Assert.AreEqual(2, matrix1.E12);
            Assert.AreEqual(0, matrix1.E13);
            Assert.AreEqual(3, matrix1.E21);
            Assert.AreEqual(4, matrix1.E22);
            Assert.AreEqual(0, matrix1.E23);
            Assert.AreEqual(0, matrix1.E31);
            Assert.AreEqual(0, matrix1.E32);
            Assert.AreEqual(1, matrix1.E33);

            Assert.AreEqual(1, matrix2.E11);
            Assert.AreEqual(2, matrix2.E12);
            Assert.AreEqual(3, matrix2.E13);
            Assert.AreEqual(4, matrix2.E21);
            Assert.AreEqual(5, matrix2.E22);
            Assert.AreEqual(6, matrix2.E23);
            Assert.AreEqual(7, matrix2.E31);
            Assert.AreEqual(8, matrix2.E32);
            Assert.AreEqual(9, matrix2.E33);
        }

        [TestMethod()]
        public void TransposeTest() {
            Matrix2D matrix1 = new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9).Transpose;

            Assert.AreEqual(new Matrix2D(1, 4, 7, 2, 5, 8, 3, 6, 9), matrix1);
        }

        [TestMethod()]
        public void OperatorTest() {
            Matrix2D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix2D matrix2 = new(1, 3, 5, 7, 9, 2, 4, 6, 8);
            Matrix2D matrix3 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual(new Matrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9), +matrix1);
            Assert.AreEqual(new Matrix2D(-1, -2, -3, -4, -5, -6, -7, -8, -9), -matrix1);
            Assert.AreEqual(new Matrix2D(2, 5, 8, 11, 14, 8, 11, 14, 17), matrix1 + matrix2);
            Assert.AreEqual(new Matrix2D(0, -1, -2, -3, -4, 4, 3, 2, 1), matrix1 - matrix2);
            Assert.AreEqual(new Matrix2D(0, 1, 2, 3, 4, -4, -3, -2, -1), matrix2 - matrix1);
            Assert.AreEqual(new Matrix2D(27, 39, 33, 63, 93, 78, 99, 147, 123), matrix1 * matrix2);
            Assert.AreEqual(new Matrix2D(48, 57, 66, 57, 75, 93, 84, 102, 120), matrix2 * matrix1);
            Assert.AreEqual(new Matrix2D(2, 4, 6, 8, 10, 12, 14, 16, 18), 2 * matrix1);
            Assert.AreEqual(new Matrix2D(2, 4, 6, 8, 10, 12, 14, 16, 18), matrix1 * 2);
            Assert.AreEqual(new Matrix2D(0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5), matrix1 / 2);

            Assert.IsTrue(matrix1 == matrix3);
            Assert.IsFalse(matrix2 == matrix3);
            Assert.IsTrue(matrix1 != matrix2);
        }

        [TestMethod()]
        public void EqualsTest() {
            Matrix2D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix2D matrix2 = new(1, 3, 5, 7, 9, 2, 4, 6, 8);
            Matrix2D matrix3 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.IsTrue(matrix1.Equals(matrix1));
            Assert.IsFalse(matrix1.Equals(matrix2));
            Assert.IsTrue(matrix1.Equals(matrix3));
            Assert.IsFalse(matrix1.Equals(null));
        }

        [TestMethod()]
        public void StaticMatrixTest() {
            Matrix2D matrix1 = Matrix2D.Zero;
            Matrix2D matrix2 = Matrix2D.Identity;
            Matrix2D matrix3 = Matrix2D.Invalid;

            Assert.AreEqual(0, matrix1.E11);
            Assert.AreEqual(0, matrix1.E12);
            Assert.AreEqual(0, matrix1.E13);
            Assert.AreEqual(0, matrix1.E21);
            Assert.AreEqual(0, matrix1.E22);
            Assert.AreEqual(0, matrix1.E23);
            Assert.AreEqual(0, matrix1.E31);
            Assert.AreEqual(0, matrix1.E32);
            Assert.AreEqual(0, matrix1.E33);

            Assert.AreEqual(1, matrix2.E11);
            Assert.AreEqual(0, matrix2.E12);
            Assert.AreEqual(0, matrix2.E13);
            Assert.AreEqual(0, matrix2.E21);
            Assert.AreEqual(1, matrix2.E22);
            Assert.AreEqual(0, matrix2.E23);
            Assert.AreEqual(0, matrix2.E31);
            Assert.AreEqual(0, matrix2.E32);
            Assert.AreEqual(1, matrix2.E33);

            Assert.IsTrue(double.IsNaN(matrix3.E11));
            Assert.IsTrue(double.IsNaN(matrix3.E12));
            Assert.IsTrue(double.IsNaN(matrix3.E13));
            Assert.IsTrue(double.IsNaN(matrix3.E21));
            Assert.IsTrue(double.IsNaN(matrix3.E22));
            Assert.IsTrue(double.IsNaN(matrix3.E23));
            Assert.IsTrue(double.IsNaN(matrix3.E31));
            Assert.IsTrue(double.IsNaN(matrix3.E32));
            Assert.IsTrue(double.IsNaN(matrix3.E33));
        }

        [TestMethod()]
        public void RotateTest() {
            Vector2D vector = new(1, 2);

            Assert.IsTrue((Matrix2D.Rotate(0) * vector - new Vector2D(1, 2)).Norm < 1e-12);
            Assert.IsTrue((Matrix2D.Rotate(Math.PI / 2) * vector - new Vector2D(-2, 1)).Norm < 1e-12);
            Assert.IsTrue((Matrix2D.Rotate(Math.PI) * vector - new Vector2D(-1, -2)).Norm < 1e-12);
            Assert.IsTrue((Matrix2D.Rotate(Math.PI * 3 / 2) * vector - new Vector2D(2, -1)).Norm < 1e-12);
        }

        [TestMethod()]
        public void ScaleTest() {
            Vector2D vector = new(1, 2);

            Assert.AreEqual(new Vector2D(2, 6), Matrix2D.Scale(2, 3) * vector);
        }

        [TestMethod()]
        public void MoveTest() {
            Vector2D vector = new(1, 2);

            Assert.AreEqual(new Vector2D(3, -1), Matrix2D.Move(2, -3) * vector);
        }

        [TestMethod()]
        public void ToStringTest() {
            Matrix2D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.AreEqual("{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }", matrix1.ToString());
        }
    }
}