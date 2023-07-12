using SanguisEtIgnis.Core.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// The strategic priorities for a race
    /// </summary>
    public class StratgicPriorities
    {
        public BudgetAreas BudgetAreas { get; set; }
        public int Value { get; set; }
    }
}