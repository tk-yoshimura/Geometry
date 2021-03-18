using System;

namespace Geometry.Geometry3D {

    /// <summary>四面体</summary>
    public class Tetrahedron3D {

        /// <summary>コンストラクタ</summary>
        public Tetrahedron3D(Vector3D v0, Vector3D v1, Vector3D v2, Vector3D v3) {
            this.V0 = v0;
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
        }

        /// <summary>構成点0</summary>
        public Vector3D V0 { get; set; }

        /// <summary>構成点1</summary>
        public Vector3D V1 { get; set; }

        /// <summary>構成点2</summary>
        public Vector3D V2 { get; set; }

        /// <summary>構成点3</summary>
        public Vector3D V3 { get; set; }

        /// <summary>面積</summary>
        public double Area {
            get {
                Triangle3D t123 = new Triangle3D(V1, V2, V3), t023 = new Triangle3D(V0, V2, V3), t013 = new Triangle3D(V0, V1, V3), t012 = new Triangle3D(V0, V1, V2);

                return t123.Area + t023.Area + t013.Area + t012.Area;
            }
        }

        /// <summary>体積</summary>
        public double Volume{
            get {
                return Math.Abs(Vector3D.InnerProduct((V1 - V0) * (V2 - V0), V3 - V0)) / 6;
            }
        }
        /// <summary>行列積</summary>
        public static Tetrahedron3D operator *(Matrix3D matrix, Tetrahedron3D tetrahedron) {
            return new Tetrahedron3D(matrix * tetrahedron.V0, matrix * tetrahedron.V1, matrix * tetrahedron.V2, matrix * tetrahedron.V3);
        }

        /// <summary>不正な四面体</summary>
        public static Tetrahedron3D Invalid => new Tetrahedron3D(Vector3D.Invalid, Vector3D.Invalid, Vector3D.Invalid, Vector3D.Invalid);

        /// <summary>有効な四面体であるか判定</summary>
        public static bool IsValid(Tetrahedron3D tetrahedron) {
            return Vector3D.IsValid(tetrahedron.V0) && Vector3D.IsValid(tetrahedron.V1) && Vector3D.IsValid(tetrahedron.V2) && Vector3D.IsValid(tetrahedron.V3);
        }
    }
}
