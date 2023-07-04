using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Corps : BaseUnit
    {
        public int CorpId { get; set; }

        private List<Division> divisions = new List<Division>();

        public List<Division> Divisions
        {
            get { return divisions; }
        }

        public Division AddDivision(Division c)
        {
            divisions.Add(c);

            return c;
        }

        public override string UnitSizeText
        {
            get
            {
                return "XXX";
            }
        }
    }
}
