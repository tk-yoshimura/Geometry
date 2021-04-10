﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Circle3DTests {
        [TestMethod()]
        public void Circle3DTest() {
            Circle3D circle = new(new Vector3D(1, 3, 5), new Vector3D(2, 4, 6), 2);

            Assert.AreEqual(new Vector3D(1, 3, 5), circle.Center);
            Assert.AreEqual(new Vector3D(2, 4, 6).Normal, circle.Normal);
            Assert.AreEqual(2.0, circle.Radius);

            Assert.AreEqual(4 * Math.PI, circle.Area);
        }

        [TestMethod()]
        public void CircumTest() {
            Vector3D v0 = new(3, 9, 1), v1 = new(4, 2, 1), v2 = new(12, 6, 1);

            Circle3D circle1 = Circle3D.Circum(new Triangle3D(v0, v1, v2));

            Assert.AreEqual(new Vector3D(7, 6, 1), circle1.Center);
            Assert.AreEqual(new Vector3D(0, 0, 1), circle1.Normal);
            Assert.AreEqual(5, circle1.Radius);

            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 0.5);

            Circle3D circle2 = Circle3D.Circum(new Triangle3D(matrix * v0, matrix * v1, matrix * v2));

            Assert.IsTrue((circle2.Center - matrix * new Vector3D(7, 6, 1)).Norm < 1e-12);
            Assert.IsTrue((circle2.Normal - matrix * new Vector3D(0, 0, 1)).Norm < 1e-12);
            Assert.AreEqual(5, circle2.Radius, 1e-12);
        }

        [TestMethod()]
        public void IncircleTest() {
            Vector3D v0 = new(2, 1, 1), v1 = new(6, 1, 1), v2 = new(6, 4, 1);

            Circle3D circle1 = Circle3D.Incircle(new Triangle3D(v0, v1, v2));

            Assert.AreEqual(new Vector3D(5, 2, 1), circle1.Center);
            Assert.AreEqual(new Vector3D(0, 0, 1), circle1.Normal);
            Assert.AreEqual(1, circle1.Radius);

            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 0.5);

            Circle3D circle2 = Circle3D.Incircle(new Triangle3D(matrix * v0, matrix * v1, matrix * v2));

            Assert.IsTrue((circle2.Center - matrix * new Vector3D(5, 2, 1)).Norm < 1e-12);
            Assert.IsTrue((circle2.Normal - matrix * new Vector3D(0, 0, 1)).Norm < 1e-12);
            Assert.AreEqual(1, circle2.Radius, 1e-12);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Circle3D.IsValid(new Circle3D(new Vector3D(1, 3, 5), new Vector3D(2, 4, 6), 2)));
            Assert.IsFalse(Circle3D.IsValid(Circle3D.Invalid));
        }
    }
}