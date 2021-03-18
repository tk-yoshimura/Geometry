using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Plane3DTests {
        [TestMethod()]
        public void Plane3DTest() {
            Plane3D plane1 = new Plane3D(new Vector3D(1, 2, 3), 4);
            Plane3D plane2 = new Plane3D(new Vector3D(1, 0, 0), new Vector3D(0, 1, 0), new Vector3D(0, 0, 1));

            Vector3D normal1 = new Vector3D(1, 2, 3).Normal;
            Vector3D normal2 = new Vector3D(1, 1, 1).Normal;

            Assert.AreEqual(plane1.Normal, normal1);
            Assert.AreEqual(plane1.A, normal1.X);
            Assert.AreEqual(plane1.B, normal1.Y);
            Assert.AreEqual(plane1.C, normal1.Z);
            Assert.AreEqual(plane1.D, 4);

            Assert.AreEqual(plane2.Normal, normal2);
            Assert.AreEqual(plane2.D, -normal2.X);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Plane3D.IsValid(new Plane3D(new Vector3D(1, 0, 0), new Vector3D(0, 1, 0), new Vector3D(0, 0, 1))), true);
            Assert.AreEqual(Plane3D.IsValid(Plane3D.Invalid), false);
        }
    }
}