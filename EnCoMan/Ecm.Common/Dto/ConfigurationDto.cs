
namespace Ecm.Common.Dto
{
    public class ConfigurationDto
    {
        public int Id { get; set; }
        public short Order { get; set; }
        public string Name { get; set; }
        public EnergyTypeDto EnergyType { get; set; }
        public PeriodicityDto Periodicity { get; set; }
        public UserDto User { get; set; }
    }
}
