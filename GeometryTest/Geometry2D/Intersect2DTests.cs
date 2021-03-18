using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry2D.Tests {
    [TestClass()]
    public class Intersect2DTests {
        [TestMethod()]
        public void LineLineTest() {
            Line2D line1 = new Line2D(new Vector2D(1, 3), new Vector2D(3, 2));
            Line2D line2 = new Line2D(new Vector2D(6, 1), new Vector2D(-1, 2));

            Vector2D cross = Intersect2D.LineLine(line1, line2);

            Assert.AreEqual(cross, new Vector2D(4, 5));
        }

        [TestMethod()]
        public void CircleLineTest() {
            Line2D line = new Line2D(new Vector2D(4, 1), new Vector2D(1, 3));
            Circle2D circle = new Circle2D(new Vector2D(6, 12), 5);

            Vector2D[] cross = Intersect2D.CircleLine(circle, line);

            Assert.AreEqual(cross[0], new Vector2D(6, 7));
            Assert.AreEqual(cross[1], new Vector2D(9, 16));
        }
    }
}