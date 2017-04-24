using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodGetResultAdapter : CodNodeOperationResultAdapter, ICodGetResult
    {
        public static ICodGetResult Success(ICodNode node)
        {
            return new CodGetResultAdapter(node, true, null);
        }

        public static ICodGetResult Failed(ICodNode node, string error)
        {
            return new CodGetResultAdapter(node, false, error);
        }

        private CodGetResultAdapter(ICodNode node, bool isValid, string error)
            : base(node, isValid, error)
        {

        }
    }
}
