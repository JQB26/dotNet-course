using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw03
{
    class Complex<T>
    {
        private T realPart;
        private T imaginaryPart;


        public void SetRealPart(T realPart)
        {
            this.realPart = realPart;
        }
        public T GetRealPart()
        {
            return realPart;
        }

        public void SetImaginaryPart(T imaginaryPart)
        {
            this.imaginaryPart = imaginaryPart;
        }
        public T GetImaginaryPart()
        {
            return imaginaryPart;
        }
    }
}
