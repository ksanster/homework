using System;
namespace Lesson3
{
    namespace Ex1
    {
        public struct Complex
        {
            public double im;
            public double re;

            public Complex Add(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }
            public Complex Sub(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }
            public Complex Mul(Complex x)
            {
                Complex y;
                y.im = re * x.im + im * x.re;
                y.re = re * x.re - im * x.im;
                return y;
            }

            public override string ToString()
            {
                var reStr = re.ToString("F2");
                var imStr = (im == 0) ? string.Empty : "i" + Math.Abs(im).ToString("F1");
                var sign = (im == 0) ? string.Empty : (im > 0) ? "+" : "-";

                return $"[{reStr}{sign}{imStr}]";
            }

        }
    }
}
