using System;

namespace Geometry.Geometry3D {

    /// <summary>3次元ベクトル</summary>
    public struct Vector3D {

        /// <summary>コンストラクタ</summary>
        public Vector3D(double x, double y, double z) {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>X成分</summary>
        public double X { get; set; }

        /// <summary>Y成分</summary>
        public double Y { get; set; }

        /// <summary>Z成分</summary>
        public double Z { get; set; }

        /// <summary>ノルム</summary>
        public readonly double Norm => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>ノルム二乗</summary>
        public readonly double SquareNorm => X * X + Y * Y + Z * Z;

        /// <summary>正規化ベクトル</summary>
        public Vector3D Normal => this / Norm;

        /// <summary>単項プラス</summary>
        public static Vector3D operator +(Vector3D v) {
            return new Vector3D(v.X, v.Y, v.Z);
        }

        /// <summary>単項マイナス</summary>
        public static Vector3D operator -(Vector3D v) {
            return new Vector3D(-v.X, -v.Y, -v.Z);
        }

        /// <summary>ベクトル和</summary>
        public static Vector3D operator +(Vector3D v1, Vector3D v2) {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        /// <summary>ベクトル差</summary>
        public static Vector3D operator -(Vector3D v1, Vector3D v2) {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        /// <summary>ベクトル外積</summary>
        public static Vector3D operator *(Vector3D v1, Vector3D v2) {
            return new Vector3D(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        /// <summary>スカラー倍</summary>
        public static Vector3D operator *(double r, Vector3D v) {
            return new Vector3D(v.X * r, v.Y * r, v.Z * r);
        }

        /// <summary>スカラー倍</summary>
        public static Vector3D operator *(Vector3D v, double r) {
            return r * v;
        }

        /// <summary>スカラー逆数倍</summary>
        public static Vector3D operator /(Vector3D v, double r) {
            return (1 / r) * v;
        }

        /// <summary>行列ベクトル積</summary>
        public static Vector3D operator *(Matrix3D m, Vector3D v) {
            Vector3D ret = new(v.X * m.E11 + v.Y * m.E12 + v.Z * m.E13 + m.E14,
                                        v.X * m.E21 + v.Y * m.E22 + v.Z * m.E23 + m.E24,
                                        v.X * m.E31 + v.Y * m.E32 + v.Z * m.E33 + m.E34);

            double w = v.X * m.E41 + v.Y * m.E42 + v.Z * m.E43 + m.E44;

            return (w == 1) ? (ret) : (ret / w);
        }

        /// <summary>等しいか判定</summary>
        public static bool operator ==(Vector3D v1, Vector3D v2) {
            return (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z);
        }

        /// <summary>異なるか判定</summary>
        public static bool operator !=(Vector3D v1, Vector3D v2) {
            return (v1.X != v2.X) || (v1.Y != v2.Y) || (v1.Z != v2.Z);
        }

        /// <summary>等しいか判定</summary>
        public override readonly bool Equals(object obj) {
            return (!(obj is null)) && obj is Vector3D vector && vector == this;
        }

        /// <summary>ハッシュ値</summary>
        public override readonly int GetHashCode() {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>四元数に型変換</summary>
        public static implicit operator Quaternion(Vector3D v) {
            return new Quaternion(0, v.X, v.Y, v.Z);
        }

        /// <summary>ベクトル間距離</summary>
        public static double Distance(Vector3D v1, Vector3D v2) {
            return (v1 - v2).Norm;
        }

        /// <summary>ベクトル間距離二乗</summary>
        public static double SquareDistance(Vector3D v1, Vector3D v2) {
            return (v1 - v2).SquareNorm;
        }

        /// <summary>内積</summary>
        public static double InnerProduct(Vector3D v1, Vector3D v2) {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>ゼロベクトルか判定</summary>
        public static bool IsZero(Vector3D v) {
            return (v.X == 0) && (v.Y == 0) && (v.Z == 0);
        }

        /// <summary>有効なベクトルか判定</summary>
        public static bool IsValid(Vector3D v) {
            return !double.IsNaN(v.X) && !double.IsInfinity(v.X) && !double.IsNaN(v.Y) && !double.IsInfinity(v.Y) && !double.IsNaN(v.Z) && !double.IsInfinity(v.Z);
        }

        /// <summary>ゼロベクトル</summary>
        public static Vector3D Zero => new(0, 0, 0);

        /// <summary>不正なベクトル</summary>
        public static Vector3D Invalid => new(double.NaN, double.NaN, double.NaN);

        /// <summary>文字列化</summary>
        public override readonly string ToString() {
            return $"{X},{Y},{Z}";
        }
    }
}
