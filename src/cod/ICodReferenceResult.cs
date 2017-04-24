using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cod
{
    /// <summary>
    /// The result of a code reference operation
    /// </summary>
    public interface ICodReferenceResult : ICodNodeOperationResult
    {
        ICodReference Reference { get; }
    }
}
