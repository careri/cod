using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodNodeOperationResultAdapter<T> : CodOperationResultAdapter, ICodNodeOperationResult<T>
        where T : ICodNode
    {
        private readonly T m_node;

        protected CodNodeOperationResultAdapter(T node, bool isValid, string error)
            : base(isValid, error)
        {
            m_node = node;
        }

        public override string ID
        {
            get
            {
                return m_node != null ? m_node.ID : "<null>";
            }
        }


        public T Node
        {
            get { return m_node; }
        }
    }

    public class CodNodeOperationResultAdapter : CodNodeOperationResultAdapter<ICodNode>
    {
        protected CodNodeOperationResultAdapter(ICodNode node, bool isValid, string error)
            : base(node, isValid, error)
        {
        }
    }
}
