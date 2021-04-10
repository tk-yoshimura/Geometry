using System;

namespace Geometry.Geometry3D {

    /// <summary>円</summary>
    public class Circle3D {
        Vector3D normal;

        /// <summary>コンストラクタ</summary>
        public Circle3D(Vector3D center, Vector3D normal, double radius) {
            this.Center = center;
            this.Normal = normal;
            this.Radius = radius;
        }

        /// <summary>中心</summary>
        public Vector3D Center { get; set; }

        /// <summary>法線</summary>
        public Vector3D Normal {
            get {
                return normal;
            }
            set {
                normal = value.Normal;
            }
        }

        /// <summary>半径</summary>
        public double Radius { get; set; }

        /// <summary>面積</summary>
        public double Area => Radius * Radius * Math.PI;

        /// <summary>外接円</summary>
        public static Circle3D Circum(Triangle3D triangle) {
            Vector3D a = triangle.V0 - triangle.V1, b = triangle.V1 - triangle.V2, c = triangle.V2 - triangle.V0;

            double a_sqnorm = a.SquareNorm, b_sqnorm = b.SquareNorm, c_sqnorm = c.SquareNorm;
            double a_norm = Math.Sqrt(a_sqnorm), b_norm = Math.Sqrt(b_sqnorm), c_norm = Math.Sqrt(c_sqnorm);

            double ra = a_sqnorm * (b_sqnorm + c_sqnorm - a_sqnorm);
            double rb = b_sqnorm * (c_sqnorm + a_sqnorm - b_sqnorm);
            double rc = c_sqnorm * (a_sqnorm + b_sqnorm - c_sqnorm);

            Vector3D center = (ra * triangle.V2 + rb * triangle.V0 + rc * triangle.V1) / (ra + rb + rc);
            Vector3D normal = -a * c;
            double radius = (a_norm * b_norm * c_norm) / Math.Sqrt((a_norm + b_norm + c_norm) * (-a_norm + b_norm + c_norm) * (a_norm - b_norm + c_norm) * (a_norm + b_norm - c_norm));

            return new Circle3D(center, normal, radius);
        }

        /// <summary>内接円</summary>
        public static Circle3D Incircle(Triangle3D triangle) {
            Vector3D a = triangle.V0 - triangle.V1, b = triangle.V1 - triangle.V2, c = triangle.V2 - triangle.V0;

            double a_norm = a.Norm, b_norm = b.Norm, c_norm = c.Norm, s = triangle.Area, sum_norm = a_norm + b_norm + c_norm;

            Vector3D center = (a_norm * triangle.V2 + b_norm * triangle.V0 + c_norm * triangle.V1) / sum_norm;
            Vector3D normal = -a * c;
            double radius = 2 * s / sum_norm;

            return new Circle3D(center, normal, radius);
        }

        /// <summary>不正な円</summary>
        public static Circle3D Invalid => new(Vector3D.Invalid, Vector3D.Invalid, double.NaN);

        /// <summary>有効な円であるか判定</summary>
        public static bool IsValid(Circle3D circle) {
            return Vector3D.IsValid(circle.Center) && Vector3D.IsValid(circle.Normal) && !double.IsNaN(circle.Radius) && !double.IsInfinity(circle.Radius);
        }
    }
}
