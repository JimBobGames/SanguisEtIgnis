using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class NamedObject
    {
        private string name = "";

        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value == null)
                {
                    name = "";
                }
                else
                {
                    name = value;
                }
            }
        }
    }
}
