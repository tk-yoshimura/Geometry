using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class QuaternionTests {
        [TestMethod()]
        public void QuaternionTest() {
            Quaternion q1 = new(1, 2, 3, 4);
            Quaternion q2 = new(new Vector3D(5, 6, 7));

            Assert.AreEqual(1, q1.R);
            Assert.AreEqual(2, q1.I);
            Assert.AreEqual(3, q1.J);
            Assert.AreEqual(4, q1.K);

            Assert.AreEqual(0, q2.R);
            Assert.AreEqual(5, q2.I);
            Assert.AreEqual(6, q2.J);
            Assert.AreEqual(7, q2.K);
        }

        [TestMethod()]
        public void OperatorTest() {
            Vector3D vector1 = new(5, 6, 7);
            Vector3D vector2 = new(1, 2, 3);

            Quaternion q1 = new(1, 2, 3, 4);
            Quaternion q2 = new(vector1);
            Quaternion q3 = new(vector1, 1);
            Quaternion q4 = new(vector1, vector2);
            Quaternion q5 = new(1, 2, 3, 4);

            Assert.AreEqual(new Quaternion(1, 2, 3, 4), +q1);
            Assert.AreEqual(new Quaternion(-1, -2, -3, -4), -q1);
            Assert.AreEqual(new Quaternion(1, 7, 9, 11), q1 + q2);
            Assert.AreEqual(new Quaternion(1, -3, -3, -3), q1 - q2);
            Assert.AreEqual(new Quaternion(-1, 3, 3, 3), q2 - q1);
            Assert.AreEqual(new Quaternion(2, 4, 6, 8), 2 * q1);
            Assert.AreEqual(new Quaternion(2, 4, 6, 8), q1 * 2);
            Assert.AreEqual(new Quaternion(0.5, 1, 1.5, 2), q1 / 2);
            Assert.IsTrue((q1 / q3 * q3 - q1).Norm < 1e-12);

            Assert.IsFalse(q1 == q2);
            Assert.IsTrue(q1 == q5);
            Assert.IsTrue(q1 != q2);

            Assert.IsTrue((q3 * vector1 * q3.Conjugate - vector1).Norm < 1e-12);
            Assert.IsTrue((q4 * vector1 * q4.Conjugate - vector2).Norm < 1e-12);
        }

        [TestMethod()]
        public void NormTest() {
            Quaternion q = new(1, 2, 3, 4);

            Assert.AreEqual(q.Norm, Math.Sqrt(30));
            Assert.AreEqual(30, q.SquareNorm);
        }

        [TestMethod()]
        public void UnitTest() {
            Quaternion q = new Quaternion(1, 2, -3, -4).Unit;

            Assert.AreEqual(1 / Math.Sqrt(30), q.R);
            Assert.AreEqual(2 / Math.Sqrt(30), q.I);
            Assert.AreEqual(-3 / Math.Sqrt(30), q.J);
            Assert.AreEqual(-4 / Math.Sqrt(30), q.K);
        }

        [TestMethod()]
        public void ConjugateTest() {
            Quaternion q = new Quaternion(1, 2, -3, -4).Conjugate;

            Assert.AreEqual(1, q.R);
            Assert.AreEqual(-2, q.I);
            Assert.AreEqual(3, q.J);
            Assert.AreEqual(4, q.K);
        }

        [TestMethod()]
        public void InverseTest() {
            Quaternion q = new(1, 2, -3, -4);

            Assert.IsTrue((q * q.Inverse - Quaternion.Identity).Norm < 1e-12);
        }

        [TestMethod()]
        public void EqualsTest() {
            Quaternion q1 = new(1, 2, 3, 4);
            Quaternion q2 = new(1, 2, 3, 4);
            Quaternion q3 = new(1, 2, 3, 5);

            Assert.IsTrue(q1.Equals(q1));
            Assert.IsTrue(q1.Equals(q2));
            Assert.IsFalse(q1.Equals(q3));
            Assert.IsFalse(q1.Equals(null));
        }

        [TestMethod()]
        public void IsZeroTest() {
            Quaternion q1 = new(1, 0, 0, 1);
            Quaternion q2 = Quaternion.Zero;

            Assert.IsFalse(Quaternion.IsZero(q1));
            Assert.IsTrue(Quaternion.IsZero(q2));
        }

        [TestMethod()]
        public void IsNaNTest() {
            Quaternion q1 = new(1, 0, 0, 1);
            Quaternion q2 = new(1, 0, 0, double.NaN);
            Quaternion q3 = new(1, 0, 0, double.PositiveInfinity);

            Assert.IsFalse(Quaternion.IsNaN(q1));
            Assert.IsTrue(Quaternion.IsNaN(q2));
            Assert.IsFalse(Quaternion.IsNaN(q3));
        }

        [TestMethod()]
        public void IsInfinityTest() {
            Quaternion q1 = new(1, 0, 0, 1);
            Quaternion q2 = new(1, 0, 0, double.NaN);
            Quaternion q3 = new(1, 0, 0, double.PositiveInfinity);

            Assert.IsFalse(Quaternion.IsInfinity(q1));
            Assert.IsFalse(Quaternion.IsInfinity(q2));
            Assert.IsTrue(Quaternion.IsInfinity(q3));
        }

        [TestMethod()]
        public void IsValidTest() {
            Quaternion q1 = new(1, 0, 0, 1);
            Quaternion q2 = new(1, 0, 0, double.NaN);
            Quaternion q3 = new(1, 0, 0, double.PositiveInfinity);

            Assert.IsTrue(Quaternion.IsValid(q1));
            Assert.IsFalse(Quaternion.IsValid(q2));
            Assert.IsFalse(Quaternion.IsValid(q3));
        }

        [TestMethod()]
        public void ToStringTest() {
            Quaternion q = new(1, 2, 3, 4);

            Assert.AreEqual("1,2,3,4", q.ToString());
        }
    }
}