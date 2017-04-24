using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    public interface ICodNodeOperationResult<T> : ICodOperationResult
        where T : ICodNode
    {
        T Node { get; }
    }

    /// <summary>
    /// The result of a node operation
    /// </summary>
    public interface ICodNodeOperationResult : ICodNodeOperationResult<ICodNode>
    {
    }
}
