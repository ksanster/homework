using System;
namespace Lesson3
{
    namespace Ex3
    {
        public class Fraction
        {
            public static Fraction operator +(Fraction a)
            {
                return a;
            }
            public static Fraction operator -(Fraction a)
            {
                return new Fraction(-a.numerator, a.denominator);
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                return a + (-b);
            }

            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
            }

            public static Fraction operator /(Fraction a, Fraction b)
            {
                if (b.numerator == 0)
                {
                    throw new DivideByZeroException();
                }
                return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
            }

            private int numerator;
            private int denominator;

            public int Numerator
            {
                get => numerator;
                set
                {
                    numerator = value;
                    Reduct();
                }
            }

            public int Denominator
            {
                get => denominator;
                set
                {
                    if (value == 0)
                        throw new ArgumentException("Знаменатель не может равняться нулю");

                    denominator = value;
                    Reduct();
                }
            }

            public Fraction()
            {
                numerator = 0;
                denominator = 1;
            }

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("Знаменатель не может равняться нулю", nameof(denominator));
                }
                this.numerator = numerator;
                this.denominator = denominator;
                Reduct();
            }

            public void Reduct()
            {
                var nod = NumberUtils.Nod(Math.Abs(numerator), Math.Abs(denominator));
                if (nod == 0)
                    return;

                numerator /= nod;
                denominator /= nod;
            }

            public override string ToString()
            {
                return $"[{numerator}/{denominator}]";
            }
        }
    }
}

