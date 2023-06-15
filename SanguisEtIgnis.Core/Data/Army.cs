using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Army : BaseUnit
    {
        public int ArmyId { get; set; }

        private List<Corps> corps = new List<Corps>();

        public List<Corps> Corps
        {
            get { return corps; }
        }

        public Corps AddCorps(Corps c)
        {
            corps.Add(c);

            return c;
        }
    }
}
