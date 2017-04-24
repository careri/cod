using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodCommitResultAdapter : CodNodeOperationResultAdapter<ICodCommit>, ICodCommitResult
    {
        public static ICodCommitResult Success(ICodCommit commit)
        {
            return new CodCommitResultAdapter(commit, true, null);
        }

        public static ICodCommitResult Failed(ICodCommit commit, string error)
        {
            return new CodCommitResultAdapter(commit, false, error);
        }

        private CodCommitResultAdapter(ICodCommit commit, bool isValid, string error)
            : base(commit, isValid, error)
        {

        }
    }
}
