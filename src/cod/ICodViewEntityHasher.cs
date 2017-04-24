using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    public interface ICodViewEntityHasher
    {
        //string ComputeHash(ICodEntity entity);

        string ComputeHash<T>(ICodViewEntity<T> entity);
    }
}
