using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Segment3DTests {
        [TestMethod()]
        public void Segment3DTest() {
            Segment3D segment1 = new(new Vector3D(6, 1, 4), new Vector3D(-1, 2, 6));
            Segment3D segment2 = Matrix3D.Move(2, 4, -1) * Matrix3D.Scale(1, 2, 5) * segment1;

            Assert.AreEqual(Math.Sqrt(7 * 7 + 1 * 1 + 2 * 2), segment1.Length);

            Assert.AreEqual(new Vector3D(6 * 1 + 2, 1 * 2 + 4, 4 * 5 - 1), segment2.V0);
            Assert.AreEqual(new Vector3D(-1 * 1 + 2, 2 * 2 + 4, 6 * 5 - 1), segment2.V1);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Segment3D.IsValid(new Segment3D(new Vector3D(6, 1, 4), new Vector3D(-1, 2, 6))));
            Assert.IsFalse(Segment3D.IsValid(Segment3D.Invalid));
        }
    }
}