using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodViewAdapter : CodAdapterBase, ICodView
    {
        private readonly ICodUser m_user;
        private readonly ICodStorage m_storage;
        private readonly ICodReference m_reference;
        private ICodReference m_trackedReference;
        private CodEntityCollection m_entities;

        public CodViewAdapter(ICodStorage storage, ICodUser user, ICodReference reference, ICodReference trackedReference)
        {
            m_storage = storage;
            m_user = user;
            m_reference = reference;
            m_trackedReference = trackedReference;
            m_entities = new CodEntityCollection(this);
        }

        public virtual ICodStorage Storage
        {
            get { return m_storage; }
        }

        public virtual ICodReference Reference
        {
            get { return m_reference; }
        }

        public virtual ICodReference TrackedReference
        {
            get { return m_trackedReference; }
        }

        public void SetTrackedReference(ICodReference reference)
        {
            if (!object.Equals(m_trackedReference, reference))
            {
                var old = m_trackedReference;
                m_trackedReference = reference;
                OnTrackedReferenceChanged(reference, old);
            }
        }

        /// <summary>
        /// Called after the view has been set to track another reference
        /// </summary>
        /// <param name="newRef"></param>
        /// <param name="oldRef"></param>
        protected virtual void OnTrackedReferenceChanged(ICodReference newRef, ICodReference oldRef)
        {
        }

        public virtual ICodUser User
        {
            get { return m_user; }
        }

        public virtual IEnumerable<ICodViewEntity> Entities
        {
            get { return m_entities.Entities; }
        }

        public virtual ICodCommitResult Commit(string message)
        {
            throw new NotImplementedException();
        }

        public override string ToDebugString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}@{1}", m_user.Name, m_reference.Name);
            var entities = Entities.ToArray();

            if (entities.Any(e => e.IsDirty))
            {
                sb.Insert(0, "[Dirty] ");
            }
            return sb.ToString();
        }
    }
}
