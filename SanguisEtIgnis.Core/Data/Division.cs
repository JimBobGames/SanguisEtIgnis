using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Division : BaseUnit
    {
        private List<Brigade> brigades = new List<Brigade>();

        public List<Brigade> Brigades
        {
            get { return brigades; }
        }
    }
}
