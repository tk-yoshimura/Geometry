namespace Geometry.Geometry2D {

    /// <summary>線分</summary>
    public class Segment2D {

        /// <summary>コンストラクタ</summary>
        public Segment2D(Vector2D v0, Vector2D v1) {
            this.V0 = v0;
            this.V1 = v1;
        }

        /// <summary>始点</summary>
        public Vector2D V0 { get; set; }

        /// <summary>終点</summary>
        public Vector2D V1 { get; set; }

        /// <summary>長さ</summary>
        public double Length => Vector2D.Distance(V0, V1);

        /// <summary>行列積</summary>
        public static Segment2D operator *(Matrix2D matrix, Segment2D segment) {
            return new Segment2D(matrix * segment.V0, matrix * segment.V1);
        }

        /// <summary>不正な線分</summary>
        public static Segment2D Invalid => new(Vector2D.Invalid, Vector2D.Invalid);

        /// <summary>有効な線分であるか判定</summary>
        public static bool IsValid(Segment2D segment) {
            return Vector2D.IsValid(segment.V0) && Vector2D.IsValid(segment.V1);
        }
    }
}
