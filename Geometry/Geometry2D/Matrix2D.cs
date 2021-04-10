using System;

namespace Geometry.Geometry2D {

    /// <summary>2次元同次変換行列</summary>
    public struct Matrix2D {

        /// <summary>コンストラクタ</summary>
        public Matrix2D(double e11, double e12, double e21, double e22) {
            this.E11 = e11;
            this.E12 = e12;
            this.E21 = e21;
            this.E22 = e22;

            this.E13 = this.E23 = this.E31 = this.E32 = 0;
            this.E33 = 1;
        }

        /// <summary>コンストラクタ</summary>
        public Matrix2D(double e11, double e12, double e13, double e21, double e22, double e23, double e31, double e32, double e33) {
            this.E11 = e11;
            this.E12 = e12;
            this.E13 = e13;
            this.E21 = e21;
            this.E22 = e22;
            this.E23 = e23;
            this.E31 = e31;
            this.E32 = e32;
            this.E33 = e33;
        }

        /// <summary>E11成分</summary>
        public double E11 { get; set; }

        /// <summary>E12成分</summary>
        public double E12 { get; set; }

        /// <summary>E13成分</summary>
        public double E13 { get; set; }

        /// <summary>E21成分</summary>
        public double E21 { get; set; }

        /// <summary>E22成分</summary>
        public double E22 { get; set; }

        /// <summary>E23成分</summary>
        public double E23 { get; set; }

        /// <summary>E31成分</summary>
        public double E31 { get; set; }

        /// <summary>E32成分</summary>
        public double E32 { get; set; }

        /// <summary>E33成分</summary>
        public double E33 { get; set; }

        /// <summary>転置</summary>
        public Matrix2D Transpose {
            get {
                return new Matrix2D(E11, E21, E31,
                                    E12, E22, E32,
                                    E13, E23, E33);
            }
        }

        /// <summary>単項プラス</summary>
        public static Matrix2D operator +(Matrix2D m) {
            return m;
        }

        /// <summary>単項マイナス</summary>
        public static Matrix2D operator -(Matrix2D m) {
            return new Matrix2D(-m.E11, -m.E12, -m.E13,
                                -m.E21, -m.E22, -m.E23,
                                -m.E31, -m.E32, -m.E33);
        }

        /// <summary>行列和</summary>
        public static Matrix2D operator +(Matrix2D m1, Matrix2D m2) {
            return new Matrix2D(m1.E11 + m2.E11, m1.E12 + m2.E12, m1.E13 + m2.E13,
                                m1.E21 + m2.E21, m1.E22 + m2.E22, m1.E23 + m2.E23,
                                m1.E31 + m2.E31, m1.E32 + m2.E32, m1.E33 + m2.E33);
        }

        /// <summary>行列差</summary>
        public static Matrix2D operator -(Matrix2D m1, Matrix2D m2) {
            return new Matrix2D(m1.E11 - m2.E11, m1.E12 - m2.E12, m1.E13 - m2.E13,
                                m1.E21 - m2.E21, m1.E22 - m2.E22, m1.E23 - m2.E23,
                                m1.E31 - m2.E31, m1.E32 - m2.E32, m1.E33 - m2.E33);
        }

        /// <summary>行列積</summary>
        public static Matrix2D operator *(Matrix2D m1, Matrix2D m2) {
            return new Matrix2D(m1.E11 * m2.E11 + m1.E12 * m2.E21 + m1.E13 * m2.E31,
                                m1.E11 * m2.E12 + m1.E12 * m2.E22 + m1.E13 * m2.E32,
                                m1.E11 * m2.E13 + m1.E12 * m2.E23 + m1.E13 * m2.E33,

                                m1.E21 * m2.E11 + m1.E22 * m2.E21 + m1.E23 * m2.E31,
                                m1.E21 * m2.E12 + m1.E22 * m2.E22 + m1.E23 * m2.E32,
                                m1.E21 * m2.E13 + m1.E22 * m2.E23 + m1.E23 * m2.E33,

                                m1.E31 * m2.E11 + m1.E32 * m2.E21 + m1.E33 * m2.E31,
                                m1.E31 * m2.E12 + m1.E32 * m2.E22 + m1.E33 * m2.E32,
                                m1.E31 * m2.E13 + m1.E32 * m2.E23 + m1.E33 * m2.E33);
        }

        /// <summary>スカラー倍</summary>
        public static Matrix2D operator *(double r, Matrix2D m) {
            return new Matrix2D(m.E11 * r, m.E12 * r, m.E13 * r, m.E21 * r, m.E22 * r, m.E23 * r, m.E31 * r, m.E32 * r, m.E33 * r);
        }

        /// <summary>スカラー倍</summary>
        public static Matrix2D operator *(Matrix2D m, double r) {
            return r * m;
        }

        /// <summary>スカラー逆数倍</summary>
        public static Matrix2D operator /(Matrix2D m, double r) {
            return (1 / r) * m;
        }

        /// <summary>等しいか判定</summary>
        public static bool operator ==(Matrix2D m1, Matrix2D m2) {
            if (m1.E11 != m2.E11 || m1.E12 != m2.E12 || m1.E13 != m2.E13)
                return false;

            if (m1.E21 != m2.E21 || m1.E22 != m2.E22 || m1.E23 != m2.E23)
                return false;

            if (m1.E31 != m2.E31 || m1.E32 != m2.E32 || m1.E33 != m2.E33)
                return false;

            return true;
        }

        /// <summary>異なるか判定</summary>
        public static bool operator !=(Matrix2D m1, Matrix2D m2) {
            return !(m1 == m2);
        }

        /// <summary>等しいか判定</summary>
        public override bool Equals(object obj) {
            return (!(obj is null)) && obj is Matrix2D matrix && matrix == this;
        }

        /// <summary>ハッシュ値</summary>
        public override int GetHashCode() {
            return E11.GetHashCode() ^ E12.GetHashCode() ^ E13.GetHashCode()
                 ^ E21.GetHashCode() ^ E22.GetHashCode() ^ E23.GetHashCode()
                 ^ E31.GetHashCode() ^ E32.GetHashCode() ^ E33.GetHashCode();
        }

        /// <summary>回転行列</summary>
        /// <param name="theta">回転量(ラジアン)</param>
        public static Matrix2D Rotate(double theta) {
            double cs = Math.Cos(theta), sn = Math.Sin(theta);
            return new Matrix2D(cs, -sn, sn, cs);
        }

        /// <summary>拡大行列</summary>
        /// <param name="sx">X方向の拡大率</param>
        /// <param name="sy">Y方向の拡大率</param>
        public static Matrix2D Scale(double sx, double sy) {
            return new Matrix2D(sx, 0, 0, sy);
        }

        /// <summary>移動行列</summary>
        /// <param name="mx">X方向の移動量</param>
        /// <param name="my">Y方向の移動量</param>
        public static Matrix2D Move(double mx, double my) {
            return new Matrix2D(1, 0, mx, 0, 1, my, 0, 0, 1);
        }

        /// <summary>ゼロ行列</summary>
        public static Matrix2D Zero => new(0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>単位行列</summary>
        public static Matrix2D Identity => new(1, 0, 0, 1);

        /// <summary>不正な行列</summary>
        public static Matrix2D Invalid {
            get {
                double nan = double.NaN;
                return new Matrix2D(nan, nan, nan, nan, nan, nan, nan, nan, nan);
            }
        }

        /// <summary>文字列化</summary>
        public override string ToString() {
            return $"{{ {{ {E11}, {E12}, {E13} }}, {{ {E21}, {E22}, {E23} }}, {{ {E31}, {E32}, {E33} }} }}";
        }
    }
}
