using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodCommitAdapter : CodNodeAdapter, ICodCommit
    {
        public CodCommitAdapter(ICodUser user, string id, ICodNode parent, params ICodEntity[] entities)
            : base(user, id, (byte)CodNodeTypes.Commit, parent, entities)
        {

        }

        public CodCommitAdapter(ICodUser user, string id, byte type, ICodNode parent, params ICodEntity[] entities)
            : base(user, id, type, parent, entities)
        {

        }
    }
}
