using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// A binary large object
    /// </summary>
    public interface ICodBlob
    {
        uint Size { get; }

        Stream GetStream();

        string Hash { get; }
    }
}
