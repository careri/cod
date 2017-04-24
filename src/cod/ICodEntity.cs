using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// An entity bound to an object.
    /// E.g. a file or a property
    /// </summary>
    public interface ICodEntity
    {
        /// <summary>
        /// A unique ID describing the entity type.
        /// E.g. strings could be of type 0, blobs of type 1.
        /// This is metadata for the storage implementation. But also for the view to know how to write the data
        /// </summary>
        byte Type { get; }
        
        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A hash for the value of this entity.
        /// Used to check for modified entitites
        /// </summary>
        string ValueHash { get; }
    }

    /// <summary>
    /// Provides a value for the ICodEntity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICodEntity<T> : ICodEntity
    {
        T Value { get; }
    }
}
