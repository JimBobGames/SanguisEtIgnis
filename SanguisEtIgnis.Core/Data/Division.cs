using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Division : BaseUnit
    {
        public int DivisionId { get; set; }


        private List<Brigade> brigades = new List<Brigade>();

        public List<Brigade> Brigades
        {
            get { return brigades; }
        }

        public Brigade AddBrigade(Brigade c)
        {
            brigades.Add(c);

            return c;
        }

        public override string UnitSizeText
        {
            get
            {
                return "XX";
            }
        }
    }
}
