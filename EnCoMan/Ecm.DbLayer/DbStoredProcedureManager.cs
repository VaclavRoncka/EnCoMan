using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer
{
    public class DbStoredProcedureManager
    {
        public static void ResetDatabaseData()
        {
            using (var ctx = new Entities())
            {
                ctx.ResetDatabaseData();
                ctx.SaveChanges();
            }
        }
    }
}
