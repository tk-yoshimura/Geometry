using System;

namespace Geometry.Geometry3D {

    /// <summary>3次元同次変換行列</summary>
    public struct Matrix3D {

        /// <summary>コンストラクタ</summary>
        public Matrix3D(double e11, double e12, double e13, double e21, double e22, double e23, double e31, double e32, double e33) {
            this.E11 = e11;
            this.E12 = e12;
            this.E13 = e13;
            this.E21 = e21;
            this.E22 = e22;
            this.E23 = e23;
            this.E31 = e31;
            this.E32 = e32;
            this.E33 = e33;

            this.E14 = this.E24 = this.E34 = this.E41 = this.E42 = this.E43 = 0;
            this.E44 = 1;
        }

        /// <summary>コンストラクタ</summary>
        public Matrix3D(double e11, double e12, double e13, double e14, double e21, double e22, double e23, double e24,
                        double e31, double e32, double e33, double e34, double e41, double e42, double e43, double e44) {

            this.E11 = e11;
            this.E12 = e12;
            this.E13 = e13;
            this.E14 = e14;
            this.E21 = e21;
            this.E22 = e22;
            this.E23 = e23;
            this.E24 = e24;
            this.E31 = e31;
            this.E32 = e32;
            this.E33 = e33;
            this.E34 = e34;
            this.E41 = e41;
            this.E42 = e42;
            this.E43 = e43;
            this.E44 = e44;
        }

        /// <summary>E11成分</summary>
        public double E11 { get; set; }

        /// <summary>E12成分</summary>
        public double E12 { get; set; }

        /// <summary>E13成分</summary>
        public double E13 { get; set; }

        /// <summary>E14成分</summary>
        public double E14 { get; set; }

        /// <summary>E21成分</summary>
        public double E21 { get; set; }

        /// <summary>E22成分</summary>
        public double E22 { get; set; }

        /// <summary>E23成分</summary>
        public double E23 { get; set; }

        /// <summary>E24成分</summary>
        public double E24 { get; set; }

        /// <summary>E31成分</summary>
        public double E31 { get; set; }

        /// <summary>E32成分</summary>
        public double E32 { get; set; }

        /// <summary>E33成分</summary>
        public double E33 { get; set; }

        /// <summary>E34成分</summary>
        public double E34 { get; set; }

        /// <summary>E41成分</summary>
        public double E41 { get; set; }

        /// <summary>E42成分</summary>
        public double E42 { get; set; }

        /// <summary>E43成分</summary>
        public double E43 { get; set; }

        /// <summary>E44成分</summary>
        public double E44 { get; set; }

        /// <summary>転置</summary>
        public readonly Matrix3D Transpose {
            get {
                return new Matrix3D(E11, E21, E31, E41,
                                    E12, E22, E32, E42,
                                    E13, E23, E33, E43,
                                    E14, E24, E34, E44);
            }
        }

        /// <summary>単項プラス</summary>
        public static Matrix3D operator +(Matrix3D m) {
            return m;
        }

        /// <summary>単項マイナス</summary>
        public static Matrix3D operator -(Matrix3D m) {
            return new Matrix3D(-m.E11, -m.E12, -m.E13, -m.E14,
                                -m.E21, -m.E22, -m.E23, -m.E24,
                                -m.E31, -m.E32, -m.E33, -m.E34,
                                -m.E41, -m.E42, -m.E43, -m.E44);
        }

        /// <summary>行列和</summary>
        public static Matrix3D operator +(Matrix3D m1, Matrix3D m2) {
            return new Matrix3D(m1.E11 + m2.E11, m1.E12 + m2.E12, m1.E13 + m2.E13, m1.E14 + m2.E14,
                                m1.E21 + m2.E21, m1.E22 + m2.E22, m1.E23 + m2.E23, m1.E24 + m2.E24,
                                m1.E31 + m2.E31, m1.E32 + m2.E32, m1.E33 + m2.E33, m1.E34 + m2.E34,
                                m1.E41 + m2.E41, m1.E42 + m2.E42, m1.E43 + m2.E43, m1.E44 + m2.E44);
        }

        /// <summary>行列差</summary>
        public static Matrix3D operator -(Matrix3D m1, Matrix3D m2) {
            return new Matrix3D(m1.E11 - m2.E11, m1.E12 - m2.E12, m1.E13 - m2.E13, m1.E14 - m2.E14,
                                m1.E21 - m2.E21, m1.E22 - m2.E22, m1.E23 - m2.E23, m1.E24 - m2.E24,
                                m1.E31 - m2.E31, m1.E32 - m2.E32, m1.E33 - m2.E33, m1.E34 - m2.E34,
                                m1.E41 - m2.E41, m1.E42 - m2.E42, m1.E43 - m2.E43, m1.E44 - m2.E44);
        }

        /// <summary>行列積</summary>
        public static Matrix3D operator *(Matrix3D m1, Matrix3D m2) {
            return new Matrix3D(m1.E11 * m2.E11 + m1.E12 * m2.E21 + m1.E13 * m2.E31 + m1.E14 * m2.E41,
                                m1.E11 * m2.E12 + m1.E12 * m2.E22 + m1.E13 * m2.E32 + m1.E14 * m2.E42,
                                m1.E11 * m2.E13 + m1.E12 * m2.E23 + m1.E13 * m2.E33 + m1.E14 * m2.E43,
                                m1.E11 * m2.E14 + m1.E12 * m2.E24 + m1.E13 * m2.E34 + m1.E14 * m2.E44,

                                m1.E21 * m2.E11 + m1.E22 * m2.E21 + m1.E23 * m2.E31 + m1.E24 * m2.E41,
                                m1.E21 * m2.E12 + m1.E22 * m2.E22 + m1.E23 * m2.E32 + m1.E24 * m2.E42,
                                m1.E21 * m2.E13 + m1.E22 * m2.E23 + m1.E23 * m2.E33 + m1.E24 * m2.E43,
                                m1.E21 * m2.E14 + m1.E22 * m2.E24 + m1.E23 * m2.E34 + m1.E24 * m2.E44,

                                m1.E31 * m2.E11 + m1.E32 * m2.E21 + m1.E33 * m2.E31 + m1.E34 * m2.E41,
                                m1.E31 * m2.E12 + m1.E32 * m2.E22 + m1.E33 * m2.E32 + m1.E34 * m2.E42,
                                m1.E31 * m2.E13 + m1.E32 * m2.E23 + m1.E33 * m2.E33 + m1.E34 * m2.E43,
                                m1.E31 * m2.E14 + m1.E32 * m2.E24 + m1.E33 * m2.E34 + m1.E34 * m2.E44,

                                m1.E41 * m2.E11 + m1.E42 * m2.E21 + m1.E43 * m2.E31 + m1.E44 * m2.E41,
                                m1.E41 * m2.E12 + m1.E42 * m2.E22 + m1.E43 * m2.E32 + m1.E44 * m2.E42,
                                m1.E41 * m2.E13 + m1.E42 * m2.E23 + m1.E43 * m2.E33 + m1.E44 * m2.E43,
                                m1.E41 * m2.E14 + m1.E42 * m2.E24 + m1.E43 * m2.E34 + m1.E44 * m2.E44);
        }

        /// <summary>スカラー倍</summary>
        public static Matrix3D operator *(double r, Matrix3D m) {
            return new Matrix3D(m.E11 * r, m.E12 * r, m.E13 * r, m.E14 * r,
                                m.E21 * r, m.E22 * r, m.E23 * r, m.E24 * r,
                                m.E31 * r, m.E32 * r, m.E33 * r, m.E34 * r,
                                m.E41 * r, m.E42 * r, m.E43 * r, m.E44 * r);
        }

        /// <summary>スカラー倍</summary>
        public static Matrix3D operator *(Matrix3D m, double r) {
            return r * m;
        }

        /// <summary>スカラー逆数倍</summary>
        public static Matrix3D operator /(Matrix3D m, double r) {
            return (1 / r) * m;
        }

        /// <summary>等しいか判定</summary>
        public static bool operator ==(Matrix3D m1, Matrix3D m2) {
            if (m1.E11 != m2.E11 || m1.E12 != m2.E12 || m1.E13 != m2.E13 || m1.E14 != m2.E14)
                return false;

            if (m1.E21 != m2.E21 || m1.E22 != m2.E22 || m1.E23 != m2.E23 || m1.E24 != m2.E24)
                return false;

            if (m1.E31 != m2.E31 || m1.E32 != m2.E32 || m1.E33 != m2.E33 || m1.E24 != m2.E24)
                return false;

            if (m1.E41 != m2.E41 || m1.E42 != m2.E42 || m1.E43 != m2.E43 || m1.E44 != m2.E44)
                return false;

            return true;
        }

        /// <summary>異なるか判定</summary>
        public static bool operator !=(Matrix3D m1, Matrix3D m2) {
            return !(m1 == m2);
        }

        /// <summary>等しいか判定</summary>
        public override readonly bool Equals(object obj) {
            return (!(obj is null)) && obj is Matrix3D matrix && matrix == this;
        }

        /// <summary>ハッシュ値</summary>
        public override readonly int GetHashCode() {
            return E11.GetHashCode() ^ E12.GetHashCode() ^ E13.GetHashCode()
                 ^ E21.GetHashCode() ^ E22.GetHashCode() ^ E23.GetHashCode()
                 ^ E31.GetHashCode() ^ E32.GetHashCode() ^ E33.GetHashCode();
        }

        /// <summary>X軸回転行列</summary>
        /// <param name="theta">回転量(ラジアン)</param>
        public static Matrix3D RotateX(double theta) {
            double cs = Math.Cos(theta), sn = Math.Sin(theta);
            return new Matrix3D(1, 0, 0, 0, +cs, -sn, 0, +sn, +cs);
        }

        /// <summary>Y軸回転行列</summary>
        /// <param name="theta">回転量(ラジアン)</param>
        public static Matrix3D RotateY(double theta) {
            double cs = Math.Cos(theta), sn = Math.Sin(theta);
            return new Matrix3D(+cs, 0, +sn, 0, 1, 0, -sn, 0, +cs);
        }

        /// <summary>Z軸回転行列</summary>
        /// <param name="theta">回転量(ラジアン)</param>
        public static Matrix3D RotateZ(double theta) {
            double cs = Math.Cos(theta), sn = Math.Sin(theta);
            return new Matrix3D(+cs, -sn, 0, +sn, +cs, 0, 0, 0, 1);
        }

        /// <summary>回転行列</summary>
        /// <param name="roll">前後軸に対する回転量</param>
        /// <param name="pitch">左右軸に対する回転量</param>
        /// <param name="yaw">上下軸に対する回転量</param>
        /// <remarks>X軸の+方向が前</remarks>
        public static Matrix3D Rotate(double roll, double pitch, double yaw) {
            return RotateX(roll) * RotateY(pitch) * RotateZ(yaw);
        }

        /// <summary>回転行列</summary>
        /// <param name="axis">回転軸</param>
        /// <param name="theta">回転量</param>
        public static Matrix3D RotateAxis(Vector3D axis, double theta) {
            axis = axis.Normal;

            double cs = Math.Cos(theta), dcs = 1 - cs, sn = Math.Sin(theta);
            double xx, xy, xz, yx, yy, yz, zx, zy, zz;
            double nx = axis.X, ny = axis.Y, nz = axis.Z;

            xx = nx * nx * dcs + cs;
            xy = nx * ny * dcs - nz * sn;
            xz = nx * nz * dcs + ny * sn;

            yx = ny * nx * dcs + nz * sn;
            yy = ny * ny * dcs + cs;
            yz = ny * nz * dcs - nx * sn;

            zx = nz * nx * dcs - ny * sn;
            zy = nz * ny * dcs + nx * sn;
            zz = nz * nz * dcs + cs;

            return new Matrix3D(xx, xy, xz, yx, yy, yz, zx, zy, zz);
        }

        /// <summary>拡大行列</summary>
        /// <param name="sx">X方向の拡大率</param>
        /// <param name="sy">Y方向の拡大率</param>
        /// <param name="sz">Z方向の拡大率</param>
        public static Matrix3D Scale(double sx, double sy, double sz) {
            return new Matrix3D(sx, 0, 0, 0, sy, 0, 0, 0, sz);
        }

        /// <summary>移動行列</summary>
        /// <param name="mx">X方向の移動量</param>
        /// <param name="my">Y方向の移動量</param>
        /// <param name="mz">Z方向の移動量</param>
        public static Matrix3D Move(double mx, double my, double mz) {
            return new Matrix3D(1, 0, 0, mx, 0, 1, 0, my, 0, 0, 1, mz, 0, 0, 0, 1);
        }

        /// <summary>ゼロ行列</summary>
        public static Matrix3D Zero => new(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>単位行列</summary>
        public static Matrix3D Identity => new(1, 0, 0, 0, 1, 0, 0, 0, 1);

        /// <summary>不正な行列</summary>
        public static Matrix3D Invalid {
            get {
                double nan = double.NaN;
                return new Matrix3D(nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan, nan);
            }
        }

        /// <summary>文字列化</summary>
        public override readonly string ToString() {
            return $"{{ {{ {E11}, {E12}, {E13}, {E14} }}, {{ {E21}, {E22}, {E23}, {E24} }}, {{ {E31}, {E32}, {E33}, {E34} }}, {{ {E41}, {E42}, {E43}, {E44} }} }}";
        }
    }
}
