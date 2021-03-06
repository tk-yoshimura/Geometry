using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Line2DTests {
        [TestMethod()]
        public void Line2DTest() {
            Line2D line1 = new(new Vector2D(6, 1), new Vector2D(-1, 2));
            Line2D line2 = Matrix2D.Move(2, 4) * Matrix2D.Scale(1, 2) * line1;

            Assert.AreEqual(new Vector2D(6 * 1 + 2, 1 * 2 + 4), line2.V);
            Assert.AreEqual(new Vector2D(-1 * 1, 2 * 2), line2.Direction);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Line2D.IsValid(new Line2D(new Vector2D(6, 1), new Vector2D(-1, 2))));
            Assert.IsFalse(Line2D.IsValid(Line2D.Invalid));
        }
    }
}