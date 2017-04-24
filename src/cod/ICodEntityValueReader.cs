using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod
{
    public interface ICodEntityValueReader
    {
        ///// <summary>
        ///// Reads the value as an object
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //object ReadValue(ICodEntity entity);

        ///// <summary>
        ///// Reads the value as a stream
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //Stream ReadStream(ICodEntity entity);

        /// <summary>
        /// Reads the value as a string.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string GetHumanReadableString(ICodEntity entity);
    }
}
