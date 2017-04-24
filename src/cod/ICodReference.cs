using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// A reference to a certain node in the history
    /// </summary>
    public interface ICodReference
    {
        ICodNode Node { get; }
        string Name { get; }

    }
}
