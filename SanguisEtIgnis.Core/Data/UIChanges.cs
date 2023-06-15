using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// The changes thats need to be redrawn
    /// </summary>
    public class UIChanges
    {
        private HashSet<int> battalionIds = new HashSet<int>();

        public HashSet<int> BattalionIds
        {
            get
            {
                return battalionIds;
            }
        }
    }
}
