using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodViewResultAdapter : CodOperationResultAdapter, ICodViewResult
    {
        public static ICodViewResult Success(ICodView view)
        {
            return new CodViewResultAdapter(view, true, null);
        }

        public static ICodViewResult Failed(ICodView view, string error)
        {
            return new CodViewResultAdapter(view, false, error);
        }

        private readonly ICodView m_view;

        private CodViewResultAdapter(ICodView view, bool isValid, string error)
            : base(isValid, error)
        {
            m_view = view;
        }

        public ICodView View { get { return m_view; } } 
    }
}
