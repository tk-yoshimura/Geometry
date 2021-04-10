using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Tetrahedron3DTests {
        [TestMethod()]
        public void Tetrahedron3DTest() {
            Tetrahedron3D tetrahedron1 = new(new Vector3D(0, 0, 0), new Vector3D(1, 0, 0), new Vector3D(0, 2, 0), new Vector3D(0, 0, 3));
            Tetrahedron3D tetrahedron2 = Matrix3D.Move(2, 4, 6) * Matrix3D.Scale(1, 2, 3) * tetrahedron1;

            Assert.AreEqual(9, (Matrix3D.Rotate(1, 1, 1) * tetrahedron1).Area, 1e-12);

            Assert.AreEqual(1, (Matrix3D.Rotate(1, 1, 1) * tetrahedron1).Volume, 1e-12);
            Assert.AreEqual(6, (Matrix3D.Rotate(1, 2, 3) * tetrahedron2).Volume, 1e-12);

            Assert.AreEqual(new Vector3D(0 * 1 + 2, 0 * 2 + 4, 0 * 3 + 6), tetrahedron2.V0);
            Assert.AreEqual(new Vector3D(1 * 1 + 2, 0 * 2 + 4, 0 * 3 + 6), tetrahedron2.V1);
            Assert.AreEqual(new Vector3D(0 * 1 + 2, 2 * 2 + 4, 0 * 3 + 6), tetrahedron2.V2);
            Assert.AreEqual(new Vector3D(0 * 1 + 2, 0 * 2 + 4, 3 * 3 + 6), tetrahedron2.V3);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Tetrahedron3D.IsValid(new Tetrahedron3D(new Vector3D(0, 0, 0), new Vector3D(1, 0, 0), new Vector3D(0, 2, 0), new Vector3D(0, 0, 3))));
            Assert.IsFalse(Tetrahedron3D.IsValid(Tetrahedron3D.Invalid));
        }
    }
}