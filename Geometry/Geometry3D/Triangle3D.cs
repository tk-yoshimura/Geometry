using System;

namespace Geometry.Geometry3D {

    /// <summary>三角形</summary>
    public class Triangle3D {

        /// <summary>コンストラクタ</summary>
        public Triangle3D(Vector3D v0, Vector3D v1, Vector3D v2) {
            this.V0 = v0;
            this.V1 = v1;
            this.V2 = v2;
        }

        /// <summary>構成点0</summary>
        public Vector3D V0 { get; set; }

        /// <summary>構成点1</summary>
        public Vector3D V1 { get; set; }

        /// <summary>構成点2</summary>
        public Vector3D V2 { get; set; }

        /// <summary>面積</summary>
        public double Area => Math.Sqrt(((V1 - V0) * (V2 - V0)).SquareNorm) / 2;

        /// <summary>行列積</summary>
        public static Triangle3D operator *(Matrix3D matrix, Triangle3D triangle) {
            return new Triangle3D(matrix * triangle.V0, matrix * triangle.V1, matrix * triangle.V2);
        }

        /// <summary>不正な三角形</summary>
        public static Triangle3D Invalid => new(Vector3D.Invalid, Vector3D.Invalid, Vector3D.Invalid);

        /// <summary>有効な三角形であるか判定</summary>
        public static bool IsValid(Triangle3D triangle) {
            return Vector3D.IsValid(triangle.V0) && Vector3D.IsValid(triangle.V1) && Vector3D.IsValid(triangle.V2);
        }
    }
}
