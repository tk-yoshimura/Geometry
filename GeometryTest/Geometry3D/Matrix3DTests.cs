using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Matrix3DTests {
        [TestMethod()]
        public void Matrix3DTest() {
            Matrix3D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3D matrix2 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(1, matrix1.E11);
            Assert.AreEqual(2, matrix1.E12);
            Assert.AreEqual(3, matrix1.E13);
            Assert.AreEqual(0, matrix1.E14);
            Assert.AreEqual(4, matrix1.E21);
            Assert.AreEqual(5, matrix1.E22);
            Assert.AreEqual(6, matrix1.E23);
            Assert.AreEqual(0, matrix1.E24);
            Assert.AreEqual(7, matrix1.E31);
            Assert.AreEqual(8, matrix1.E32);
            Assert.AreEqual(9, matrix1.E33);
            Assert.AreEqual(0, matrix1.E34);
            Assert.AreEqual(0, matrix1.E41);
            Assert.AreEqual(0, matrix1.E42);
            Assert.AreEqual(0, matrix1.E43);
            Assert.AreEqual(1, matrix1.E44);

            Assert.AreEqual(1, matrix2.E11);
            Assert.AreEqual(2, matrix2.E12);
            Assert.AreEqual(3, matrix2.E13);
            Assert.AreEqual(4, matrix2.E14);
            Assert.AreEqual(5, matrix2.E21);
            Assert.AreEqual(6, matrix2.E22);
            Assert.AreEqual(7, matrix2.E23);
            Assert.AreEqual(8, matrix2.E24);
            Assert.AreEqual(9, matrix2.E31);
            Assert.AreEqual(10, matrix2.E32);
            Assert.AreEqual(11, matrix2.E33);
            Assert.AreEqual(12, matrix2.E34);
            Assert.AreEqual(13, matrix2.E41);
            Assert.AreEqual(14, matrix2.E42);
            Assert.AreEqual(15, matrix2.E43);
            Assert.AreEqual(16, matrix2.E44);
        }

        [TestMethod()]
        public void TransposeTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).Transpose;

            Assert.AreEqual(new Matrix3D(1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15, 4, 8, 12, 16), matrix1);
        }

        [TestMethod()]
        public void OperatorTest() {
            Matrix3D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix3D matrix2 = new(1, 3, 5, 7, 9, 11, 13, 15, 2, 4, 6, 8, 10, 12, 14, 16);
            Matrix3D matrix3 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16), +matrix1);
            Assert.AreEqual(new Matrix3D(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16), -matrix1);
            Assert.AreEqual(new Matrix3D(2, 5, 8, 11, 14, 17, 20, 23, 11, 14, 17, 20, 23, 26, 29, 32), matrix1 + matrix2);
            Assert.AreEqual(new Matrix3D(0, -1, -2, -3, -4, -5, -6, -7, 7, 6, 5, 4, 3, 2, 1, 0), matrix1 - matrix2);
            Assert.AreEqual(new Matrix3D(0, 1, 2, 3, 4, 5, 6, 7, -7, -6, -5, -4, -3, -2, -1, 0), matrix2 - matrix1);
            Assert.AreEqual(new Matrix3D(65, 85, 105, 125, 153, 205, 257, 309, 241, 325, 409, 493, 329, 445, 561, 677), matrix1 * matrix2);
            Assert.AreEqual(new Matrix3D(152, 168, 184, 200, 376, 424, 472, 520, 180, 200, 220, 240, 404, 456, 508, 560), matrix2 * matrix1);
            Assert.AreEqual(new Matrix3D(2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32), 2 * matrix1);
            Assert.AreEqual(new Matrix3D(2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32), matrix1 * 2);
            Assert.AreEqual(new Matrix3D(0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8), matrix1 / 2);

            Assert.IsTrue(matrix1 == matrix3);
            Assert.IsFalse(matrix2 == matrix3);
            Assert.IsTrue(matrix1 != matrix2);
        }

        [TestMethod()]
        public void EqualsTest() {
            Matrix3D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix3D matrix2 = new(1, 3, 5, 7, 9, 11, 13, 15, 2, 4, 6, 8, 10, 12, 14, 16);
            Matrix3D matrix3 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.IsTrue(matrix1.Equals(matrix1));
            Assert.IsFalse(matrix1.Equals(matrix2));
            Assert.IsTrue(matrix1.Equals(matrix3));
            Assert.IsFalse(matrix1.Equals(null));
        }

        [TestMethod()]
        public void StaticMatrixTest() {
            Matrix3D matrix1 = Matrix3D.Zero;
            Matrix3D matrix2 = Matrix3D.Identity;
            Matrix3D matrix3 = Matrix3D.Invalid;

            Assert.AreEqual(0, matrix1.E11);
            Assert.AreEqual(0, matrix1.E12);
            Assert.AreEqual(0, matrix1.E13);
            Assert.AreEqual(0, matrix1.E14);
            Assert.AreEqual(0, matrix1.E21);
            Assert.AreEqual(0, matrix1.E22);
            Assert.AreEqual(0, matrix1.E23);
            Assert.AreEqual(0, matrix1.E24);
            Assert.AreEqual(0, matrix1.E31);
            Assert.AreEqual(0, matrix1.E32);
            Assert.AreEqual(0, matrix1.E33);
            Assert.AreEqual(0, matrix1.E34);
            Assert.AreEqual(0, matrix1.E41);
            Assert.AreEqual(0, matrix1.E42);
            Assert.AreEqual(0, matrix1.E43);
            Assert.AreEqual(0, matrix1.E44);

            Assert.AreEqual(1, matrix2.E11);
            Assert.AreEqual(0, matrix2.E12);
            Assert.AreEqual(0, matrix2.E13);
            Assert.AreEqual(0, matrix2.E14);
            Assert.AreEqual(0, matrix2.E21);
            Assert.AreEqual(1, matrix2.E22);
            Assert.AreEqual(0, matrix2.E23);
            Assert.AreEqual(0, matrix2.E24);
            Assert.AreEqual(0, matrix2.E31);
            Assert.AreEqual(0, matrix2.E32);
            Assert.AreEqual(1, matrix2.E33);
            Assert.AreEqual(0, matrix2.E34);
            Assert.AreEqual(0, matrix2.E41);
            Assert.AreEqual(0, matrix2.E42);
            Assert.AreEqual(0, matrix2.E43);
            Assert.AreEqual(1, matrix2.E44);

            Assert.IsTrue(double.IsNaN(matrix3.E11));
            Assert.IsTrue(double.IsNaN(matrix3.E12));
            Assert.IsTrue(double.IsNaN(matrix3.E13));
            Assert.IsTrue(double.IsNaN(matrix3.E14));
            Assert.IsTrue(double.IsNaN(matrix3.E21));
            Assert.IsTrue(double.IsNaN(matrix3.E22));
            Assert.IsTrue(double.IsNaN(matrix3.E23));
            Assert.IsTrue(double.IsNaN(matrix3.E24));
            Assert.IsTrue(double.IsNaN(matrix3.E31));
            Assert.IsTrue(double.IsNaN(matrix3.E32));
            Assert.IsTrue(double.IsNaN(matrix3.E33));
            Assert.IsTrue(double.IsNaN(matrix3.E34));
            Assert.IsTrue(double.IsNaN(matrix3.E41));
            Assert.IsTrue(double.IsNaN(matrix3.E42));
            Assert.IsTrue(double.IsNaN(matrix3.E43));
            Assert.IsTrue(double.IsNaN(matrix3.E44));
        }

        [TestMethod()]
        public void RotateXTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.IsTrue((Matrix3D.RotateX(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateX(Math.PI / 2) * vector - new Vector3D(1, -3, 2)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateX(Math.PI) * vector - new Vector3D(1, -2, -3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateX(Math.PI * 3 / 2) * vector - new Vector3D(1, 3, -2)).Norm < 1e-12);
        }

        [TestMethod()]
        public void RotateYTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.IsTrue((Matrix3D.RotateY(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateY(Math.PI / 2) * vector - new Vector3D(3, 2, -1)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateY(Math.PI) * vector - new Vector3D(-1, 2, -3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateY(Math.PI * 3 / 2) * vector - new Vector3D(-3, 2, 1)).Norm < 1e-12);
        }

        [TestMethod()]
        public void RotateZTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.IsTrue((Matrix3D.RotateZ(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateZ(Math.PI / 2) * vector - new Vector3D(-2, 1, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateZ(Math.PI) * vector - new Vector3D(-1, -2, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateZ(Math.PI * 3 / 2) * vector - new Vector3D(2, -1, 3)).Norm < 1e-12);
        }

        [TestMethod()]
        public void RotateAxisTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(+1, 0, 0), Math.PI / 2) * vector - new Vector3D(1, -3, 2)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(-1, 0, 0), Math.PI / 2) * vector - new Vector3D(1, 3, -2)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(0, +1, 0), Math.PI / 2) * vector - new Vector3D(3, 2, -1)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(0, -1, 0), Math.PI / 2) * vector - new Vector3D(-3, 2, 1)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(0, 0, +1), Math.PI / 2) * vector - new Vector3D(-2, 1, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(new Vector3D(0, 0, -1), Math.PI / 2) * vector - new Vector3D(2, -1, 3)).Norm < 1e-12);
            Assert.IsTrue((Matrix3D.RotateAxis(vector, Math.PI / 2) * vector - vector).Norm < 1e-12);
        }

        [TestMethod()]
        public void ScaleTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.AreEqual(new Vector3D(2, 6, 12), Matrix3D.Scale(2, 3, 4) * vector);
        }

        [TestMethod()]
        public void MoveTest() {
            Vector3D vector = new(1, 2, 3);

            Assert.AreEqual(new Vector3D(3, -1, 1), Matrix3D.Move(2, -3, -2) * vector);
        }

        [TestMethod()]
        public void ToStringTest() {
            Matrix3D matrix1 = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual("{ { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } }", matrix1.ToString());
        }
    }
}