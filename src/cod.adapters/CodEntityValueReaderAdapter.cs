using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cod.adapters
{
    public class CodEntityValueReaderAdapter : CodAdapterBase, ICodEntityValueReader
    {
        //public virtual object ReadValue(ICodEntity entity)
        //{
        //    if (entity is ICodStringEntity)
        //    {
        //        return ((ICodStringEntity)entity).Value;
        //    }
        //    else if (entity is ICodBlobEntity)
        //    {
        //    }
        //}

        //public System.IO.Stream ReadStream(ICodEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        public string GetHumanReadableString(ICodEntity entity)
        {
            // TODO, use value
            return string.Format("[{0}] {1}, #{2}", entity.Type, entity.Name, entity.ValueHash); 
        }

        public override string ToDebugString()
        {
            return "EntityValueReader";
        }
    }
}
