using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class Polynomial
    {
        private int[] _coeff;

        public int[] Coeff
        {
            get { return _coeff; }
        }

        public Polynomial(params int[] coeff)
        {
            if (coeff.Length < 2)
                throw new Exception("It's a polynomial with degree smaller than 1");
            else if (coeff[0] == 0)
                throw new Exception("The coefficient of the highest power of the polynomial is zero");
            else
            {
                _coeff = new int[coeff.Length];
                for (int i = 0; i < coeff.Length; i++)
                    _coeff[i] = coeff[i];
            }
        }

        public static bool operator ==(Polynomial polynomFirst, Polynomial polynomSecond)
        {
            if (ReferenceEquals(polynomFirst, polynomSecond))
                return true;

            if (((object)polynomFirst == null) || ((object)polynomSecond == null))
                return false;

            if (polynomFirst._coeff.Length != polynomSecond._coeff.Length)
                return false;

            for (int i = 0; i < polynomFirst._coeff.Length; i++)
                if (polynomFirst._coeff[i] != polynomSecond._coeff[i])
                    return false;

            return true;
        }

        public static bool operator !=(Polynomial polynomFirst, Polynomial polynomSecond)
        {
            return !(polynomFirst == polynomSecond);
        }

        public static Polynomial operator +(Polynomial polynomFirst, Polynomial polynomSecond)
        {
            if (polynomFirst == null || polynomSecond == null)
                throw new ArgumentNullException();

            if (polynomFirst._coeff.Length > polynomSecond._coeff.Length)
            {
                var polynom = new Polynomial(polynomFirst._coeff);
                for (int i = 0; i < polynomSecond._coeff.Length; i++)
                    polynom._coeff[i + polynomFirst._coeff.Length - polynomSecond._coeff.Length] = checked(polynomFirst._coeff[i + polynomFirst._coeff.Length - polynomSecond._coeff.Length] + polynomSecond._coeff[i]);

                return polynom;
            }
            else
            {
                var polynom = new Polynomial(polynomSecond._coeff);
                for (int i = 0; i < polynomFirst._coeff.Length; i++)
                    polynom._coeff[i + polynomSecond._coeff.Length - polynomFirst._coeff.Length] = checked(polynomFirst._coeff[i] + polynomSecond._coeff[i + polynomSecond._coeff.Length - polynomFirst._coeff.Length]);

                return polynom;
            }
        }

        public static Polynomial operator -(Polynomial polynomFirst, Polynomial polynomSecond)
        {
            if (polynomFirst == null || polynomSecond == null)
                throw new ArgumentNullException();

            if (polynomFirst._coeff.Length > polynomSecond._coeff.Length)
            {
                var polynom = new Polynomial(polynomFirst._coeff);
                for (int i = 0; i < polynomSecond._coeff.Length; i++)
                    polynom._coeff[i + polynomFirst._coeff.Length - polynomSecond._coeff.Length] = checked(polynomFirst._coeff[i + polynomFirst._coeff.Length - polynomSecond._coeff.Length] - polynomSecond._coeff[i]);
                for (int i = 0; i < polynomFirst._coeff.Length - polynomSecond._coeff.Length; i++)
                    polynom._coeff[i] = -polynom._coeff[i];

                return polynom;
            }
            else
            {
                var polynom = new Polynomial(polynomSecond._coeff);
                for (int i = 0; i < polynomFirst._coeff.Length; i++)
                    polynom._coeff[i + polynomSecond._coeff.Length - polynomFirst._coeff.Length] = checked(polynomFirst._coeff[i] - polynomSecond._coeff[i + polynomSecond._coeff.Length - polynomFirst._coeff.Length]);
                for (int i = 0; i < polynomSecond._coeff.Length - polynomFirst._coeff.Length; i++)
                    polynom._coeff[i] = -polynom._coeff[i];

                return polynom;
            }
        }

        public static Polynomial operator *(Polynomial polynomFirst, Polynomial polynomSecond)
        {
            if (polynomFirst == null || polynomSecond == null)
                throw new ArgumentNullException();

            int[] coeff = new int[polynomFirst._coeff.Length + polynomSecond._coeff.Length - 1];
            coeff[0] = 1;
            var polynom = new Polynomial(coeff);
            polynom._coeff[0] = 0;

            if (polynomFirst._coeff.Length < polynomSecond._coeff.Length)
            {
                Polynomial polynomExchange = polynomFirst;
                polynomFirst = polynomSecond;
                polynomSecond = polynomExchange;
            }

            checked
            {
                for (int i = 0; i < Math.Min(polynomFirst._coeff.Length, polynomSecond._coeff.Length); i++)
                    for (int j = 0; j <= i; j++)
                        polynom._coeff[i] += polynomFirst._coeff[j] * polynomSecond._coeff[i - j];

                int k = 0;
                for (int i = Math.Min(polynomFirst._coeff.Length, polynomSecond._coeff.Length); i < Math.Max(polynomFirst._coeff.Length, polynomSecond._coeff.Length); i++)
                {
                    k++;
                    for (int j = k; j <= i; j++)
                        polynom._coeff[i] += polynomFirst._coeff[j] * polynomSecond._coeff[i - j];
                }

                int l = 0;
                for (int i = Math.Max(polynomFirst._coeff.Length, polynomSecond._coeff.Length); i < polynom._coeff.Length; i++)
                {
                    k++;
                    l++;
                    for (int j = k; j <= i - l; j++)
                        polynom._coeff[i] += polynomFirst._coeff[j] * polynomSecond._coeff[i - j];
                }
            }

            return polynom;
        }
    }
}