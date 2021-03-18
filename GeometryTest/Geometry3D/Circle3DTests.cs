using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Circle3DTests {
        [TestMethod()]
        public void Circle3DTest() {
            Circle3D circle = new Circle3D(new Vector3D(1, 3, 5), new Vector3D(2, 4, 6), 2);

            Assert.AreEqual(circle.Center, new Vector3D(1, 3, 5));
            Assert.AreEqual(circle.Normal, new Vector3D(2, 4, 6).Normal);
            Assert.AreEqual(circle.Radius, 2.0);

            Assert.AreEqual(circle.Area, 4 * Math.PI);
        }

        [TestMethod()]
        public void CircumTest() {
            Vector3D v0 = new Vector3D(3, 9, 1), v1 = new Vector3D(4, 2, 1), v2 = new Vector3D(12, 6, 1);

            Circle3D circle1 = Circle3D.Circum(new Triangle3D(v0, v1, v2));

            Assert.AreEqual(circle1.Center, new Vector3D(7, 6, 1));
            Assert.AreEqual(circle1.Normal, new Vector3D(0, 0, 1));
            Assert.AreEqual(circle1.Radius, 5);

            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 0.5);

            Circle3D circle2 = Circle3D.Circum(new Triangle3D(matrix * v0, matrix * v1, matrix * v2));

            Assert.AreEqual((circle2.Center - matrix * new Vector3D(7, 6, 1)).Norm < 1e-12, true);
            Assert.AreEqual((circle2.Normal - matrix * new Vector3D(0, 0, 1)).Norm < 1e-12, true);
            Assert.AreEqual(circle2.Radius, 5, 1e-12);
        }

        [TestMethod()]
        public void IncircleTest() {
            Vector3D v0 = new Vector3D(2, 1, 1), v1 = new Vector3D(6, 1, 1), v2 = new Vector3D(6, 4, 1);

            Circle3D circle1 = Circle3D.Incircle(new Triangle3D(v0, v1, v2));

            Assert.AreEqual(circle1.Center, new Vector3D(5, 2, 1));
            Assert.AreEqual(circle1.Normal, new Vector3D(0, 0, 1));
            Assert.AreEqual(circle1.Radius, 1);

            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 0.5);

            Circle3D circle2 = Circle3D.Incircle(new Triangle3D(matrix * v0, matrix * v1, matrix * v2));

            Assert.AreEqual((circle2.Center - matrix * new Vector3D(5, 2, 1)).Norm < 1e-12, true);
            Assert.AreEqual((circle2.Normal - matrix * new Vector3D(0, 0, 1)).Norm < 1e-12, true);
            Assert.AreEqual(circle2.Radius, 1, 1e-12);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.AreEqual(Circle3D.IsValid(new Circle3D(new Vector3D(1, 3, 5), new Vector3D(2, 4, 6), 2)), true);
            Assert.AreEqual(Circle3D.IsValid(Circle3D.Invalid), false);
        }
    }
}