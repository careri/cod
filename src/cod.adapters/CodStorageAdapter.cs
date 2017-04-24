using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodStorageAdapter : ICodStorage
    {
        private readonly ICodViewEntityHasher m_valueHasher;
        private readonly ICodEntityValueReader m_valueReader;
        private readonly bool m_isCaseSensitive;

        public CodStorageAdapter(ICodViewEntityHasher hasher, ICodEntityValueReader reader, bool isCaseSensitive)
        {
            m_valueHasher = hasher;
            m_valueReader = reader;
            m_isCaseSensitive = isCaseSensitive;
	    }

        public CodStorageAdapter(): this(
            new CodViewEntityHasherAdapter(),
            new CodEntityValueReaderAdapter(),
            false)
        {

        }

        public virtual ICodVerifyResult Verify(ICodNode node)
        {
            throw new NotImplementedException();
        }

        public virtual  ICodGetResult Get(string id)
        {
            throw new NotImplementedException();
        }

        public virtual  ICodAddResult Add(ICodNode node)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ICodNode> Nodes
        {
            get { return Enumerable.Empty<ICodNode>(); }
        }

        public virtual  ICodReferenceResult SetReference(string name, ICodNode node, bool force)
        {
            throw new NotImplementedException();
        }

        public virtual ICodViewResult View(ICodUser user, ICodReference reference)
        {
            throw new NotImplementedException();
        }

        public ICodViewEntityHasher ValueHasher
        {
            get { return m_valueHasher; }
        }

        public virtual ICodEntityValueReader ValueReader
        {
            get { return m_valueReader; }
        }

        public virtual bool IsCaseSensitive
        {
            get { return m_isCaseSensitive; }
        }
    }
}
