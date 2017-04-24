using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodViewEntityAdapter : CodAdapterBase, ICodViewEntity
    {
        protected readonly ICodView m_view;
        protected readonly ICodEntity m_entity;
        private bool m_isDirty;
        private bool m_isStaged;
        

        public CodViewEntityAdapter(ICodView view, ICodEntity entity)
        {
            m_view = view;
            m_entity = entity;
        }

        public bool IsDirty
        {
            get { return m_isDirty; }
        }

        public bool IsStaged
        {
            get { return m_isStaged; }
        }

        public ICodEntity Entity
        {
            get { return m_entity; }
        }

        public void SetStaged(bool isStaged)
        {
            m_isStaged = isStaged;
        }

        protected void SetDirty(bool isDirty)
        {
            m_isDirty = isDirty;
        }

        public override string ToDebugString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0} = {1}", m_entity.Name, m_entity.GetHumanReadableValueSafe(m_view.Storage.ValueReader));

            if (m_isDirty)
            {
                sb.Insert(0, "[Dirty]");
            }
            if (m_isStaged)
            {
                sb.Insert(0, "[Staged]");
            }
            return AppendDebugInfo(sb).ToString();
        }

        protected virtual StringBuilder AppendDebugInfo(StringBuilder sb)
        {
            return sb;
        }
    }

    public class CodViewEntityAdapter<T> : CodViewEntityAdapter, ICodViewEntity<T>
    {
        private readonly ICodEntity<T> m_typedEntity;
        private readonly string m_orgValueHash;
        private T m_value;
        private string m_valueHash;


        public CodViewEntityAdapter(ICodView view, ICodEntity<T> entity)
            : base(view, entity)
        {
            m_typedEntity = entity;
            m_value = m_typedEntity.Value;
            m_valueHash = m_orgValueHash = m_typedEntity.ValueHash;
        }

        public T Value
        {
            get
            {
                return m_value;
            }
            set
            {
                var hasher = m_view.Storage.ValueHasher ?? new CodViewEntityHasherAdapter();
                var newHash = hasher.ComputeHash(this);

                if (string.Equals(m_orgValueHash, newHash))
                {
                    // No longer dirty
                    SetDirty(false);
                    m_value = value;
                }
                else if (!string.Equals(newHash, m_valueHash))
                {
                    // Dirty!
                    m_value = value;
                    m_valueHash = newHash;
                    SetDirty(true);
                }
            }
        }

        protected override StringBuilder AppendDebugInfo(StringBuilder sb)
        {
            var value = m_value;
            sb.AppendFormat(", Value: {0}", value != null ? value.ToString() : "<null>");
            return sb;
        }


        public new ICodEntity<T> Entity
        {
            get { return m_typedEntity; }
        }

        public virtual System.IO.Stream GetValueStream()
        {
            var stream = new MemoryStream();
            var value = m_value;

            if (m_value != null)
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    WriteValue(writer, m_value);
                }
            }
            return stream;
        }

        protected virtual void WriteValue(BinaryWriter writer, T m_value)
        {
            throw new NotImplementedException();
        }
    }
}
