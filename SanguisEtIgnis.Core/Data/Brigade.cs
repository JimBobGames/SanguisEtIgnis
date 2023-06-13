using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Brigade : BaseUnit
    {
        private List<Battalion> battalions = new List<Battalion>();

        public List<Battalion> Battalions
        {
            get { return battalions; }
        }
    }
}
