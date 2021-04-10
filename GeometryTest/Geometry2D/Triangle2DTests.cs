using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Triangle2DTests {
        [TestMethod()]
        public void Triangle2DTest() {
            Triangle2D triangle1 = new(new Vector2D(8, 1), new Vector2D(2, 3), new Vector2D(4, 9));
            Triangle2D triangle2 = Matrix2D.Move(2, 4) * Matrix2D.Scale(1, 2) * triangle1;

            Assert.AreEqual((2 * 2 + 6 * 6) / 2, triangle1.Area);
            Assert.AreEqual(2 * 2 + 6 * 6, triangle2.Area);

            Assert.AreEqual(new Vector2D(8 * 1 + 2, 1 * 2 + 4), triangle2.V0);
            Assert.AreEqual(new Vector2D(2 * 1 + 2, 3 * 2 + 4), triangle2.V1);
            Assert.AreEqual(new Vector2D(4 * 1 + 2, 9 * 2 + 4), triangle2.V2);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Triangle2D.IsValid(new Triangle2D(new Vector2D(8, 1), new Vector2D(2, 3), new Vector2D(4, 9))));
            Assert.IsFalse(Triangle2D.IsValid(Triangle2D.Invalid));
        }
    }
}