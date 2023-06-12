using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public abstract class BaseUnit : NamedObject
    {
        public Commander? Commander { get; set; }

        public string Name {
            get
            {
                // use the overriden name if available
                if (!string.IsNullOrEmpty(Name))
                {
                    return Name;
                }
                if (Commander != null && !string.IsNullOrEmpty(Commander.Name))
                {
                    return Commander.Name;
                }
                return "Unknown Name";
            }

            set
            {
                Name = value;
            }
        }   
    }
}
