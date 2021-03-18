using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Geometry3D.Tests {
    [TestClass()]
    public class Intersect3DTests {
        [TestMethod()]
        public void LineLineTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Line3D line1 = new Line3D(new Vector3D(1, 3, 1), new Vector3D(3, 2, 0));
            Line3D line2 = new Line3D(new Vector3D(6, 1, 1), new Vector3D(-1, 2, 0));

            Vector3D cross = Intersect3D.LineLine(matrix * line1, matrix * line2, 1e-12);

            Assert.AreEqual((cross - matrix * new Vector3D(4, 5, 1)).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void LinePlaneTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new Vector3D(1, 0, 0), v2 = new Vector3D(0, 2, 0), v3 = new Vector3D(0, 0, 3);

            Plane3D plane = new Plane3D(matrix * v1, matrix * v2, matrix * v3);

            Vector3D cross1 = Intersect3D.LinePlane(matrix * new Line3D(Vector3D.Zero, v1), plane);

            Assert.AreEqual((cross1 - matrix * v1).Norm < 1e-12, true);

            Vector3D cross2 = Intersect3D.LinePlane(matrix * new Line3D(Vector3D.Zero, -v1), plane);

            Assert.AreEqual((cross2 - matrix * v1).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void LineTriangleTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new Vector3D(1, 0, 0), v2 = new Vector3D(0, 1, 0), v3 = new Vector3D(0, 0, 1);

            Vector3D v4 = new Vector3D(1, 1, 1) / 3, v5 = new Vector3D(1, -0.1, -0.1), v6 = new Vector3D(-0.1, 1, -0.1), v7 = new Vector3D(-0.1, -0.1, 1);
            Vector3D v8 = new Vector3D(1, -0.1, 0.1), v9 = new Vector3D(1, 0.1, -0.1), v10 = new Vector3D(-0.1, -1, 0.1), v11 = new Vector3D(-0.1, 0.1, -1);

            Triangle3D triangle = new Triangle3D(matrix * v1, matrix * v2, matrix * v3);

            Vector3D cross1 = Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v4), triangle);

            Assert.AreEqual((cross1 - matrix * v4).Norm < 1e-12, true);

            Vector3D cross2 = Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, -v4), triangle);

            Assert.AreEqual((cross2 - matrix * v4).Norm < 1e-12, true);

            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v5), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v6), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v7), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v8), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v9), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v10), triangle)), false);
            Assert.AreEqual(Vector3D.IsValid(Intersect3D.LineTriangle(matrix * new Line3D(Vector3D.Zero, v11), triangle)), false);
        }

        [TestMethod()]
        public void LineCircleTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Scale(1, 2, 3) * Matrix3D.Move(-5, -6, -7);

            Vector3D v1 = new Vector3D(1, 0, 0), v2 = new Vector3D(0, 1, 0), v3 = new Vector3D(0, 0, 1);
            Vector3D v4 = new Vector3D(1, 2, 3) / 6, v5 = new Vector3D(1, -0.1, -0.1);

            Circle3D circle = Circle3D.Circum(new Triangle3D(matrix * v1, matrix * v2, matrix * v3));

            Vector3D cross1 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, v4), circle);

            Assert.AreEqual((cross1 - matrix * v4).Norm < 1e-12, true);

            Vector3D cross2 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, -v4), circle);

            Assert.AreEqual((cross2 - matrix * v4).Norm < 1e-12, true);

            Vector3D cross3 = Intersect3D.LineCircle(matrix * new Line3D(Vector3D.Zero, v5), circle);

            Assert.AreEqual(Vector3D.IsValid(cross3), false);
        }

        [TestMethod()]
        public void LineSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Move(-5, -6, -7);

            Vector3D v0 = new Vector3D(3, 4, 0), v1 = new Vector3D(0, 3, -4);

            Line3D line = matrix * new Line3D(v0, v1 - v0);

            Sphere3D sphere = new Sphere3D(matrix * Vector3D.Zero, 5);

            Vector3D[] cross = Intersect3D.LineSphere(line, sphere);

            Assert.AreEqual((cross[0] - matrix * v0).Norm < 1e-12, true);
            Assert.AreEqual((cross[1] - matrix * v1).Norm < 1e-12, true);
        }

        [TestMethod()]
        public void PlanePlaneTest() {
            Vector3D v1 = new Vector3D(-1, 2, 4), v2 = new Vector3D(1, 2, 4), v3 = new Vector3D(1, -2, -1), v4 = new Vector3D(1, 2, 3);

            Plane3D plane_xy = new Plane3D(new Vector3D(0, 0, 1), Vector3D.Zero);
            Plane3D plane_yz = new Plane3D(new Vector3D(1, 0, 0), Vector3D.Zero);
            Plane3D plane_zx = new Plane3D(new Vector3D(0, 1, 0), Vector3D.Zero);

            Plane3D plane1 = new Plane3D(v1, v2, v3);
            Plane3D plane2 = new Plane3D(v1, v2, v4);

            Assert.AreEqual(Intersect3D.PlanePlane(plane_xy, plane_yz).Direction, new Vector3D(0, 1, 0));
            Assert.AreEqual(Intersect3D.PlanePlane(plane_yz, plane_zx).Direction, new Vector3D(0, 0, 1));
            Assert.AreEqual(Intersect3D.PlanePlane(plane_zx, plane_xy).Direction, new Vector3D(1, 0, 0));

            Assert.AreEqual(Intersect3D.PlanePlane(plane1, plane2).V.X, 0);
            Assert.AreEqual(Intersect3D.PlanePlane(plane1, plane2).Direction, new Vector3D(1, 0, 0));
        }

        [TestMethod()]
        public void PlaneSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4) * Matrix3D.Move(-5, -6, -7);

            Vector3D v0 = matrix * Vector3D.Zero, v1 = matrix * new Vector3D(1, 0, 0), v2 = matrix * new Vector3D(0, 1, 0), v3 = matrix * new Vector3D(0, 0, 1);

            Plane3D plane = new Plane3D(v1, v2, v3);
            Circle3D circle = Circle3D.Circum(new Triangle3D(v1, v2, v3));
            Sphere3D sphere = new Sphere3D(v0, 1);

            Circle3D cross = Intersect3D.PlaneSphere(plane, sphere);

            Assert.AreEqual((circle.Center - cross.Center).Norm < 1e-12, true);
            Assert.AreEqual((circle.Normal - cross.Normal).Norm < 1e-12, true);
            Assert.AreEqual(circle.Radius, cross.Radius, 1e-12);
        }

        [TestMethod()]
        public void SphereSphereTest() {
            Matrix3D matrix = Matrix3D.RotateAxis(new Vector3D(1, 2, 3), 4);

            Vector3D v0 = matrix * new Vector3D(-2, 0, 0), v1 = matrix * new Vector3D(3, 0, 0), v2 = matrix * new Vector3D(-0.2, 0, 0);

            Sphere3D sphere1 = new Sphere3D(v0, 3);
            Sphere3D sphere2 = new Sphere3D(v1, 4);
            Circle3D circle = new Circle3D(v2, matrix * new Vector3D(1, 0, 0), 2.4);

            Circle3D cross = Intersect3D.SphereSphere(sphere1, sphere2);

            Assert.AreEqual((circle.Center - cross.Center).Norm < 1e-12, true);
            Assert.AreEqual((circle.Normal - cross.Normal).Norm < 1e-12, true);
            Assert.AreEqual(circle.Radius, cross.Radius, 1e-12);
        }
    }
}