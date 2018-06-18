using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRCLib.Poly
{
    public interface IPolynomial
    {
        byte Poly { get; }
        byte Init { get; }
        byte XorOut { get; }
        bool RefIn { get; }
        bool RefOut { get; }
    }
}
