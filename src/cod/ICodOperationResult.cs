using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    public interface ICodOperationResult
    {
        bool IsValid { get; }
        string Error { get; }
    }
}
