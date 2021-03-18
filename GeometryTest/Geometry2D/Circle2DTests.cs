using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Circle2DTests {
        [TestMethod()]
        public void Circle2DTest() {
            Circle2D circle = new Circle2D(new Vector2D(1, 3), 2);

            Assert.AreEqual(circle.Center, new Vector2D(1, 3));
            Assert.AreEqual(circle.Radius, 2.0);

            Assert.AreEqual(circle.Area, 4 * Math.PI);
        }

        [TestMethod()]
        public void CircumTest() {
            Vector2D v0 = new Vector2D(3, 9), v1 = new Vector2D(4, 2), v2 = new Vector2D(12, 6);

            Circle2D circle = Circle2D.Circum(new Triangle2D(v0, v1, v2));

            Assert.AreEqual(circle.Center, new Vector2D(7, 6));
            Assert.AreEqual(circle.Radius, 5);
        }

        [TestMethod()]
        public void IncircleTest() {
            Vector2D v0 = new Vector2D(2, 1), v1 = new Vector2D(6, 1), v2 = new Vector2D(6, 4);

            Circle2D circle = Circle2D.Incircle(new Triangle2D(v0, v1, v2));

            Assert.AreEqual(circle.Center, new Vector2D(5, 2));
            Assert.AreEqual(circle.Radius, 1);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Circle2D.IsValid(new Circle2D(new Vector2D(1, 3), 2)), true);
            Assert.AreEqual(Circle2D.IsValid(Circle2D.Invalid), false);
        }
    }
}