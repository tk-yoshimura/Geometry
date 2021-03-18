namespace Geometry.Geometry3D {

    /// <summary>平面</summary>
    /// <remarks>方程式 : ax + by + cz + d = 0</remarks>
    public class Plane3D {
        Vector3D normal;

        /// <summary>コンストラクタ</summary>
        public Plane3D(Vector3D normal, double d) {
            this.Normal = normal;
            this.D = d;
        }

        /// <summary>コンストラクタ</summary>
        public Plane3D(Vector3D normal, Vector3D v) {
            this.Normal = normal;
            this.D = -(A * v.X + B * v.Y + C * v.Z);
        }

        /// <summary>コンストラクタ</summary>
        public Plane3D(Vector3D v0, Vector3D v1, Vector3D v2) {
            this.Normal = (v1 - v0) * (v2 - v0);
            this.D = -(A * v0.X + B * v0.Y + C * v0.Z);
        }

        /// <summary>法線ベクトル</summary>
        public Vector3D Normal {
            get {
                return normal;
            }
            set {
                normal = value.Normal;
            }
        }

        /// <summary>A</summary>
        public double A => Normal.X;

        /// <summary>B</summary>
        public double B => Normal.Y;

        /// <summary>C</summary>
        public double C => Normal.Z;

        /// <summary>D</summary>
        public double D { get; set; }

        /// <summary>不正な平面</summary>
        public static Plane3D Invalid => new Plane3D(Vector3D.Invalid, double.NaN);

        /// <summary>有効な平面であるか判定</summary>
        public static bool IsValid(Plane3D plane) {
            return Vector3D.IsValid(plane.Normal) && !Vector3D.IsZero(plane.Normal) && !double.IsNaN(plane.D) && !double.IsInfinity(plane.D);
        }
    }
}
