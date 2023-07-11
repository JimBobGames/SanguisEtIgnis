using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class NamedObject : IComparable<NamedObject>
    {
        private string name = "";
        private string shortName = "";

        public int CompareTo(NamedObject other)
        {
            return Name.CompareTo(other.Name);
        }

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
        public virtual string ShortName
        {
            get
            {
                return shortName;
            }
            set
            {
                if (value == null)
                {
                    shortName = "";
                }
                else
                {
                    shortName = value;
                }
            }
        }
    }
}
