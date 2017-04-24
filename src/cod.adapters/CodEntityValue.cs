using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    public static class CodEntityValue
    {
        /// <summary>
        /// Retrieves a value and catches any exceptions
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static string GetHumanReadableValueSafe(this ICodEntity entity, ICodEntityValueReader reader)
        {
            try
            {
                return reader.GetHumanReadableString(entity);
            }
            catch
            {
                try
                {
                    return entity.ToString();
                }
                catch
                {
                    return entity.GetType().Name;
                }
            }
        }
    }
}
