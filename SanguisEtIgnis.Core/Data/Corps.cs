using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Corps : BaseUnit
    {
        private List<Division> divisions = new List<Division>();

        public List<Division> Divisions
        {
            get { return divisions; }
        }
    }
}
