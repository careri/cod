using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// An item in the objects history.
    /// Can hold any kind of data.
    /// The most common data is a commit of value changes.
    /// The node is imutable once written
    /// </summary>
    public interface ICodNode
    {
        /// <summary>
        /// A unique ID. Probably the hash of the content
        /// </summary>
        string ID { get; }

        /// <summary>
        /// The parent of this node.
        /// Must always have a parent if not the root.
        /// Additional parents can be stored in the metadata
        /// </summary>
        ICodNode Parent { get; }

        /// <summary>
        /// The entities provided by this node
        /// </summary>
        IEnumerable<ICodEntity> Entities { get; }

        /// <summary>
        /// The type of node
        /// </summary>
        byte NodeType { get; }

        /// <summary>
        /// The author of the node
        /// </summary>
        ICodUser Author { get; }
    }
}
