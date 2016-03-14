using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Data
{
    public class EnergyType : IEntity<int>
    {
        public EnergyType()
        {
            Records = new HashSet<Record>();
            Configurations = new List<Configuration>();
        }
        public int Id { get; set; }

        public string Description { get; set; }
        public string Unit { get; set; }

        
        
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}
