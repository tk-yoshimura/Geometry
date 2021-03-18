using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Vector3DTests {
        [TestMethod()]
        public void Vector3DTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual(vector.X, 1.0);
            Assert.AreEqual(vector.Y, 2.0);
            Assert.AreEqual(vector.Z, 3.0);

            vector.X = 2;
            vector.Y = 4;
            vector.Z = 6;

            Assert.AreEqual(vector.X, 2.0);
            Assert.AreEqual(vector.Y, 4.0);
            Assert.AreEqual(vector.Z, 6.0);
        }

        [TestMethod()]
        public void OperatorTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 5, 6);
            Vector3D vector3 = new Vector3D(1, 2, 3);

            Assert.AreEqual(+vector1, new Vector3D(1, 2, 3));
            Assert.AreEqual(-vector1, new Vector3D(-1, -2, -3));
            Assert.AreEqual(vector1 + vector2, new Vector3D(5, 7, 9));
            Assert.AreEqual(vector1 - vector2, new Vector3D(-3, -3, -3));
            Assert.AreEqual(vector2 - vector1, new Vector3D(3, 3, 3));
            Assert.AreEqual(vector1 * 2, new Vector3D(2, 4, 6));
            Assert.AreEqual(2 * vector1, new Vector3D(2, 4, 6));
            Assert.AreEqual(vector1 / 2, new Vector3D(0.5, 1, 1.5));

            Assert.AreEqual(vector1 == vector3, true);
            Assert.AreEqual(vector2 == vector3, false);
            Assert.AreEqual(vector1 != vector2, true);
        }

        [TestMethod()]
        public void NormTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);

            Assert.AreEqual(vector1.Norm, Math.Sqrt(14));
            Assert.AreEqual(vector1.SquareNorm, 14);
        }

        [TestMethod()]
        public void NormalTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3).Normal;

            Assert.AreEqual(vector1.X, 1 / Math.Sqrt(14));
            Assert.AreEqual(vector1.Y, 2 / Math.Sqrt(14));
            Assert.AreEqual(vector1.Z, 3 / Math.Sqrt(14));
        }

        [TestMethod()]
        public void EqualsTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 5, 6);
            Vector3D vector3 = new Vector3D(1, 2, 3);

            Assert.AreEqual(vector1.Equals(vector1), true);
            Assert.AreEqual(vector1.Equals(vector2), false);
            Assert.AreEqual(vector1.Equals(vector3), true);
            Assert.AreEqual(vector1.Equals(null), false);
        }

        [TestMethod()]
        public void DistanceTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 6, 9);

            Assert.AreEqual(Vector3D.Distance(vector1, vector2), Math.Sqrt(61));
            Assert.AreEqual(Vector3D.SquareDistance(vector1, vector2), 61);
        }

        [TestMethod()]
        public void InnerProductTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 6, 9);

            Assert.AreEqual(Vector3D.InnerProduct(vector1, vector2), 43);
        }

        [TestMethod()]
        public void OuterProductTest() {
            Vector3D vector1 = new Vector3D(1, 2, 3);
            Vector3D vector2 = new Vector3D(4, 6, 9);

            Assert.AreEqual(vector1 * vector2, -vector2 * vector1);
            Assert.AreEqual(vector1 * vector2, new Vector3D(2 * 9 - 3 * 6, 3 * 4 - 1 * 9, 1 * 6 - 2 * 4));
        }

        [TestMethod()]
        public void IsZeroTest() {
            Vector3D vector1 = new Vector3D(0, 0, 1);
            Vector3D vector2 = Vector3D.Zero;

            Assert.AreEqual(Vector3D.IsZero(vector1), false);
            Assert.AreEqual(Vector3D.IsZero(vector2), true);
        }

        [TestMethod()]
        public void IsValidTest() {
            Vector3D vector1 = new Vector3D(0, 0, 1);
            Vector3D vector2 = Vector3D.Zero;
            Vector3D vector3 = Vector3D.Invalid;

            Assert.AreEqual(Vector3D.IsValid(vector1), true);
            Assert.AreEqual(Vector3D.IsValid(vector2), true);
            Assert.AreEqual(Vector3D.IsValid(vector3), false);
        }

        [TestMethod()]
        public void ToStringTest() {
            Vector3D vector = new Vector3D(1, 2, 3);

            Assert.AreEqual(vector.ToString(), "1,2,3");
        }
    }
}