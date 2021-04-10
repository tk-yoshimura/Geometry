using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Line3DTests {
        [TestMethod()]
        public void Line3DTest() {
            Line3D line1 = new(new Vector3D(6, 1, 3), new Vector3D(-1, 2, 3));
            Line3D line2 = Matrix3D.Move(2, 4, 6) * Matrix3D.Scale(1, 2, 3) * line1;

            Assert.AreEqual(new Vector3D(6 * 1 + 2, 1 * 2 + 4, 3 * 3 + 6), line2.V);
            Assert.AreEqual(new Vector3D(-1 * 1, 2 * 2, 3 * 3), line2.Direction);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Line3D.IsValid(new Line3D(new Vector3D(6, 1, 3), new Vector3D(-1, 2, 3))));
            Assert.IsFalse(Line3D.IsValid(Line3D.Invalid));
        }
    }
}