using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Brigade : BaseUnit
    {
        public int BrigadeId { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }
        public int FacingInDegrees { get; set; }

        private List<Battalion> battalions = new List<Battalion>();

        public List<Battalion> Battalions
        {
            get { return battalions; }
        }

        public Battalion AddBattalion(Battalion c)
        {
            battalions.Add(c);

            return c;
        }

        public override string UnitSizeText
        {
            get
            {
                return "X";
            }
        }
    }
}
