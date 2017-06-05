using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GraphingSoftware
{
    public class Polynomial: Function
    {
        private Dictionary<int, decimal> _poly = new Dictionary<int, decimal>();

        public Polynomial(string Poly)
        {
            Poly = Regex.Replace(Poly, @"\s+", "");

            int key;
            decimal constant;
            string[] monos = Regex.Split(Poly, @"(?=[+-])");

            foreach (string s in monos)
            {
                string[] temp = s.Split(new string[] {"x^"}, StringSplitOptions.RemoveEmptyEntries);
                key = Convert.ToInt32(temp[1]);
                constant = Convert.ToDecimal(temp[0]);
                _poly.Add(key, constant);
            }
        }

        private Polynomial()
        {
            //used in factory methods only
        }

        public Dictionary<int,decimal> Equation
        {
            get { return _poly; }
        }


        public override string ToString()
        {
            string temp = "";
            bool first = true;
            foreach (KeyValuePair<int, decimal> entry in _poly)
            {
                if (entry.Value > 0 && !first)
                {
                    temp += "+" + entry.Value + "x^" + entry.Key;
                }
                else
                {
                    temp += entry.Value + "x^" + entry.Key;
                }
                first = false;
            }
            return temp;
        }

        public override decimal getValue(decimal val)
        {
            double temp = 0;
            foreach (KeyValuePair<int,decimal> entry in _poly)
            {
                temp += (double)entry.Value * Math.Pow((double)val, entry.Key);
            }
            return (decimal)temp;
        }

        //used in factory methods only to build polynomials
        private void addMononomial(int power, decimal constant)
        {
            if (power < 0)
                return;
            _poly.Add(power, constant);
        }

        public override decimal getBoundary(decimal upper, decimal lower)
        {
            return getValue(upper) - getValue(lower);
        }

        public override Function getDerivative()
        {
            Polynomial derivative = new Polynomial();

            foreach (KeyValuePair<int, decimal> entry in _poly)
            {   
                derivative.addMononomial(entry.Key - 1, entry.Value * entry.Key);
            }
            return derivative;
        }

        public override Function getIntegral()
        {
            Polynomial Integral = new Polynomial();

            foreach (KeyValuePair<int, decimal> entry in _poly)
            {
                Integral.addMononomial(entry.Key + 1, entry.Value / (entry.Key+1));
            }

            return Integral;
        }

        public override void draw()
        {
            throw new NotImplementedException();
        }

        public Polynomial negate()
        {
            Polynomial temp = new Polynomial();
            foreach (KeyValuePair<int, decimal> entry in _poly)
            {
                temp.addMononomial(entry.Key, entry.Value * -1);
            }
            return temp;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            Polynomial sum = new Polynomial();

            foreach (KeyValuePair<int,decimal> entryA in a.Equation)
            {
                foreach (KeyValuePair<int,decimal> entryB in b.Equation)
                {
                    if (entryA.Key == entryB.Key)
                    {
                        sum.addMononomial(entryA.Key, entryA.Value + entryB.Value);
                    }

                    if (!(sum.Equation.ContainsKey(entryB.Key) || a.Equation.ContainsKey(entryB.Key)))
                    {
                        sum.addMononomial(entryB.Key, entryB.Value);
                    }
                }
                if (!sum.Equation.ContainsKey(entryA.Key))
                {
                    sum.addMononomial(entryA.Key, entryA.Value);
                }
            }
            return sum;
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return a + b.negate();
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            Polynomial temp = new Polynomial();
            foreach (KeyValuePair<int, decimal> entryA in a.Equation)
            {
                foreach (KeyValuePair<int, decimal> entryB in b.Equation)
                {
                    if (!temp.Equation.ContainsKey(entryA.Key + entryB.Key))
                        temp.addMononomial(entryA.Key + entryB.Key, 0);

                    temp.Equation[entryA.Key + entryB.Key] += entryA.Value * entryB.Value;
                }
            }
            return temp;
        }

        public static Polynomial operator /(Polynomial a, Polynomial b)
        {
            throw new NotImplementedException();
        }
    }
}
