using System;

namespace Geometry.Geometry3D {

    /// <summary>交差</summary>
    public static class Intersect3D {

        /// <summary>直線間の交点</summary>
        public static Vector3D LineLine(Line3D line1, Line3D line2, double distance_threshold) {
            Vector3D v1 = line1.V, dv1 = line1.Direction.Normal, v2 = line2.V, dv2 = line2.Direction.Normal;

            double d1dv1 = Vector3D.InnerProduct(v1, dv1);
            double d1dv2 = Vector3D.InnerProduct(v1, dv2);
            double d2dv1 = Vector3D.InnerProduct(v2, dv1);
            double d2dv2 = Vector3D.InnerProduct(v2, dv2);
            double dv1dv2 = Vector3D.InnerProduct(dv1, dv2);

            double inn = 1 / (dv1dv2 * dv1dv2 - 1);

            double f1 = d2dv2 - d1dv2;
            double f2 = d1dv1 - d2dv1;

            double t1 = (dv1dv2 * f1 + f2) * inn;
            double t2 = (dv1dv2 * f2 + f1) * inn;

            Vector3D rt1 = v1 + dv1 * t1;
            Vector3D rt2 = v2 + dv2 * t2;

            return Vector3D.Distance(rt1, rt2) < distance_threshold ? (rt1 + rt2) / 2 : Vector3D.Invalid;
        }

        /// <summary>直線-平面間の交点</summary>
        public static Vector3D LinePlane(Line3D line, Plane3D plane) {
            double inn = Vector3D.InnerProduct(line.Direction, plane.Normal);
            double t = -(Vector3D.InnerProduct(line.V, plane.Normal) + plane.D) / inn;

            return line.V + line.Direction * t;
        }

        /// <summary>直線-三角形間の交点</summary>
        public static Vector3D LineTriangle(Line3D line, Triangle3D triangle) {
            Vector3D dir = line.Direction.Normal, eu, ev, pvec, tvec, qvec;
            double det, inv_u, inv_v;

            eu = triangle.V1 - triangle.V0;
            ev = triangle.V2 - triangle.V0;

            pvec = dir * ev;
            det = Vector3D.InnerProduct(eu, pvec);

            if (det > 0) {
                tvec = line.V - triangle.V0;
                inv_u = Vector3D.InnerProduct(tvec, pvec);
                if (inv_u < 0 || inv_u > det) {
                    return Vector3D.Invalid;
                }

                qvec = tvec * eu;
                inv_v = Vector3D.InnerProduct(dir, qvec);
                if (inv_v < 0 || inv_u + inv_v > det) {
                    return Vector3D.Invalid;
                }
            }
            else if (det < 0) {
                tvec = line.V - triangle.V0;
                inv_u = Vector3D.InnerProduct(tvec, pvec);
                if (inv_u > 0 || inv_u < det) {
                    return Vector3D.Invalid;
                }

                qvec = tvec * eu;
                inv_v = Vector3D.InnerProduct(dir, qvec);
                if (inv_v > 0 || inv_u + inv_v < det) {
                    return Vector3D.Invalid;
                }
            }
            else {
                return Vector3D.Invalid;
            }

            double t = Vector3D.InnerProduct(ev, qvec) / det;

            return line.V + dir * t;
        }

        /// <summary>直線-円間の交点</summary>
        public static Vector3D LineCircle(Line3D line, Circle3D circle) {
            Vector3D cross = LinePlane(line, new Plane3D(circle.Normal, circle.Center));

            return Vector3D.SquareDistance(cross, circle.Center) < circle.Radius * circle.Radius ? cross : Vector3D.Invalid;
        }

        /// <summary>直線-球間の交点</summary>
        public static Vector3D[] LineSphere(Line3D line, Sphere3D sphere) {
            Vector3D otoc;
            double b, c, v;

            otoc = line.V - sphere.Center;

            b = 2 * Vector3D.InnerProduct(line.Direction.Normal, otoc);
            c = otoc.SquareNorm - sphere.Radius * sphere.Radius;
            v = b * b - 4 * c;

            if (!(v >= 0)) {
                return Array.Empty<Vector3D>();
            }

            if (v == 0) {
                double t = -0.5 * b;
                return new Vector3D[] { line.V + t * line.Direction.Normal };
            }
            else {
                double t1 = -0.5 * (b + Math.Sqrt(v)), t2 = -0.5 * (b - Math.Sqrt(v));

                return new Vector3D[] { line.V + t1 * line.Direction.Normal, line.V + t2 * line.Direction.Normal };
            }
        }

        /// <summary>平面間の交線</summary>
        public static Line3D PlanePlane(Plane3D plane1, Plane3D plane2) {
            Vector3D normal1 = plane1.Normal, normal2 = plane1.Normal, line_org, line_dir;
            double inv;

            line_dir = (plane1.Normal * plane2.Normal).Normal;

            if (line_dir.X != 0) {
                inv = 1 / line_dir.X;

                line_org = new Vector3D(0,
                                        (plane1.D * normal2.Z - plane2.D * normal1.Z) * inv,
                                        (plane2.D * normal1.Y - plane1.D * normal2.Y) * inv);

                return new Line3D(line_org, line_dir);
            }

            if (line_dir.Y != 0) {
                inv = 1 / line_dir.Y;

                line_org = new Vector3D((plane2.D * normal1.Z - plane1.D * normal2.Z) * inv,
                                        0,
                                        (plane1.D * normal2.X - plane2.D * normal1.X) * inv);

                return new Line3D(line_org, line_dir);
            }

            if (line_dir.Z != 0) {
                inv = 1 / line_dir.Z;

                line_org = new Vector3D((plane1.D * normal2.Y - plane2.D * normal1.Y) * inv,
                                        (plane2.D * normal1.X - plane1.D * normal2.X) * inv,
                                        0);

                return new Line3D(line_org, line_dir);
            }

            return Line3D.Invalid;
        }

        /// <summary>平面-球間の交円</summary>
        public static Circle3D PlaneSphere(Plane3D plane, Sphere3D sphere) {
            double t = -(Vector3D.InnerProduct(sphere.Center, plane.Normal) + plane.D);

            if (Math.Abs(t) > sphere.Radius) {
                return Circle3D.Invalid;
            }

            return new Circle3D(sphere.Center + plane.Normal * t, plane.Normal, Math.Sqrt(sphere.Radius * sphere.Radius - t * t));
        }

        /// <summary>球間の交円</summary>
        public static Circle3D SphereSphere(Sphere3D sphere1, Sphere3D sphere2) {
            double r0 = sphere1.Radius, r1 = sphere2.Radius, r01, rm01, rp01, inv_d, r0_sq, x, h;
            Vector3D c0 = sphere1.Center, c1 = sphere2.Center, c01, center;

            c01 = c1 - c0;
            r01 = c01.SquareNorm;
            rm01 = r0 - r1;
            rp01 = r0 + r1;

            if (((rp01 * rp01) <= r01) || ((rm01 * rm01) >= r01)) {
                return Circle3D.Invalid;
            }

            inv_d = 1 / Math.Sqrt(r01);
            r0_sq = r0 * r0;
            x = (r01 + r0_sq - r1 * r1) * inv_d * 0.5;
            h = Math.Sqrt(r0_sq - x * x);

            center = c0 + c01 * x * inv_d;

            return new Circle3D(center, c01, h);
        }
    }
}
