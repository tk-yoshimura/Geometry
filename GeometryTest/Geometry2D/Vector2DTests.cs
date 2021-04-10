using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Vector2DTests {
        [TestMethod()]
        public void Vector2DTest() {
            Vector2D vector = new(1, 2);

            Assert.AreEqual(1.0, vector.X);
            Assert.AreEqual(2.0, vector.Y);

            vector.X = 2;
            vector.Y = 4;

            Assert.AreEqual(2.0, vector.X);
            Assert.AreEqual(4.0, vector.Y);
        }

        [TestMethod()]
        public void OperatorTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = new(3, 4);
            Vector2D vector3 = new(1, 2);

            Assert.AreEqual(new Vector2D(1, 2), +vector1);
            Assert.AreEqual(new Vector2D(-1, -2), -vector1);
            Assert.AreEqual(new Vector2D(4, 6), vector1 + vector2);
            Assert.AreEqual(new Vector2D(-2, -2), vector1 - vector2);
            Assert.AreEqual(new Vector2D(2, 2), vector2 - vector1);
            Assert.AreEqual(new Vector2D(2, 4), vector1 * 2);
            Assert.AreEqual(new Vector2D(2, 4), 2 * vector1);
            Assert.AreEqual(new Vector2D(0.5, 1), vector1 / 2);

            Assert.IsTrue(vector1 == vector3);
            Assert.IsFalse(vector2 == vector3);
            Assert.IsTrue(vector1 != vector2);
        }

        [TestMethod()]
        public void NormTest() {
            Vector2D vector1 = new(1, 2);

            Assert.AreEqual(Math.Sqrt(5), vector1.Norm);
            Assert.AreEqual(5, vector1.SquareNorm);
        }

        [TestMethod()]
        public void NormalTest() {
            Vector2D vector1 = new Vector2D(1, 2).Normal;

            Assert.AreEqual(1 / Math.Sqrt(5), vector1.X);
            Assert.AreEqual(2 / Math.Sqrt(5), vector1.Y);
        }

        [TestMethod()]
        public void EqualsTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = new(3, 4);
            Vector2D vector3 = new(1, 2);

            Assert.IsTrue(vector1.Equals(vector1));
            Assert.IsFalse(vector1.Equals(vector2));
            Assert.IsTrue(vector1.Equals(vector3));
            Assert.IsFalse(vector1.Equals(null));
        }

        [TestMethod()]
        public void DistanceTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = new(4, 6);

            Assert.AreEqual(Math.Sqrt(25), Vector2D.Distance(vector1, vector2));
            Assert.AreEqual(25, Vector2D.SquareDistance(vector1, vector2));
        }

        [TestMethod()]
        public void InnerProductTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = new(4, -6);

            Assert.AreEqual(-8.0, Vector2D.InnerProduct(vector1, vector2));
        }

        [TestMethod()]
        public void IsZeroTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = Vector2D.Zero;
            Vector2D vector3 = Vector2D.Invalid;

            Assert.IsFalse(Vector2D.IsZero(vector1));
            Assert.IsTrue(Vector2D.IsZero(vector2));
            Assert.IsFalse(Vector2D.IsZero(vector3));
        }

        [TestMethod()]
        public void IsValidTest() {
            Vector2D vector1 = new(1, 2);
            Vector2D vector2 = Vector2D.Zero;
            Vector2D vector3 = Vector2D.Invalid;

            Assert.IsTrue(Vector2D.IsValid(vector1));
            Assert.IsTrue(Vector2D.IsValid(vector2));
            Assert.IsFalse(Vector2D.IsValid(vector3));

            vector1.Y = double.NaN;

            Assert.IsFalse(Vector2D.IsValid(vector1));
        }

        [TestMethod()]
        public void ToStringTest() {
            Vector2D vector1 = new(1, 2);

            Assert.AreEqual("1,2", vector1.ToString());
        }
    }
}