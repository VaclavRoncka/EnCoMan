using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Data
{
    public class User : IEntity<int>
    {
        public User()
        {
            Records = new HashSet<Record>();
            Configurations = new HashSet<Configuration>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}
