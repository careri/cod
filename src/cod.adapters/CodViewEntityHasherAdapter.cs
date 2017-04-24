using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cod.adapters
{
    /// <summary>
    /// An implementation that uses SHA256
    /// </summary>
    public class CodViewEntityHasherAdapter : ICodViewEntityHasher
    {
        private readonly SHA256 m_sha = SHA256.Create();

        public string ComputeHash<T>(ICodViewEntity<T> entity)
        {
            var value = entity.Value;
            string hashStr = null;

            lock (m_sha)
            {
                m_sha.Clear();

                using (var stream = entity.GetValueStream())
                using (var memStream = new MemoryStream())
                using (var hashStream = new CryptoStream(memStream, m_sha, CryptoStreamMode.Write))
                {
                    stream.CopyTo(hashStream);
                    hashStream.FlushFinalBlock();
                }
                var hash = m_sha.Hash;
                hashStr = Convert.ToBase64String(hash);
            }
            return hashStr;
        }
    }
}
