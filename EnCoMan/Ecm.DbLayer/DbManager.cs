using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer
{
    

    public class DbManager
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
        

        public static void AddUser(User user)
        {
            using (var ctx = new Entities())
            {
                ctx.Users.Add(user);

                ctx.SaveChanges();
            }
        }
        
    }
}
