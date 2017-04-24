using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    [DebuggerDisplay("{ToDebugString()}")]
    public abstract class CodAdapterBase
    {
        public abstract string ToDebugString();
    }
}
