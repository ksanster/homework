using System;
namespace Lesson3
{
    namespace Ex1
    {
        public class ComplexClass
        {
            public static ComplexClass operator +(ComplexClass value) => value;
            public static ComplexClass operator +(ComplexClass v1, ComplexClass v2)
            {
                return new ComplexClass(v1.Re + v2.Re, v1.Im + v2.Im);
            }
            public static ComplexClass operator -(ComplexClass value)
            {
                return new ComplexClass(-value.Re, value.Im);
            }
            public static ComplexClass operator -(ComplexClass v1, ComplexClass v2)
            {
                return new ComplexClass(v1.Re - v2.Re, v1.Im - v2.Im);
            }
            //λ(x+iy)=λx+iλy.
            public static ComplexClass operator *(ComplexClass v1, double v)
            {
                return new ComplexClass(v * v1.Re, v * v1.Im);
            }
            public static ComplexClass operator *(double v, ComplexClass v1)
            {
                return new ComplexClass(v * v1.Re, v * v1.Im);
            }
            //(x1+iy1)(x2+iy2)=x1x2−y1y2+(x1y2+x2y1)i.
            public static ComplexClass operator *(ComplexClass v1, ComplexClass v2)
            {
                return new ComplexClass(v1.Re * v2.Re - v1.Im * v2.Im, v1.Re * v2.Im + v2.Re * v1.Im);
            }

            private double re;
            private double im;

            public double Re
            {
                get => re;
                set => re = value;
            }
            public double Im
            {
                get => im;
                set => im = value;
            }

            public ComplexClass()
            {
                re = 0;
                im = 0;
            }

            public ComplexClass(double re, double im)
            {
                this.re = re;
                this.im = im;
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
