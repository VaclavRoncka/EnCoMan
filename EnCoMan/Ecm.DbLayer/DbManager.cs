using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer
{
    

    public class DbManager
    {
        

        public static void AddUser()
        {
            using (var ctx = new Entities())
            {
                var newUser = new User() {UserName = "FarmasjeBuh"};
                ctx.Users.Add(newUser);

                ctx.SaveChanges();
            }
        }
        
    }
}
