using System;

namespace Geometry.Geometry2D {

    /// <summary>交差</summary>
    public static class Intersect2D {

        /// <summary>直線間の交点</summary>
        public static Vector2D LineLine(Line2D line1, Line2D line2) {
            Vector2D v1 = line1.V, dv1 = line1.Direction, v2 = line2.V, dv2 = line2.Direction;

            double vv1 = dv1.X * v1.Y - dv1.Y * v1.X;
            double vv2 = dv2.X * v2.Y - dv2.Y * v2.X;
            double vv12 = dv1.X * dv2.Y - dv1.Y * dv2.X;

            return new Vector2D((vv1 * dv2.X - vv2 * dv1.X) / vv12, (vv1 * dv2.Y - vv2 * dv1.Y) / vv12);
        }

        /// <summary>円-直線間の交点</summary>
        public static Vector2D[] CircleLine(Circle2D circle, Line2D line) {
            Vector2D ev = circle.Center - line.V, dv = line.Direction;
            double dv_sqnorm = dv.SquareNorm, radius = circle.Radius;

            double v = radius * radius * dv_sqnorm - dv.X * dv.X * ev.Y * ev.Y - dv.Y * dv.Y * ev.X * ev.X + 2 * dv.X * dv.Y * ev.X * ev.Y;
            
            if(!(v >= 0)) {
                return new Vector2D[0];
            }

            double ed_inner_product = Vector2D.InnerProduct(ev, dv);

            if(v == 0) {
                double t = ed_inner_product / dv_sqnorm;

                return new Vector2D[1] { line.V + t * line.Direction };
            }
            else {
                double t1 = (ed_inner_product - Math.Sqrt(v)) / dv_sqnorm;
                double t2 = (ed_inner_product + Math.Sqrt(v)) / dv_sqnorm;

                return new Vector2D[2] { line.V + t1 * line.Direction, line.V + t2 * line.Direction };
            }
        }
    }
}
