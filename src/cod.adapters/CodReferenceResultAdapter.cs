using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodReferenceResultAdapter : CodNodeOperationResultAdapter, ICodReferenceResult
    {
        public static ICodReferenceResult Success(ICodReference reference)
        {
            return new CodReferenceResultAdapter(reference, true, null);
        }

        public static ICodReferenceResult Failed(ICodReference reference, string error)
        {
            return new CodReferenceResultAdapter(reference, false, error);
        }

        public static ICodReferenceResult Failed(ICodNode node, string error)
        {
            return new CodReferenceResultAdapter(node, false, error);
        }

        private readonly ICodReference m_reference;

        private CodReferenceResultAdapter(ICodReference reference, bool isValid, string error)
            : this(reference != null ? reference.Node : null, isValid, error)
        {
            m_reference = reference;
        }

        private CodReferenceResultAdapter(ICodNode node, bool isValid, string error)
            : base(node, isValid, error)
        {

        }

        public ICodReference Reference { get { return m_reference; } } 
    }
}
