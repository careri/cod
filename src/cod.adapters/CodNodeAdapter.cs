using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodNodeAdapter : ICodNode
    {
        private readonly ICodUser m_author;
        private readonly byte m_type;
        private readonly string m_id;
        private readonly ICodNode m_parent;
        private readonly ICodEntity[] m_entities;

        public CodNodeAdapter(ICodUser author, string id, byte type, ICodNode parent, params ICodEntity[] entities)
        {
            m_id = id;
            m_parent = parent;
            m_entities = entities ?? new ICodEntity[0];
        }

        public string ID
        {
            get { return m_id; }
        }

        public ICodNode Parent
        {
            get { return m_parent; }
        }

        public virtual IEnumerable<ICodEntity> Entities
        {
            get { return m_entities; }
        }


        public byte NodeType
        {
            get { return m_type; }
        }

        public ICodUser Author
        {
            get { return m_author; }
        }
    }
}
