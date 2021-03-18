using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Matrix3DTests {
        [TestMethod()]
        public void Matrix3DTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Matrix3D matrix2 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(matrix1.E11, 1);
            Assert.AreEqual(matrix1.E12, 2);
            Assert.AreEqual(matrix1.E13, 3);
            Assert.AreEqual(matrix1.E14, 0);
            Assert.AreEqual(matrix1.E21, 4);
            Assert.AreEqual(matrix1.E22, 5);
            Assert.AreEqual(matrix1.E23, 6);
            Assert.AreEqual(matrix1.E24, 0);
            Assert.AreEqual(matrix1.E31, 7);
            Assert.AreEqual(matrix1.E32, 8);
            Assert.AreEqual(matrix1.E33, 9);
            Assert.AreEqual(matrix1.E34, 0);
            Assert.AreEqual(matrix1.E41, 0);
            Assert.AreEqual(matrix1.E42, 0);
            Assert.AreEqual(matrix1.E43, 0);
            Assert.AreEqual(matrix1.E44, 1);

            Assert.AreEqual(matrix2.E11, 1);
            Assert.AreEqual(matrix2.E12, 2);
            Assert.AreEqual(matrix2.E13, 3);
            Assert.AreEqual(matrix2.E14, 4);
            Assert.AreEqual(matrix2.E21, 5);
            Assert.AreEqual(matrix2.E22, 6);
            Assert.AreEqual(matrix2.E23, 7);
            Assert.AreEqual(matrix2.E24, 8);
            Assert.AreEqual(matrix2.E31, 9);
            Assert.AreEqual(matrix2.E32, 10);
            Assert.AreEqual(matrix2.E33, 11);
            Assert.AreEqual(matrix2.E34, 12);
            Assert.AreEqual(matrix2.E41, 13);
            Assert.AreEqual(matrix2.E42, 14);
            Assert.AreEqual(matrix2.E43, 15);
            Assert.AreEqual(matrix2.E44, 16);
        }

        [TestMethod()]
        public void TransposeTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).Transpose;

            Assert.AreEqual(matrix1, new Matrix3D(1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15, 4, 8, 12, 16));
        }

        [TestMethod()]
        public void OperatorTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix3D matrix2 = new Matrix3D(1, 3, 5, 7, 9, 11, 13, 15, 2, 4, 6, 8, 10, 12, 14, 16);
            Matrix3D matrix3 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(+matrix1, new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
            Assert.AreEqual(-matrix1, new Matrix3D(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16));
            Assert.AreEqual(matrix1 + matrix2, new Matrix3D(2, 5, 8, 11, 14, 17, 20, 23, 11, 14, 17, 20, 23, 26, 29, 32));
            Assert.AreEqual(matrix1 - matrix2, new Matrix3D(0, -1, -2, -3, -4, -5, -6, -7, 7, 6, 5, 4, 3, 2, 1, 0));
            Assert.AreEqual(matrix2 - matrix1, new Matrix3D(0, 1, 2, 3, 4, 5, 6, 7, -7, -6, -5, -4, -3, -2, -1, 0));
            Assert.AreEqual(matrix1 * matrix2, new Matrix3D(65, 85, 105, 125, 153, 205, 257, 309, 241, 325, 409, 493, 329, 445, 561, 677));
            Assert.AreEqual(matrix2 * matrix1, new Matrix3D(152, 168, 184, 200, 376, 424, 472, 520, 180, 200, 220, 240, 404, 456, 508, 560));
            Assert.AreEqual(2 * matrix1, new Matrix3D(2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32));
            Assert.AreEqual(matrix1 * 2, new Matrix3D(2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32));
            Assert.AreEqual(matrix1 / 2, new Matrix3D(0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8));

            Assert.AreEqual(matrix1 == matrix3, true);
            Assert.AreEqual(matrix2 == matrix3, false);
            Assert.AreEqual(matrix1 != matrix2, true);
        }

        [TestMethod()]
        public void EqualsTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix3D matrix2 = new Matrix3D(1, 3, 5, 7, 9, 11, 13, 15, 2, 4, 6, 8, 10, 12, 14, 16);
            Matrix3D matrix3 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(matrix1.Equals(matrix1), true);
            Assert.AreEqual(matrix1.Equals(matrix2), false);
            Assert.AreEqual(matrix1.Equals(matrix3), true);
            Assert.AreEqual(matrix1.Equals(null), false);
        }

        [TestMethod()]
        public void StaticMatrixTest() {
            Matrix3D matrix1 = Matrix3D.Zero;
            Matrix3D matrix2 = Matrix3D.Identity;
            Matrix3D matrix3 = Matrix3D.Invalid;

            Assert.AreEqual(matrix1.E11, 0);
            Assert.AreEqual(matrix1.E12, 0);
            Assert.AreEqual(matrix1.E13, 0);
            Assert.AreEqual(matrix1.E14, 0);
            Assert.AreEqual(matrix1.E21, 0);
            Assert.AreEqual(matrix1.E22, 0);
            Assert.AreEqual(matrix1.E23, 0);
            Assert.AreEqual(matrix1.E24, 0);
            Assert.AreEqual(matrix1.E31, 0);
            Assert.AreEqual(matrix1.E32, 0);
            Assert.AreEqual(matrix1.E33, 0);
            Assert.AreEqual(matrix1.E34, 0);
            Assert.AreEqual(matrix1.E41, 0);
            Assert.AreEqual(matrix1.E42, 0);
            Assert.AreEqual(matrix1.E43, 0);
            Assert.AreEqual(matrix1.E44, 0);

            Assert.AreEqual(matrix2.E11, 1);
            Assert.AreEqual(matrix2.E12, 0);
            Assert.AreEqual(matrix2.E13, 0);
            Assert.AreEqual(matrix2.E14, 0);
            Assert.AreEqual(matrix2.E21, 0);
            Assert.AreEqual(matrix2.E22, 1);
            Assert.AreEqual(matrix2.E23, 0);
            Assert.AreEqual(matrix2.E24, 0);
            Assert.AreEqual(matrix2.E31, 0);
            Assert.AreEqual(matrix2.E32, 0);
            Assert.AreEqual(matrix2.E33, 1);
            Assert.AreEqual(matrix2.E34, 0);
            Assert.AreEqual(matrix2.E41, 0);
            Assert.AreEqual(matrix2.E42, 0);
            Assert.AreEqual(matrix2.E43, 0);
            Assert.AreEqual(matrix2.E44, 1);

            Assert.AreEqual(double.IsNaN(matrix3.E11), true);
            Assert.AreEqual(double.IsNaN(matrix3.E12), true);
            Assert.AreEqual(double.IsNaN(matrix3.E13), true);
            Assert.AreEqual(double.IsNaN(matrix3.E14), true);
            Assert.AreEqual(double.IsNaN(matrix3.E21), true);
            Assert.AreEqual(double.IsNaN(matrix3.E22), true);
            Assert.AreEqual(double.IsNaN(matrix3.E23), true);
            Assert.AreEqual(double.IsNaN(matrix3.E24), true);
            Assert.AreEqual(double.IsNaN(matrix3.E31), true);
            Assert.AreEqual(double.IsNaN(matrix3.E32), true);
            Assert.AreEqual(double.IsNaN(matrix3.E33), true);
            Assert.AreEqual(double.IsNaN(matrix3.E34), true);
            Assert.AreEqual(double.IsNaN(matrix3.E41), true);
            Assert.AreEqual(double.IsNaN(matrix3.E42), true);
            Assert.AreEqual(double.IsNaN(matrix3.E43), true);
            Assert.AreEqual(double.IsNaN(matrix3.E44), true);
        }

        [TestMethod()]
        public void RotateXTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual((Matrix3D.RotateX(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateX(Math.PI / 2) * vector - new Vector3D(1, -3, 2)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateX(Math.PI) * vector - new Vector3D(1, -2, -3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateX(Math.PI * 3 / 2) * vector - new Vector3D(1, 3, -2)).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void RotateYTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual((Matrix3D.RotateY(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateY(Math.PI / 2) * vector - new Vector3D(3, 2, -1)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateY(Math.PI) * vector - new Vector3D(-1, 2, -3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateY(Math.PI * 3 / 2) * vector - new Vector3D(-3, 2, 1)).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void RotateZTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual((Matrix3D.RotateZ(0) * vector - new Vector3D(1, 2, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateZ(Math.PI / 2) * vector - new Vector3D(-2, 1, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateZ(Math.PI) * vector - new Vector3D(-1, -2, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateZ(Math.PI * 3 / 2) * vector - new Vector3D(2, -1, 3)).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void RotateAxisTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(+1, 0, 0), Math.PI / 2) * vector - new Vector3D(1, -3, 2)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(-1, 0, 0), Math.PI / 2) * vector - new Vector3D(1, 3, -2)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(0, +1, 0), Math.PI / 2) * vector - new Vector3D(3, 2, -1)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(0, -1, 0), Math.PI / 2) * vector - new Vector3D(-3, 2, 1)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(0, 0, +1), Math.PI / 2) * vector - new Vector3D(-2, 1, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(new Vector3D(0, 0, -1), Math.PI / 2) * vector - new Vector3D(2, -1, 3)).Norm < 1e-12, true);
            Assert.AreEqual((Matrix3D.RotateAxis(vector, Math.PI / 2) * vector - vector).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void ScaleTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual(Matrix3D.Scale(2, 3, 4) * vector, new Vector3D(2, 6, 12));
        }

        [TestMethod()]
        public void MoveTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual(Matrix3D.Move(2, -3, -2) * vector, new Vector3D(3, -1, 1));
        }

        [TestMethod()]
        public void ToStringTest() {
            Matrix3D matrix1 = new Matrix3D(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.AreEqual(matrix1.ToString(), "{ { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } }");
        }
    }
}