using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public abstract class BaseUnit : NamedObject
    {
        public Officer? Officer { get; set; }

        public abstract string UnitSizeText { get; }
        /*
        public string Name {
            get
            {
                // use the overriden name if available
                if (!string.IsNullOrEmpty(Name))
                {
                    return Name;
                }
                if (Officer != null && !string.IsNullOrEmpty(Officer.Name))
                {
                    return Officer.Name;
                }
                return "Unknown Name";
            }

            set
            {
                Name = value;
            }
        } 
        */
    }
}
