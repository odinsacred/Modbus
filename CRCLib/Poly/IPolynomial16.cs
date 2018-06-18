using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly
{
    public interface IPolynomial16
    {
        UInt16 Poly { get; }
        UInt16 Init { get; }
        UInt16 XorOut { get; }
        bool RefIn { get; }
        bool RefOut { get; }
    }
}
