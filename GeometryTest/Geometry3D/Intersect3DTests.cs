﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Intersect3DTests {
        [TestMethod()]
        public void LineLineTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Line3D line1 = new(new Vector3D(1, 3, 1), new Vector3D(3, 2, 0));
            Line3D line2 = new(new Vector3D(6, 1, 1), new Vector3D(-1, 2, 0));

            Vector3D cross = Intersect3D.LineLine(matrix * line1, matrix * line2, 1e-12);

            Assert.IsTrue((cross - matrix * new Vector3D(4, 5, 1)).Norm < 1e-12);
        }

        [TestMethod()]
        public void LinePlaneTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new(1, 0, 0), v2 = new(0, 2, 0), v3 = new(0, 0, 3);

            Plane3D plane = new(matrix * v1, matrix * v2, matrix * v3);

            Vector3D cross1 = Intersect3D.LinePlane(matrix * new Line3D(Vector3D.Zero, v1), plane);

            Assert.IsTrue((cross1 - matrix * v1).Norm < 1e-12);

            Vector3D cross2 = Intersect3D.LinePlane(matrix * new Line3D(Vector3D.Zero, -v1), plane);

            Assert.IsTrue((cross2 - matrix * v1).Norm < 1e-12);
        }

        [TestMethod()]
        public void LineTriangleTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new(1, 0, 0), v2 = new(0, 1, 0), v3 = new(0, 0, 1);

            Vector3D v4 = new Vector3D(1, 1, 1) / 3, v5 = new(1, -0.1, -0.1), v6 = new(-0.1, 1, -0.1), v7 = new(-0.1, -0.1, 1);
            Vector3D v8 = new(1, -0.1, 0.1), v9 = new(1, 0.1, -0.1), v10 = new(-0.1, -1, 0.1), v11 = new(-0.1, 0.1, -1);

            Triangle3D triangle = new(matrix * v1, matrix * v2, matrix * v3);

            Vector3D cross1 = Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v4), triangle);

            Assert.IsTrue((cross1 - matrix * v4).Norm < 1e-12);

            Vector3D cross2 = Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, -v4), triangle);

            Assert.IsTrue((cross2 - matrix * v4).Norm < 1e-12);

            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v5), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v6), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v7), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v8), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v9), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v10), triangle)));
            Assert.IsFalse(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v11), triangle)));
        }

        [TestMethod()]
        public void LineCircleTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new(1, 0, 0), v2 = new(0, 1, 0), v3 = new(0, 0, 1);
            Vector3D v4 = new Vector3D(1, 2, 3) / 6, v5 = new(1, -0.1, -0.1);

            Circle3D circle = Circle3D.Circum(new Triangle3D(matrix * v1, matrix * v2, matrix * v3));

            Vector3D cross1 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, v4), circle);

            Assert.IsTrue((cross1 - matrix * v4).Norm < 1e-12);

            Vector3D cross2 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, -v4), circle);

            Assert.IsTrue((cross2 - matrix * v4).Norm < 1e-12);

            Vector3D cross3 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, v5), circle);

            Assert.IsFalse(Vector3D.IsValid(cross3));
        }

        [TestMethod()]
        public void LineSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Move(-5, -6, -7);

            Vector3D v0 = new(3, 4, 0), v1 = new(0, 3, -4);

            Line3D line = matrix * new Line3D(v0, v1 - v0);

            Sphere3D sphere = new(matrix * Vector3D.Zero, 5);

            Vector3D[] cross = Intersect3D.LineSphere(line, sphere);

            Assert.IsTrue((cross[0] - matrix * v0).Norm < 1e-12);
            Assert.IsTrue((cross[1] - matrix * v1).Norm < 1e-12);
        }

        [TestMethod()]
        public void PlanePlaneTest() {
            Vector3D v1 = new(-1, 2, 4), v2 = new(1, 2, 4), v3 = new(1, -2, -1), v4 = new(1, 2, 3);

            Plane3D plane_xy = new(new Vector3D(0, 0, 1), Vector3D.Zero);
            Plane3D plane_yz = new(new Vector3D(1, 0, 0), Vector3D.Zero);
            Plane3D plane_zx = new(new Vector3D(0, 1, 0), Vector3D.Zero);

            Plane3D plane1 = new(v1, v2, v3);
            Plane3D plane2 = new(v1, v2, v4);

            Assert.AreEqual(new Vector3D(0, 1, 0), Intersect3D.PlanePlane(plane_xy, plane_yz).Direction);
            Assert.AreEqual(new Vector3D(0, 0, 1), Intersect3D.PlanePlane(plane_yz, plane_zx).Direction);
            Assert.AreEqual(new Vector3D(1, 0, 0), Intersect3D.PlanePlane(plane_zx, plane_xy).Direction);

            Assert.AreEqual(0, Intersect3D.PlanePlane(plane1, plane2).V.X);
            Assert.AreEqual(new Vector3D(1, 0, 0), Intersect3D.PlanePlane(plane1, plane2).Direction);
        }

        [TestMethod()]
        public void PlaneSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Move(-5, -6, -7);

            Vector3D v0 = matrix * Vector3D.Zero, v1 = matrix * new Vector3D(1, 0, 0), v2 = matrix * new Vector3D(0, 1, 0), v3 = matrix * new Vector3D(0, 0, 1);

            Plane3D plane = new(v1, v2, v3);
            Circle3D circle = Circle3D.Circum(new Triangle3D(v1, v2, v3));
            Sphere3D sphere = new(v0, 1);

            Circle3D cross = Intersect3D.PlaneSphere(plane, sphere);

            Assert.IsTrue((circle.Center - cross.Center).Norm < 1e-12);
            Assert.IsTrue((circle.Normal - cross.Normal).Norm < 1e-12);
            Assert.AreEqual(circle.Radius, cross.Radius, 1e-12);
        }

        [TestMethod()]
        public void SphereSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4);

            Vector3D v0 = matrix * new Vector3D(-2, 0, 0), v1 = matrix * new Vector3D(3, 0, 0), v2 = matrix * new Vector3D(-0.2, 0, 0);

            Sphere3D sphere1 = new(v0, 3);
            Sphere3D sphere2 = new(v1, 4);
            Circle3D circle = new(v2, matrix * new Vector3D(1, 0, 0), 2.4);

            Circle3D cross = Intersect3D.SphereSphere(sphere1, sphere2);

            Assert.IsTrue((circle.Center - cross.Center).Norm < 1e-12);
            Assert.IsTrue((circle.Normal - cross.Normal).Norm < 1e-12);
            Assert.AreEqual(circle.Radius, cross.Radius, 1e-12);
        }
    }
}