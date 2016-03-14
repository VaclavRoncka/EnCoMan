using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Data
{
    public class Configuration : IEntity<int>
    {
        public int Id { get; set; }
        public byte Order { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int EnergyTypeId { get; set; }
        public virtual EnergyType EnergyType { get; set; }

        public virtual Periodicity Periodicity { get; set; }
    }
}
