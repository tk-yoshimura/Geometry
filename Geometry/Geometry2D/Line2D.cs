namespace Geometry.Geometry2D {

    /// <summary>直線</summary>
    public class Line2D {

        /// <summary>コンストラクタ</summary>
        public Line2D(Vector2D v, Vector2D direction) {
            this.V = v;
            this.Direction = direction;
        }

        /// <summary>通過点</summary>
        public Vector2D V { get; set; }

        /// <summary>方向</summary>
        public Vector2D Direction { get; set; }

        /// <summary>行列積</summary>
        public static Line2D operator *(Matrix2D matrix, Line2D line) {
            Vector2D v0 = matrix * line.V, v1 = matrix * (line.V + line.Direction);

            return new Line2D(v0, v1 - v0);
        }

        /// <summary>不正な直線</summary>
        public static Line2D Invalid => new(Vector2D.Invalid, Vector2D.Invalid);

        /// <summary>有効な直線であるか判定</summary>
        public static bool IsValid(Line2D line) {
            return Vector2D.IsValid(line.V) && Vector2D.IsValid(line.Direction) && !Vector2D.IsZero(line.Direction);
        }
    }
}
