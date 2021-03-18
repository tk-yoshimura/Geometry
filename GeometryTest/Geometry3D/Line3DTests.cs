using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Line3DTests {
        [TestMethod()]
        public void Line3DTest() {
            Line3D line1 = new Line3D(new Vector3D(6, 1, 3), new Vector3D(-1, 2, 3));
            Line3D line2 = Matrix3D.Move(2, 4, 6) * Matrix3D.Scale(1, 2, 3) * line1;

            Assert.AreEqual(line2.V, new Vector3D(6 * 1 + 2, 1 * 2 + 4, 3 * 3 + 6));
            Assert.AreEqual(line2.Direction, new Vector3D(-1 * 1, 2 * 2, 3 * 3));
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Line3D.IsValid(new Line3D(new Vector3D(6, 1, 3), new Vector3D(-1, 2, 3))), true);
            Assert.AreEqual(Line3D.IsValid(Line3D.Invalid), false);
        }
    }
}