using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    /// <summary>
    /// The storage implementation
    /// </summary>
    public interface ICodStorage
    {
        ICodViewEntityHasher ValueHasher { get; }

        /// <summary>
        /// The value reader to use
        /// </summary>
        ICodEntityValueReader ValueReader { get; }

        /// <summary>
        /// If case sensitive we allow multiple entities with the same name but different casing
        /// </summary>
        bool IsCaseSensitive { get; }

        /// <summary>
        /// Verifies that the given node is valid.
        /// E.g. That the file written do disk matches the expected node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        ICodVerifyResult Verify(ICodNode node);

        /// <summary>
        /// Tries to retrieve a node with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nod"></param>
        /// <returns></returns>
        ICodGetResult Get(string id);

        /// <summary>
        /// Attempts to add a node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        ICodAddResult Add(ICodNode node);

        /// <summary>
        /// Retrieves all nodes stored
        /// </summary>
        IEnumerable<ICodNode> Nodes { get; }

        /// <summary>
        /// Tries to point a reference with that name at the given node
        /// </summary>
        /// <param name="name">The name of the reference</param>
        /// <param name="node">The node to point to</param>
        /// <param name="force">If true an existing reference will be overwritten</param>
        /// <returns></returns>
        ICodReferenceResult SetReference(string name, ICodNode node, bool force);

        /// <summary>
        /// Tries to retrieve a view for the given user and reference
        /// </summary>
        /// <param name="user"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        ICodViewResult View(ICodUser user, ICodReference reference);
    }
}
