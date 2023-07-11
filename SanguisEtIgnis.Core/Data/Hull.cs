using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// The hull of a starship
    /// </summary>
    public class Hull : NamedObject
    {
        public int HullId { get; set; }
        public DesignSize DesignSize { get; set; }
        public HullSize HullSize { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
    }
}
