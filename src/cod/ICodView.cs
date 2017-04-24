using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// The view of a certain commit.
    /// This might be a file system representation
    /// </summary>
    public interface ICodView
    {
        /// <summary>
        /// The storage that created the view
        /// </summary>
        ICodStorage Storage { get; }

        /// <summary>
        /// The viewed reference
        /// </summary>
        ICodReference Reference { get; }

        /// <summary>
        /// Another reference to compare with.
        /// This enables knowing if we are behind or ahead of the tracked reference
        /// </summary>
        ICodReference TrackedReference { get; }

        /// <summary>
        /// The user looking at the reference
        /// </summary>
        ICodUser User { get; }

        /// <summary>
        /// All entities defined by this view
        /// </summary>
        IEnumerable<ICodViewEntity> Entities { get; }

        /// <summary>
        /// Creates a commit of the currently staged entitites.
        /// The reference should be updated to the new commit.
        /// The commit should also be added to the storage
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        ICodCommitResult Commit(string message);
    }
}
