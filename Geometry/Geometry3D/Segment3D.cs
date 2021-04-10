namespace Geometry.Geometry3D {

    /// <summary>線分</summary>
    public class Segment3D {

        /// <summary>コンストラクタ</summary>
        public Segment3D(Vector3D v0, Vector3D v1) {
            this.V0 = v0;
            this.V1 = v1;
        }

        /// <summary>始点</summary>
        public Vector3D V0 { get; set; }

        /// <summary>終点</summary>
        public Vector3D V1 { get; set; }

        /// <summary>長さ</summary>
        public double Length => Vector3D.Distance(V0, V1);

        /// <summary>行列積</summary>
        public static Segment3D operator *(Matrix3D matrix, Segment3D segment) {
            return new Segment3D(matrix * segment.V0, matrix * segment.V1);
        }

        /// <summary>不正な線分</summary>
        public static Segment3D Invalid => new(Vector3D.Invalid, Vector3D.Invalid);

        /// <summary>有効な線分であるか判定</summary>
        public static bool IsValid(Segment3D segment) {
            return Vector3D.IsValid(segment.V0) && Vector3D.IsValid(segment.V1);
        }
    }
}
