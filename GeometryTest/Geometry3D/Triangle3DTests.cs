using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Triangle3DTests {
        [TestMethod()]
        public void Triangle3DTest() {
            Triangle3D triangle1 = new Triangle3D(new Vector3D(8, 1, 1), new Vector3D(2, 3, 1), new Vector3D(4, 9, 1));
            Triangle3D triangle2 = Matrix3D.Move(2, 4, 6) * Matrix3D.Scale(1, 2, 3) * triangle1;

            Assert.AreEqual((Matrix3D.Rotate(1, 1, 1) * triangle1).Area, (2 * 2 + 6 * 6) / 2, 1e-12);
            Assert.AreEqual((Matrix3D.Rotate(1, 2, 3) * triangle2).Area, 2 * 2 + 6 * 6, 1e-12);
            
            Assert.AreEqual(triangle2.V0, new Vector3D(8 * 1 + 2, 1 * 2 + 4, 1 * 3 + 6));
            Assert.AreEqual(triangle2.V1, new Vector3D(2 * 1 + 2, 3 * 2 + 4, 1 * 3 + 6));
            Assert.AreEqual(triangle2.V2, new Vector3D(4 * 1 + 2, 9 * 2 + 4, 1 * 3 + 6));
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Triangle3D.IsValid(new Triangle3D(new Vector3D(8, 1, 1), new Vector3D(2, 3, 1), new Vector3D(4, 9, 1))), true);
            Assert.AreEqual(Triangle3D.IsValid(Triangle3D.Invalid), false);
        }
    }
}