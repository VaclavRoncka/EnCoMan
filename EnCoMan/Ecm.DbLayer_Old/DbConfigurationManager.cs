using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer_Old
{
    public class DbConfigurationManager
    {
        public static List<Configuration> GetConfigurations(int? userId)
        {
            using (var ctx = new Entities())
            {
                var command = ctx.Configurations
                    .Include(c => c.User)
                    .Include(c => c.Periodicity)
                    .Include(c => c.EnergyType)
                    .AsNoTracking().AsQueryable();

                if (userId.HasValue)
                    command = command.Where(c => c.UserId == userId);

                return command.ToList();
            }
        }

        public static Configuration GetConfiguration(int id)
        {
            using (var ctx = new Entities())
            {
                return ctx.Configurations
                    .Include(c => c.User)
                    .Include(c => c.Periodicity)
                    .Include(c => c.EnergyType)
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Id == id);
            }
        }


        public static void DeleteConfiguration(int id)
        {
            using (var ctx = new Entities())
            {
                ctx.Entry<Configuration>(new Configuration() {Id = id})
                    .State = EntityState.Deleted;

                ctx.SaveChanges();
            }
        }

        public static void UpdateConfiguration(Configuration configuration)
        {
            using (var ctx = new Entities())
            {
                var conf = ctx.Configurations
                    .Single(c => c.Id == configuration.Id);

                conf.EnergyTypeId  = configuration.EnergyTypeId;
                conf.PeriodicityId = configuration.PeriodicityId;
                conf.Name          = configuration.Name;
                conf.Order         = configuration.Order;
                
                ctx.SaveChanges();
            }
        }

        public static Configuration CreateConfiguration(Configuration configuration)
        {
            configuration.User = null;
            configuration.EnergyType = null;
            configuration.Periodicity = null;

            using (var ctx = new Entities())
            {
                ctx.Configurations.Add(configuration);
                ctx.SaveChanges();

                return configuration;
            }
        }

    }
}
