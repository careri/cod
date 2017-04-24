using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cod
{
    public interface ICodUser
    {
        /// <summary>
        /// A unique ID for the user
        /// </summary>
        string ID { get; }

        /// <summary>
        /// The name of the user
        /// </summary>
        string Name { get; }
    }
}
