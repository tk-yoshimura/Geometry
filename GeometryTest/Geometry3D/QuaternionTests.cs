using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class QuaternionTests {
        [TestMethod()]
        public void QuaternionTest() {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(new Vector3D(5, 6, 7));

            Assert.AreEqual(q1.R, 1);
            Assert.AreEqual(q1.I, 2);
            Assert.AreEqual(q1.J, 3);
            Assert.AreEqual(q1.K, 4);

            Assert.AreEqual(q2.R, 0);
            Assert.AreEqual(q2.I, 5);
            Assert.AreEqual(q2.J, 6);
            Assert.AreEqual(q2.K, 7);
        }

        [TestMethod()]
        public void OperatorTest() {
            Vector3D vector1 = new Vector3D(5, 6, 7);
            Vector3D vector2 = new Vector3D(1, 2, 3);

            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(vector1);
            Quaternion q3 = new Quaternion(vector1, 1);
            Quaternion q4 = new Quaternion(vector1, vector2);
            Quaternion q5 = new Quaternion(1, 2, 3, 4);

            Assert.AreEqual(+q1, new Quaternion(1, 2, 3, 4));
            Assert.AreEqual(-q1, new Quaternion(-1, -2, -3, -4));
            Assert.AreEqual(q1 + q2, new Quaternion(1, 7, 9, 11));
            Assert.AreEqual(q1 - q2, new Quaternion(1, -3, -3, -3));
            Assert.AreEqual(q2 - q1, new Quaternion(-1, 3, 3, 3));
            Assert.AreEqual(2 * q1, new Quaternion(2, 4, 6, 8));
            Assert.AreEqual(q1 * 2, new Quaternion(2, 4, 6, 8));
            Assert.AreEqual(q1 / 2, new Quaternion(0.5, 1, 1.5, 2));
            Assert.AreEqual((q1 / q3 * q3 - q1).Norm < 1e-12, true);

            Assert.AreEqual(q1 == q2, false);
            Assert.AreEqual(q1 == q5, true);
            Assert.AreEqual(q1 != q2, true);

            Assert.AreEqual((q3 * vector1 * q3.Conjugate - vector1).Norm < 1e-12, true);
            Assert.AreEqual((q4 * vector1 * q4.Conjugate - vector2).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void NormTest() {
            Quaternion q = new Quaternion(1, 2, 3, 4);

            Assert.AreEqual(q.Norm, Math.Sqrt(30));
            Assert.AreEqual(q.SquareNorm, 30);
        }

        [TestMethod()]
        public void UnitTest() {
            Quaternion q = new Quaternion(1, 2, -3, -4).Unit;

            Assert.AreEqual(q.R, 1 / Math.Sqrt(30));
            Assert.AreEqual(q.I, 2 / Math.Sqrt(30));
            Assert.AreEqual(q.J, -3 / Math.Sqrt(30));
            Assert.AreEqual(q.K, -4 / Math.Sqrt(30));
        }

        [TestMethod()]
        public void ConjugateTest() {
            Quaternion q = new Quaternion(1, 2, -3, -4).Conjugate;

            Assert.AreEqual(q.R, 1);
            Assert.AreEqual(q.I, -2);
            Assert.AreEqual(q.J, 3);
            Assert.AreEqual(q.K, 4);
        }

        [TestMethod()]
        public void InverseTest() {
            Quaternion q = new Quaternion(1, 2, -3, -4);

            Assert.AreEqual((q * q.Inverse - Quaternion.Identity).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void EqualsTest() {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(1, 2, 3, 4);
            Quaternion q3 = new Quaternion(1, 2, 3, 5);

            Assert.AreEqual(q1.Equals(q1), true);
            Assert.AreEqual(q1.Equals(q2), true);
            Assert.AreEqual(q1.Equals(q3), false);
            Assert.AreEqual(q1.Equals(null), false);
        }

        [TestMethod()]
        public void IsZeroTest() {
            Quaternion q1 = new Quaternion(1, 0, 0, 1);
            Quaternion q2 = Quaternion.Zero;

            Assert.AreEqual(Quaternion.IsZero(q1), false);
            Assert.AreEqual(Quaternion.IsZero(q2), true);
        }

        [TestMethod()]
        public void IsNaNTest() {
            Quaternion q1 = new Quaternion(1, 0, 0, 1);
            Quaternion q2 = new Quaternion(1, 0, 0, double.NaN);
            Quaternion q3 = new Quaternion(1, 0, 0, double.PositiveInfinity);

            Assert.AreEqual(Quaternion.IsNaN(q1), false);
            Assert.AreEqual(Quaternion.IsNaN(q2), true);
            Assert.AreEqual(Quaternion.IsNaN(q3), false);
        }

        [TestMethod()]
        public void IsInfinityTest() {
            Quaternion q1 = new Quaternion(1, 0, 0, 1);
            Quaternion q2 = new Quaternion(1, 0, 0, double.NaN);
            Quaternion q3 = new Quaternion(1, 0, 0, double.PositiveInfinity);

            Assert.AreEqual(Quaternion.IsInfinity(q1), false);
            Assert.AreEqual(Quaternion.IsInfinity(q2), false);
            Assert.AreEqual(Quaternion.IsInfinity(q3), true);
        }

        [TestMethod()]
        public void IsValidTest() {
            Quaternion q1 = new Quaternion(1, 0, 0, 1);
            Quaternion q2 = new Quaternion(1, 0, 0, double.NaN);
            Quaternion q3 = new Quaternion(1, 0, 0, double.PositiveInfinity);

            Assert.AreEqual(Quaternion.IsValid(q1), true);
            Assert.AreEqual(Quaternion.IsValid(q2), false);
            Assert.AreEqual(Quaternion.IsValid(q3), false);
        }

        [TestMethod()]
        public void ToStringTest() {
            Quaternion q = new Quaternion(1, 2, 3, 4);

            Assert.AreEqual(q.ToString(), "1,2,3,4");
        }
    }
}