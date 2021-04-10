using System;

namespace Geometry.Geometry2D {

    /// <summary>三角形</summary>
    public class Triangle2D {

        /// <summary>コンストラクタ</summary>
        public Triangle2D(Vector2D v0, Vector2D v1, Vector2D v2) {
            this.V0 = v0;
            this.V1 = v1;
            this.V2 = v2;
        }

        /// <summary>構成点0</summary>
        public Vector2D V0 { get; set; }

        /// <summary>構成点1</summary>
        public Vector2D V1 { get; set; }

        /// <summary>構成点2</summary>
        public Vector2D V2 { get; set; }

        /// <summary>面積</summary>
        public double Area {
            get {
                Vector2D a = V1 - V0, b = V2 - V0;
                double inner_product_ab = Vector2D.InnerProduct(a, b);

                return Math.Sqrt(a.SquareNorm * b.SquareNorm - inner_product_ab * inner_product_ab) / 2;
            }
        }

        /// <summary>行列積</summary>
        public static Triangle2D operator *(Matrix2D matrix, Triangle2D triangle) {
            return new Triangle2D(matrix * triangle.V0, matrix * triangle.V1, matrix * triangle.V2);
        }

        /// <summary>不正な三角形</summary>
        public static Triangle2D Invalid => new(Vector2D.Invalid, Vector2D.Invalid, Vector2D.Invalid);

        /// <summary>有効な三角形であるか判定</summary>
        public static bool IsValid(Triangle2D triangle) {
            return Vector2D.IsValid(triangle.V0) && Vector2D.IsValid(triangle.V1) && Vector2D.IsValid(triangle.V2);
        }
    }
}
