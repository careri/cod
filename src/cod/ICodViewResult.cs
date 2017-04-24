using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cod
{
    public interface ICodViewResult : ICodOperationResult
    {
        ICodView View { get; }
    }
}
