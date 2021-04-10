using System;

namespace Geometry.Geometry3D {

    /// <summary>四元数</summary>
    public struct Quaternion {

        /// <summary>コンストラクタ</summary>
        public Quaternion(double r, double i, double j, double k) {
            this.R = r;
            this.I = i;
            this.J = j;
            this.K = k;
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="v">虚数成分に展開するベクトル</param>
        public Quaternion(Vector3D v) {
            this.R = 0;
            this.I = v.X;
            this.J = v.Y;
            this.K = v.Z;
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="axis">回転軸</param>
        /// <param name="theta">回転量</param>
        public Quaternion(Vector3D axis, double theta) {
            axis = axis.Normal;
            double c = Math.Cos(theta * 0.5), s = Math.Sin(theta * 0.5);
            this = new Quaternion(c, s * axis.X, s * axis.Y, s * axis.Z).Unit;
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="v1">始点ベクトル</param>
        /// <param name="v2">終点ベクトル</param>
        public Quaternion(Vector3D v1, Vector3D v2) {
            if (v1 != v2) {
                double v1_norm = v1.Norm, v2_norm = v2.Norm;
                this = new Quaternion(v1 * v2, Math.Acos(Vector3D.InnerProduct(v1, v2) / (v1_norm * v2_norm))) * Math.Sqrt(v2_norm / v1_norm);
            }
            else {
                this = Identity;
            }
        }

        /// <summary>実数成分</summary>
        public double R { get; set; }

        /// <summary>虚数I成分</summary>
        public double I { get; set; }

        /// <summary>虚数J成分</summary>
        public double J { get; set; }

        /// <summary>虚数K成分</summary>
        public double K { get; set; }

        /// <summary>ノルム</summary>
        public double Norm => Math.Sqrt(R * R + I * I + J * J + K * K);

        /// <summary>ノルム2乗</summary>
        public double SquareNorm => R * R + I * I + J * J + K * K;

        /// <summary>単位四元数</summary>
        public Quaternion Unit => this / Norm;

        /// <summary>共役四元数</summary>
        public Quaternion Conjugate => new(R, -I, -J, -K);

        /// <summary>逆数</summary>
        public Quaternion Inverse => Conjugate / SquareNorm;

        /// <summary>単項プラス</summary>
        public static Quaternion operator +(Quaternion q) {
            return new Quaternion(q.R, q.I, q.J, q.K);
        }

        /// <summary>単項マイナス</summary>
        public static Quaternion operator -(Quaternion q) {
            return new Quaternion(-q.R, -q.I, -q.J, -q.K);
        }

        /// <summary>四元数和</summary>
        public static Quaternion operator +(Quaternion q1, Quaternion q2) {
            return new Quaternion(q1.R + q2.R, q1.I + q2.I, q1.J + q2.J, q1.K + q2.K);
        }

        /// <summary>四元数差</summary>
        public static Quaternion operator -(Quaternion q1, Quaternion q2) {
            return new Quaternion(q1.R - q2.R, q1.I - q2.I, q1.J - q2.J, q1.K - q2.K);
        }

        /// <summary>四元数積</summary>
        public static Quaternion operator *(Quaternion q1, Quaternion q2) {
            double r, i, j, k;

            r = q1.R * q2.R - q1.I * q2.I - q1.J * q2.J - q1.K * q2.K;
            i = q1.R * q2.I + q1.I * q2.R + q1.J * q2.K - q1.K * q2.J;
            j = q1.R * q2.J - q1.I * q2.K + q1.J * q2.R + q1.K * q2.I;
            k = q1.R * q2.K + q1.I * q2.J - q1.J * q2.I + q1.K * q2.R;

            return new Quaternion(r, i, j, k);
        }

        /// <summary>四元数・ベクトル積</summary>
        public static Quaternion operator *(Quaternion q, Vector3D v) {
            double r, i, j, k;

            r = -q.I * v.X - q.J * v.Y - q.K * v.Z;
            i = +q.R * v.X + q.J * v.Z - q.K * v.Y;
            j = +q.R * v.Y - q.I * v.Z + q.K * v.X;
            k = +q.R * v.Z + q.I * v.Y - q.J * v.X;

            return new Quaternion(r, i, j, k);
        }

        /// <summary>ベクトル・四元数積</summary>
        public static Quaternion operator *(Vector3D v, Quaternion q) {
            double r, i, j, k;

            r = -v.X * q.I - v.Y * q.J - v.Z * q.K;
            i = +v.X * q.R + v.Y * q.K - v.Z * q.J;
            j = -v.X * q.K + v.Y * q.R + v.Z * q.I;
            k = +v.X * q.J - v.Y * q.I + v.Z * q.R;

            return new Quaternion(r, i, j, k);
        }

        /// <summary>四元数除</summary>
        public static Quaternion operator /(Quaternion q1, Quaternion q2) {
            return q1 * q2.Inverse;
        }

        /// <summary>スカラー倍</summary>
        public static Quaternion operator *(double r, Quaternion q) {
            return new Quaternion(q.R * r, q.I * r, q.J * r, q.K * r);
        }

        /// <summary>スカラー倍</summary>
        public static Quaternion operator *(Quaternion q, double r) {
            return r * q;
        }

        /// <summary>スカラー逆数倍</summary>
        public static Quaternion operator /(Quaternion q, double r) {
            return new Quaternion(q.R / r, q.I / r, q.J / r, q.K / r);
        }

        /// <summary>等しいか判定</summary>
        public static bool operator ==(Quaternion q1, Quaternion q2) {
            return q1.R == q2.R && q1.I == q2.I && q1.J == q2.J && q1.K == q2.K;
        }

        /// <summary>異なるか判定</summary>
        public static bool operator !=(Quaternion q1, Quaternion q2) {
            return q1.R != q2.R || q1.I != q2.I || q1.J != q2.J || q1.K != q2.K;
        }

        /// <summary>等しいか判定</summary>
        public override bool Equals(object obj) {
            return (!(obj is null)) && obj is Quaternion q && q == this;
        }

        /// <summary>ハッシュ値</summary>
        public override int GetHashCode() {
            return R.GetHashCode() ^ I.GetHashCode() ^ J.GetHashCode() ^ K.GetHashCode();
        }

        /// <summary>虚数成分をベクトルとして型変換</summary>
        public static explicit operator Vector3D(Quaternion q) {
            return new Vector3D(q.I, q.J, q.K);
        }

        /// <summary>ゼロか判定</summary>
        public static bool IsZero(Quaternion q) {
            return (q.R == 0) && (q.I == 0) && (q.J == 0) && (q.K == 0);
        }

        /// <summary>非数を含むか判定</summary>
        public static bool IsNaN(Quaternion q) {
            return double.IsNaN(q.R) || double.IsNaN(q.I) || double.IsNaN(q.J) || double.IsNaN(q.K);
        }

        /// <summary>無限大を含むか判定</summary>
        public static bool IsInfinity(Quaternion q) {
            return double.IsInfinity(q.R) || double.IsInfinity(q.I) || double.IsInfinity(q.J) || double.IsInfinity(q.K);
        }

        /// <summary>有効な四元数であるか判定</summary>
        public static bool IsValid(Quaternion q) {
            return !IsNaN(q) && !IsInfinity(q);
        }

        /// <summary>0</summary>
        public static Quaternion Zero => new(0, 0, 0, 0);

        /// <summary>1</summary>
        public static Quaternion Identity => new(1, 0, 0, 0);

        /// <summary>文字列化</summary>
        public override string ToString() {
            return $"{R},{I},{J},{K}";
        }
    }
}
