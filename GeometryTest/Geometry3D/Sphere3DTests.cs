﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Sphere3DTests {
        [TestMethod()]
        public void Sphere3DTest() {
            Sphere3D sphere1 = new(new Vector3D(1, 2, 3), 4);
            Sphere3D sphere2 = new(new Vector3D(3, 2, -1), new Vector3D(1, 3, -2), new Vector3D(3, -1, -4), new Vector3D(0, 0, -2));

            Assert.AreEqual(new Vector3D(1, 2, 3), sphere1.Center);
            Assert.AreEqual(4.0, sphere1.Radius);
            Assert.AreEqual(4 * 4 * 4 * Math.PI, sphere1.Area);
            Assert.AreEqual(4.0 / 3.0 * 4 * 4 * 4 * Math.PI, sphere1.Volume);

            Assert.IsTrue((sphere2.Center - new Vector3D(2, 1, -3)).Norm < 1e-12);
            Assert.AreEqual(6, sphere2.Radius * sphere2.Radius, 1e-12);
        }

        [TestMethod()]
        public void ValidTest() {
            Assert.IsTrue(Sphere3D.IsValid(new Sphere3D(new Vector3D(1, 2, 3), 4)));
            Assert.IsFalse(Sphere3D.IsValid(Sphere3D.Invalid));
        }
    }
}