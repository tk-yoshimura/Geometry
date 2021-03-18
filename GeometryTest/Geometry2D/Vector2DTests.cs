using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Vector2DTests {
        [TestMethod()]
        public void Vector2DTest() {
            Vector2D vector = new Vector2D(1, 2);

            Assert.AreEqual(vector.X, 1.0);
            Assert.AreEqual(vector.Y, 2.0);

            vector.X = 2;
            vector.Y = 4;

            Assert.AreEqual(vector.X, 2.0);
            Assert.AreEqual(vector.Y, 4.0);
        }

        [TestMethod()]
        public void OperatorTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = new Vector2D(3, 4);
            Vector2D vector3 = new Vector2D(1, 2);

            Assert.AreEqual(+vector1, new Vector2D(1, 2));
            Assert.AreEqual(-vector1, new Vector2D(-1, -2));
            Assert.AreEqual(vector1 + vector2, new Vector2D(4, 6));
            Assert.AreEqual(vector1 - vector2, new Vector2D(-2, -2));
            Assert.AreEqual(vector2 - vector1, new Vector2D(2, 2));
            Assert.AreEqual(vector1 * 2, new Vector2D(2, 4));
            Assert.AreEqual(2 * vector1, new Vector2D(2, 4));
            Assert.AreEqual(vector1 / 2, new Vector2D(0.5, 1));

            Assert.AreEqual(vector1 == vector3, true);
            Assert.AreEqual(vector2 == vector3, false);
            Assert.AreEqual(vector1 != vector2, true);
        }

        [TestMethod()]
        public void NormTest() {
            Vector2D vector1 = new Vector2D(1, 2);

            Assert.AreEqual(vector1.Norm, Math.Sqrt(5));
            Assert.AreEqual(vector1.SquareNorm, 5);
        }

        [TestMethod()]
        public void NormalTest() {
            Vector2D vector1 = new Vector2D(1, 2).Normal;

            Assert.AreEqual(vector1.X, 1 / Math.Sqrt(5));
            Assert.AreEqual(vector1.Y, 2 / Math.Sqrt(5));
        }

        [TestMethod()]
        public void EqualsTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = new Vector2D(3, 4);
            Vector2D vector3 = new Vector2D(1, 2);

            Assert.AreEqual(vector1.Equals(vector1), true);
            Assert.AreEqual(vector1.Equals(vector2), false);
            Assert.AreEqual(vector1.Equals(vector3), true);
            Assert.AreEqual(vector1.Equals(null), false);
        }

        [TestMethod()]
        public void DistanceTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = new Vector2D(4, 6);

            Assert.AreEqual(Vector2D.Distance(vector1, vector2), Math.Sqrt(25));
            Assert.AreEqual(Vector2D.SquareDistance(vector1, vector2), 25);
        }

        [TestMethod()]
        public void InnerProductTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = new Vector2D(4, -6);

            Assert.AreEqual(Vector2D.InnerProduct(vector1, vector2), -8.0);
        }

        [TestMethod()]
        public void IsZeroTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = Vector2D.Zero;
            Vector2D vector3 = Vector2D.Invalid;

            Assert.AreEqual(Vector2D.IsZero(vector1), false);
            Assert.AreEqual(Vector2D.IsZero(vector2), true);
            Assert.AreEqual(Vector2D.IsZero(vector3), false);
        }

        [TestMethod()]
        public void IsValidTest() {
            Vector2D vector1 = new Vector2D(1, 2);
            Vector2D vector2 = Vector2D.Zero;
            Vector2D vector3 = Vector2D.Invalid;

            Assert.AreEqual(Vector2D.IsValid(vector1), true);
            Assert.AreEqual(Vector2D.IsValid(vector2), true);
            Assert.AreEqual(Vector2D.IsValid(vector3), false);

            vector1.Y = double.NaN;

            Assert.AreEqual(Vector2D.IsValid(vector1), false);
        }

        [TestMethod()]
        public void ToStringTest() {
            Vector2D vector1 = new Vector2D(1, 2);

            Assert.AreEqual(vector1.ToString(), "1,2");
        }
    }
}