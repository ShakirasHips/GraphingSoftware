using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingSoftware
{
    abstract class MathOperand<T>
    {
        public abstract T Divide(T a, T b);
        public abstract T Multiply(T a, T b);
        public abstract T Add(T a, T b);
        public abstract T Negate(T a);
        public virtual T Subtract(T a, T b)
        {
            return Add(a, Negate(b));
        }
    }

    class DoubleMathOperand : MathOperand<double>
    {
        public override double Divide(double a, double b)
        {
            return a / b;
        }

        public override double Multiply(double a, double b)
        {
            return a * b;
        }

        public override double Add(double a, double b)
        {
            return a + b;
        }

        public override double Negate(double a)
        {
            return -a;
        }
    }

    class IntMathOperand : MathOperand<int>
    {
        public override int Divide(int a, int b)
        {
            return a / b;
        }

        public override int Multiply(int a, int b)
        {
            return a * b;
        }

        public override int Add(int a, int b)
        {
            return a + b;
        }

        public override int Negate(int a)
        {
            return -a;
        }
    }

    public class Fraction<T>
    {
        static MathOperand<T> type;

        static Fraction()
        {
            if (typeof(T) == typeof(double))
            {
                type = new DoubleMathOperand() as MathOperand<T>;
            }
            else if (typeof(T) == typeof(int))
            {
                type = new IntMathOperand() as MathOperand<T>;
            }
        }

        public Fraction(T n, T d)
        {
            N = n;
            D = d;
        }

        public T N { get; private set; }
        public T D { get; private set; }

        public override string ToString()
        {
            return N.ToString() + "/" + D.ToString();
        }

      
        
    }
}
