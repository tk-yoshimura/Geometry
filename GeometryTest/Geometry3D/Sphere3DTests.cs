using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Sphere3DTests {
        [TestMethod()]
        public void Sphere3DTest() {
            Sphere3D sphere1 = new Sphere3D(new Vector3D(1, 2, 3), 4);
            Sphere3D sphere2 = new Sphere3D(new Vector3D(3, 2, -1), new Vector3D(1, 3, -2), new Vector3D(3, -1, -4), new Vector3D(0, 0, -2));

            Assert.AreEqual(sphere1.Center, new Vector3D(1, 2, 3));
            Assert.AreEqual(sphere1.Radius, 4.0);
            Assert.AreEqual(sphere1.Area, 4 * 4 * 4 * Math.PI);
            Assert.AreEqual(sphere1.Volume, 4.0 / 3.0 * 4 * 4 * 4 * Math.PI);

            Assert.AreEqual((sphere2.Center - new Vector3D(2, 1, -3)).Norm < 1e-12, true);
            Assert.AreEqual(sphere2.Radius * sphere2.Radius, 6, 1e-12);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Sphere3D.IsValid(new Sphere3D(new Vector3D(1, 2, 3), 4)), true);
            Assert.AreEqual(Sphere3D.IsValid(Sphere3D.Invalid), false);
        }
    }
}