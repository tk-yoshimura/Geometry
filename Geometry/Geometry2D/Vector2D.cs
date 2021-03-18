using System;

namespace Geometry.Geometry2D {

    /// <summary>2次元ベクトル</summary>
    public struct Vector2D {

        /// <summary>コンストラクタ</summary>
        public Vector2D(double x, double y) {
            this.X = x;
            this.Y = y;
        }

        /// <summary>X成分</summary>
        public double X { get; set; }

        /// <summary>Y成分</summary>
        public double Y { get; set; }

        /// <summary>ノルム</summary>
        public double Norm => Math.Sqrt(X * X + Y * Y);

        /// <summary>ノルム二乗</summary>
        public double SquareNorm => X * X + Y * Y;

        /// <summary>正規化ベクトル</summary>
        public Vector2D Normal => this / Norm;

        /// <summary>単項プラス</summary>
        public static Vector2D operator +(Vector2D v) {
            return new Vector2D(v.X, v.Y);
        }

        /// <summary>単項マイナス</summary>
        public static Vector2D operator -(Vector2D v) {
            return new Vector2D(-v.X, -v.Y);
        }

        /// <summary>ベクトル和</summary>
        public static Vector2D operator +(Vector2D v1, Vector2D v2) {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>ベクトル差</summary>
        public static Vector2D operator -(Vector2D v1, Vector2D v2) {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>スカラー倍</summary>
        public static Vector2D operator *(double r, Vector2D v) {
            return new Vector2D(v.X * r, v.Y * r);
        }

        /// <summary>スカラー倍</summary>
        public static Vector2D operator *(Vector2D v, double r) {
            return r * v;
        }

        /// <summary>行列ベクトル積</summary>
        public static Vector2D operator *(Matrix2D m, Vector2D v) {
            Vector2D ret = new Vector2D(v.X * m.E11 + v.Y * m.E12 + m.E13,
                                        v.X * m.E21 + v.Y * m.E22 + m.E23);

            double w = v.X * m.E31 + v.Y * m.E32 + m.E33;

            return (w == 1) ? (ret) : (ret / w);
        }

        /// <summary>スカラー逆数倍</summary>
        public static Vector2D operator /(Vector2D v, double r) {
            return new Vector2D(v.X / r, v.Y / r);
        }

        /// <summary>等しいか判定</summary>
        public static bool operator ==(Vector2D v1, Vector2D v2) {
            return (v1.X == v2.X) && (v1.Y == v2.Y);
        }

        /// <summary>異なるか判定</summary>
        public static bool operator !=(Vector2D v1, Vector2D v2) {
            return (v1.X != v2.X) || (v1.Y != v2.Y);
        }

        /// <summary>等しいか判定</summary>
        public override bool Equals(object obj) {
            return obj is Vector2D ? (Vector2D)obj == this : false;
        }

        /// <summary>ハッシュ値</summary>
        public override int GetHashCode() {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>ベクトル間距離</summary>
        public static double Distance(Vector2D v1, Vector2D v2) {
            return (v1 - v2).Norm;
        }

        /// <summary>ベクトル間距離二乗</summary>
        public static double SquareDistance(Vector2D v1, Vector2D v2) {
            return (v1 - v2).SquareNorm;
        }

        /// <summary>内積</summary>
        public static double InnerProduct(Vector2D v1, Vector2D v2) {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        /// <summary>ゼロベクトルか判定</summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsZero(Vector2D v) {
            return (v.X == 0) && (v.Y == 0);
        }

        /// <summary>有効なベクトルか判定</summary>
        public static bool IsValid(Vector2D v) {
            return !double.IsNaN(v.X) && !double.IsInfinity(v.X) && !double.IsNaN(v.Y) && !double.IsInfinity(v.Y);
        }

        /// <summary>ゼロベクトル</summary>
        public static Vector2D Zero => new Vector2D(0, 0);

        /// <summary>不正なベクトル</summary>
        public static Vector2D Invalid => new Vector2D(double.NaN, double.NaN);

        /// <summary>文字列化</summary>
        public override string ToString() {
            return $"{X},{Y}";
        }
    }
}
