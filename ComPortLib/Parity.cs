using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortLib
{
    public enum Parity
    {
        //
        // Summary:
        //     No parity check occurs.
        None = 0,
        //
        // Summary:
        //     Sets the parity bit so that the count of bits set is an odd number.
        Odd = 1,
        //
        // Summary:
        //     Sets the parity bit so that the count of bits set is an even number.
        Even = 2
    }
}
