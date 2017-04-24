using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodAddResultAdapter : CodNodeOperationResultAdapter, ICodAddResult
    {
        public static ICodAddResult Success(ICodNode node)
        {
            return new CodAddResultAdapter(node, true, null);
        }

        public static ICodAddResult Failed(ICodNode node, string error)
        {
            return new CodAddResultAdapter(node, false, error);
        }

        private CodAddResultAdapter(ICodNode node, bool isValid, string error)
            : base(node, isValid, error)
        {

        }
    }
}
