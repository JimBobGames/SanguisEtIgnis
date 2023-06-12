using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Commander : NamedObject
    {
        public string? ShortName { get; set; }
        public string? LongName { get; set; }

        public override string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Name))
                {
                    return base.Name;
                }
                if (!string.IsNullOrEmpty(ShortName))
                {
                    return ShortName;
                }
                return "Unknown Name";
            }
            set
            {
                base.Name = value;
            }
        }
    }
}
