using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// The view of an ICodEntity.
    /// Enables updating the value.
    /// Modified view entities can be staged in a commit and added to the ICodStorage
    /// </summary>
    public interface ICodViewEntity
    {
        /// <summary>
        /// True if the value has been written
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// True if the value is staged for commit
        /// </summary>
        bool IsStaged { get; }

        /// <summary>
        /// The viewed entitity
        /// </summary>
        ICodEntity Entity { get; }
    }

    /// <summary>
    /// Provides the value property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICodViewEntity<T> : ICodViewEntity
    {
        T Value { get; set; }

        new ICodEntity<T> Entity { get; }

        System.IO.Stream GetValueStream();
    }
}
