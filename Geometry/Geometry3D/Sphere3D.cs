using System;

namespace Geometry.Geometry3D {

    /// <summary>球</summary>
    public class Sphere3D {

        /// <summary>コンストラクタ</summary>
        public Sphere3D(Vector3D center, double radius) {
            this.Center = center;
            this.Radius = radius;
        }

        /// <summary>コンストラクタ</summary>
        public Sphere3D(Vector3D vector1, Vector3D vector2, Vector3D vector3, Vector3D vector4) {
            double x1 = vector1.X, y1 = vector1.Y, z1 = vector1.Z, t1 = vector1.SquareNorm;
            double x2 = vector2.X, y2 = vector2.Y, z2 = vector2.Z, t2 = vector2.SquareNorm;
            double x3 = vector3.X, y3 = vector3.Y, z3 = vector3.Z, t3 = vector3.SquareNorm;
            double x4 = vector4.X, y4 = vector4.Y, z4 = vector4.Z, t4 = vector4.SquareNorm;

            double a_det = Determinant(t1, y1, z1, t2, y2, z2, t3, y3, z3, t4, y4, z4);
            double b_det = Determinant(x1, t1, z1, x2, t2, z2, x3, t3, z3, x4, t4, z4);
            double c_det = Determinant(x1, y1, t1, x2, y2, t2, x3, y3, t3, x4, y4, t4);
            double d_det = Determinant(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4);

            this.Center = new Vector3D(a_det, b_det, c_det) / (2 * d_det);
            this.Radius = Vector3D.Distance(vector1, this.Center);
        }

        /// <summary>中心</summary>
        public Vector3D Center { get; set; }

        /// <summary>半径</summary>
        public double Radius { get; set; }

        /// <summary>面積</summary>
        public double Area => 4 * Radius * Radius * Math.PI;

        /// <summary>体積</summary>
        public double Volume => 4.0 / 3.0 * Radius * Radius * Radius * Math.PI;

        /// <summary>不正な球</summary>
        public static Sphere3D Invalid => new Sphere3D(Vector3D.Invalid, double.NaN);

        /// <summary>有効な球であるか判定</summary>
        public static bool IsValid(Sphere3D sphere) {
            return Vector3D.IsValid(sphere.Center) && !double.IsNaN(sphere.Radius) && !double.IsInfinity(sphere.Radius);
        }

        /// <summary>行列式</summary>
        private static double Determinant(double e11, double e12, double e13, double e21, double e22, double e23, double e31, double e32, double e33, double e41, double e42, double e43) {
            return e11 * (e32 * e43 + e22 * (e33 - e43) - e33 * e42 - e23 * (e32 - e42)) - e21 * (e32 * e43 - e33 * e42)
                 - e12 * (e31 * e43 + e21 * (e33 - e43) - e33 * e41 - e23 * (e31 - e41)) + e22 * (e31 * e43 - e33 * e41)
                 + e13 * (e31 * e42 + e21 * (e32 - e42) - e32 * e41 - e22 * (e31 - e41)) - e23 * (e31 * e42 - e32 * e41);
        }
    }
}
