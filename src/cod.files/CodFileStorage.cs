using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.files
{
    public class CodFileStorage : cod.adapters.CodStorageAdapter
    {
        private const string c_metadata = ".cod";
        private const string c_nodesDir = "nodes";
        private readonly string m_path;
        private readonly string m_metadataPath;
        private CodFileNodeRepository m_prev;
        

        public CodFileStorage(DirectoryInfo di)
            : base()
        {
            m_path = di.FullName;
            m_metadataPath = Path.Combine(m_path, c_metadata);
        }

        /// <summary>
        /// Returns all nodes instances stored in this cod file storage
        /// </summary>
        public override IEnumerable<ICodNode> Nodes
        {
            get
            {
                return m_prev = new CodFileNodeRepository(
                    new DirectoryInfo(Path.Combine(m_metadataPath, c_nodesDir)), m_prev);
            }
        }
    }
}
