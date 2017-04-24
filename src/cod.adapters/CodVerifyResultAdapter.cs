using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodVerifyResultAdapter : CodNodeOperationResultAdapter, ICodVerifyResult
    {
        public static ICodVerifyResult Success(ICodNode node)
        {
            return new CodVerifyResultAdapter(node, true, null);
        }

        public static ICodVerifyResult Failed(ICodNode node, string error)
        {
            return new CodVerifyResultAdapter(node, false, error);
        }


        private CodVerifyResultAdapter(ICodNode node, bool isValid, string error)
            : base(node, isValid, error)
        {

        }
    }
}
