using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Tetrahedron3DTests {
        [TestMethod()]
        public void Tetrahedron3DTest() {
            Tetrahedron3D tetrahedron1 = new Tetrahedron3D(new Vector3D(0, 0, 0), new Vector3D(1, 0, 0), new Vector3D(0, 2, 0), new Vector3D(0, 0, 3));
            Tetrahedron3D tetrahedron2 = Matrix3D.Move(2, 4, 6) * Matrix3D.Scale(1, 2, 3) * tetrahedron1;

            Assert.AreEqual((Matrix3D.Rotate(1, 1, 1) * tetrahedron1).Area, 9, 1e-12);

            Assert.AreEqual((Matrix3D.Rotate(1, 1, 1) * tetrahedron1).Volume, 1, 1e-12);
            Assert.AreEqual((Matrix3D.Rotate(1, 2, 3) * tetrahedron2).Volume, 6, 1e-12);
            
            Assert.AreEqual(tetrahedron2.V0, new Vector3D(0 * 1 + 2, 0 * 2 + 4, 0 * 3 + 6));
            Assert.AreEqual(tetrahedron2.V1, new Vector3D(1 * 1 + 2, 0 * 2 + 4, 0 * 3 + 6));
            Assert.AreEqual(tetrahedron2.V2, new Vector3D(0 * 1 + 2, 2 * 2 + 4, 0 * 3 + 6));
            Assert.AreEqual(tetrahedron2.V3, new Vector3D(0 * 1 + 2, 0 * 2 + 4, 3 * 3 + 6));
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Tetrahedron3D.IsValid(new Tetrahedron3D(new Vector3D(0, 0, 0), new Vector3D(1, 0, 0), new Vector3D(0, 2, 0), new Vector3D(0, 0, 3))), true);
            Assert.AreEqual(Tetrahedron3D.IsValid(Tetrahedron3D.Invalid), false);
        }
    }
}