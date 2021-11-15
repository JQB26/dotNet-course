using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw03
{
    // 3.4
    public class Complex<T>
    {
        private T _realPart;
        private T _imaginaryPart;

        public Complex(T realPart, T imaginaryPart)
        {
            _realPart = realPart;
            _imaginaryPart = imaginaryPart;
        }

        public void SetRealPart(T realPart)
        {
            _realPart = realPart;
        }
        public T GetRealPart()
        {
            return _realPart;
        }

        public void SetImaginaryPart(T imaginaryPart)
        {
            _imaginaryPart = imaginaryPart;
        }
        public T GetImaginaryPart()
        {
            return _imaginaryPart;
        }
    }
}
