namespace Geometry.Geometry3D {

    /// <summary>直線</summary>
    public class Line3D {

        /// <summary>コンストラクタ</summary>
        public Line3D(Vector3D v, Vector3D direction) {
            this.V = v;
            this.Direction = direction;
        }

        /// <summary>通過点</summary>
        public Vector3D V { get; set; }

        /// <summary>方向</summary>
        public Vector3D Direction { get; set; }

        /// <summary>行列積</summary>
        public static Line3D operator *(Matrix3D matrix, Line3D line) {
            Vector3D v0 = matrix * line.V, v1 = matrix * (line.V + line.Direction);

            return new Line3D(v0, v1 - v0);
        }

        /// <summary>不正な直線</summary>
        public static Line3D Invalid => new(Vector3D.Invalid, Vector3D.Invalid);

        /// <summary>有効な直線であるか判定</summary>
        public static bool IsValid(Line3D line) {
            return Vector3D.IsValid(line.V) && Vector3D.IsValid(line.Direction) && !Vector3D.IsZero(line.Direction);
        }
    }
}
