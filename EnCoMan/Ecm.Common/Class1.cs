using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.Common
{
    public class ConfigurationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EnergyTypeId { get; set; }
        public int PeriodicityId { get; set; }
        public short Order { get; set; }
        public string Name { get; set; }
    }
}
