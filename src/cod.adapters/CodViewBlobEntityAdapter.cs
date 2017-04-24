using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public class CodViewBlobEntityAdapter : CodViewEntityAdapter<ICodBlob>, ICodViewBlobEntity
    {
        public CodViewBlobEntityAdapter(ICodView view, ICodBlobEntity entity)
            : base(view, entity)
        {
        }

        public override System.IO.Stream GetValueStream()
        {
            var value = Value;

            if (value != null)
            {
                return value.GetStream();
            }
            return new MemoryStream(new byte[0], false);
        }
    }
}
