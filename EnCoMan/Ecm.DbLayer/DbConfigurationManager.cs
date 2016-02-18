using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer
{
    public class DbConfigurationManager
    {
        public static List<Configuration> GetConfigurations(int userId)
        {
            using (var ctx = new Entities())
            {
                return ctx.Configurations
                    .Include("User")
                    .Include("EnergyType")
                    .Include("Periodicity")
                    .AsNoTracking()
                    .Where( c=> c.UserId == userId)
                    .ToList();
            }
        }

        public static Configuration GetConfiguration(int id)
        {
            using (var ctx = new Entities())
            {
                return ctx.Configurations
                    .Include("User")
                    .Include("EnergyType")
                    .Include("Periodicity")
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Id == id);
            }
        }


        public static void DeleteConfiguration(int id)
        {
            using (var ctx = new Entities())
            {
                var conf = GetConfiguration(id);

                if (conf == null)
                    return;

                ctx.Configurations.Remove(conf);
                ctx.SaveChanges();
            }
        }

        public static void UpdateConfiguration(Configuration configuration)
        {
            using (var ctx = new Entities())
            {
                var conf = GetConfiguration(configuration.Id);

                conf.EnergyTypeId  = configuration.EnergyTypeId;
                conf.PeriodicityId = configuration.PeriodicityId;
                conf.Name          = configuration.Name;
                conf.Order         = configuration.Order;
                
                ctx.SaveChanges();
            }
        }

        public static void InsertConfiguration(Configuration configuration)
        {
            using (var ctx = new Entities())
            {
                ctx.Configurations.Add(configuration);
                ctx.SaveChanges();
            }
        }

    }
}
