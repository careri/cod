using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    /// <summary>
    /// Retrievs all entities in the history of the current view
    /// </summary>
    public class CodEntityCollection : CodAdapterBase
    {
        private readonly bool m_isOwnerAdapter;
        private readonly ICodView m_owner;
        private readonly Lazy<ICodEntity[]> m_entities;
        private readonly Lazy<ICodNode> m_node;

        public CodEntityCollection(ICodView owner)
        {
            m_owner = owner;
            m_isOwnerAdapter = owner is CodAdapterBase;
            m_entities = new Lazy<ICodEntity[]>(InitEntities, true);
            m_node = new Lazy<ICodNode>(() => m_owner.Reference.Node, true);
        }

        /// <summary>
        /// The node that defined the entities
        /// </summary>
        public ICodNode Node { get { return m_node.Value; } }

        /// <summary>
        /// The defined entities
        /// </summary>
        public ICodEntity[] Entities { get { return m_entities.Value; } } 

        private ICodEntity[] InitEntities()
        {
            // Read all entities from the commit and back
            var node = m_node.Value;
            var dic = new Dictionary<string, ICodEntity>();
            var caseSensitive = m_owner.Storage.IsCaseSensitive;

            while (node != null)
            {
                foreach (var item in node.Entities)
                {
                    var name = item.Name;

                    if (!caseSensitive)
                    {
                        name = name.ToLowerInvariant();
                    }
                    if (!dic.ContainsKey(name))
                    {
                        dic[name] = item;
                    }
                }
                node = node.Parent;
            }

            return dic.Values.ToArray();
        }


        public override string ToDebugString()
        {
            var e = m_entities;
            var ownerStr = m_isOwnerAdapter ?
                    ((CodAdapterBase)m_owner).ToDebugString() :
                    m_owner.ToString();

            if (e.IsValueCreated)
            {
                var entities = m_entities.Value;
                var sb = new StringBuilder();
                

                sb.AppendFormat("[{0}]", ownerStr);

                if (entities.Length == 0)
                {
                    sb.Append(" No entities");
                }
                else
                {
                    var reader = m_owner.Storage.ValueReader ?? new CodEntityValueReaderAdapter();

                    foreach (var item in entities)
                    {
                        sb.AppendLine();
                        var value = item.GetHumanReadableValueSafe(reader);
                        sb.AppendFormat("[{0}] = {1}", item.Name, value);
                    }
                }
                return sb.ToString();
            }
            return string.Format("[{0}] Entities not initialized", ownerStr);
        }
    }
}
