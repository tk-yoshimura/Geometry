using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Triangle2DTests {
        [TestMethod()]
        public void Triangle2DTest() {
            Triangle2D triangle1 = new Triangle2D(new Vector2D(8, 1), new Vector2D(2, 3), new Vector2D(4, 9));
            Triangle2D triangle2 = Matrix2D.Move(2, 4) * Matrix2D.Scale(1, 2) * triangle1;

            Assert.AreEqual(triangle1.Area, (2 * 2 + 6 * 6) / 2);
            Assert.AreEqual(triangle2.Area, 2 * 2 + 6 * 6);

            Assert.AreEqual(triangle2.V0, new Vector2D(8 * 1 + 2, 1 * 2 + 4));
            Assert.AreEqual(triangle2.V1, new Vector2D(2 * 1 + 2, 3 * 2 + 4));
            Assert.AreEqual(triangle2.V2, new Vector2D(4 * 1 + 2, 9 * 2 + 4));
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Triangle2D.IsValid(new Triangle2D(new Vector2D(8, 1), new Vector2D(2, 3), new Vector2D(4, 9))), true);
            Assert.AreEqual(Triangle2D.IsValid(Triangle2D.Invalid), false);
        }
    }
}