using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodViewStringEntityAdapter : CodViewEntityAdapter<string>, ICodViewStringEntity
    {
        private readonly ICodStringEntity m_strEntity;
        private string m_value;
        

        public CodViewStringEntityAdapter(ICodView view, ICodStringEntity entity)
            : base(view, entity)
        {
            m_strEntity = entity;
            m_value = m_strEntity.Value;
        }

        protected override void WriteValue(BinaryWriter writer, string m_value)
        {
            writer.Write(m_value);
        }
    }
}
