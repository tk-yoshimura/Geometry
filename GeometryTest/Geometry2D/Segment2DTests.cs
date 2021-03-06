using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Segment2DTests {
        [TestMethod()]
        public void Segment2DTest() {
            Segment2D segment1 = new(new Vector2D(6, 1), new Vector2D(-1, 2));
            Segment2D segment2 = Matrix2D.Move(2, 4) * Matrix2D.Scale(1, 2) * segment1;

            Assert.AreEqual(Math.Sqrt(7 * 7 + 1 * 1), segment1.Length);

            Assert.AreEqual(new Vector2D(6 * 1 + 2, 1 * 2 + 4), segment2.V0);
            Assert.AreEqual(new Vector2D(-1 * 1 + 2, 2 * 2 + 4), segment2.V1);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Segment2D.IsValid(new Segment2D(new Vector2D(6, 1), new Vector2D(-1, 2))));
            Assert.IsFalse(Segment2D.IsValid(Segment2D.Invalid));
        }
    }
}