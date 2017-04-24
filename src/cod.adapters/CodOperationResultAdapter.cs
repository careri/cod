using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodOperationResultAdapter : CodAdapterBase, ICodOperationResult
    {
        private readonly bool m_isValid;
        private readonly string m_error;

        protected CodOperationResultAdapter(bool isValid, string error)
        {
            m_isValid = isValid;
            m_error = error;
        }

        public virtual string ID { get { return null; } }

        public bool IsValid
        {
            get { return m_isValid; }
        }

        public string Error
        {
            get { return m_error; }
        }

        public override string ToDebugString()
        {
            var id = ID ?? string.Empty;

            if (m_isValid)
            {
                return string.Format("[OK] {0}", id);
            }
            return string.Format("[Failed] {0}, {1}", id, m_error ?? "Unknown error");
        }
    }
}
