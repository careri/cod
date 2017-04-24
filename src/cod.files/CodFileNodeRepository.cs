using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cod.files
{
    class CodFileNodeRepository
    {
        private readonly string m_path;
        private readonly CodFileNodeRepository m_prev;
        private readonly Lazy<Dictionary<string,ICodNode>> m_nodes;

        /// <summary>
        /// Creates a new repo for the given directory
        /// </summary>
        /// <param name="di">The directory to parse</param>
        /// <param name="prev">If given nodes will be imported from that instances instead of recreated</param>
        public CodFileNodeRepository(
            DirectoryInfo di, 
            CodFileNodeRepository prev)
        {
            m_path = di.FullName;
            m_prev = prev;
            m_nodes = new Lazy<Dictionary<string, ICodNode>>(InitNodes, true);
        }

        private Dictionary<string, ICodNode> InitNodes()
        {
            var dic = new Dictionary<string, ICodNode>();
            var di = new DirectoryInfo(m_path);
            var prevDic = m_prev != null && m_prev.m_nodes.IsValueCreated ?
                m_prev.m_nodes.Value :
                null;

            foreach (var file in di.GetFiles())
            {
                ICodNode node;
                var hash = file.Name;

                if (prevDic != null && prevDic.TryGetValue(hash, out node))
                {
                    dic[hash] = node;
                }
                else
                {
                    // Try to parse the node
                }
            }
        }
    }
}
