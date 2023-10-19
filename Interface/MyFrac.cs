using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_4
{
    class MyFrac : IMyNumber<MyFrac>
    {
        private BigInteger nom;
        private BigInteger denom;

        public MyFrac(int nom, int denom)
        {
            this.nom = nom;
            this.denom = denom;
        }
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            this.nom = nom;
            this.denom = denom;
        } 
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(BigInteger.Add(BigInteger.Multiply(this.nom, that.denom),
                                             BigInteger.Multiply(this.denom, that.nom)),
                              BigInteger.Multiply(this.denom, that.denom));

        }
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(BigInteger.Subtract(BigInteger.Multiply(this.nom, that.denom),
                                             BigInteger.Multiply(this.denom, that.nom)),
                              BigInteger.Multiply(this.denom, that.denom));

        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(BigInteger.Multiply(this.nom, that.nom),
                              BigInteger.Multiply(this.denom, that.denom));

        }

        public MyFrac Divide(MyFrac that)
        {
            if (this.denom != 0 && that.nom != 0)
            {
                return new MyFrac(BigInteger.Multiply(this.nom, that.denom),
                              BigInteger.Multiply(this.denom, that.nom));

            }
            else
            {
                throw new DivideByZeroException();
            }

        }
        public override string ToString()
        {
            return $"{nom} / {denom}";
        }


    }

}
