using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer
{
    public class DbRecordManager
    {
        public static void GenerateRandomRecords(DateTime from, DateTime to)
        {
            var allConfigurations = DbConfigurationManager.GetConfigurations(null);

            var daily = allConfigurations.Where(c => c.PeriodicityId == 1).ToList();
            var monthly = allConfigurations.Where(c => c.PeriodicityId == 2).ToList();


            var randGen = new RandomGenerator();

            using (var ctx = new Entities())
            {
                var currDay = from;
                while (currDay <= to)
                {
                    ctx.Records.AddRange(
                        CreateRecords(currDay, monthly, randGen));

                    currDay = currDay.AddMonths(1);
                }

                currDay = from;
                while (currDay <= to)
                {
                    ctx.Records.AddRange(
                        CreateRecords(currDay, daily, randGen));

                    currDay = currDay.AddDays(1);
                }

                ctx.SaveChanges();
            }
        }

        private static IEnumerable<Record> CreateRecords(DateTime currDay, IList<Configuration> configuration, RandomGenerator randGen)
        {
            var confList = new List<Record>(configuration.Count);
            
            foreach (var conf in configuration)
            {
                var newRecord = new Record()
                {
                    Date          = currDay,
                    UserId        = conf.UserId,
                    EnergyTypeId  = conf.EnergyTypeId,
                    PeriodicityId = conf.PeriodicityId
                };

                switch (conf.EnergyTypeId)
                {
                    case 1: newRecord.Value = randGen.NextElectricity(); break;
                    case 2: newRecord.Value = randGen.NextGas(); break;
                    case 3: newRecord.Value = randGen.NextTemperature(); break;
                    case 4: newRecord.Value = randGen.NextWatter(); break;
                }

                confList.Add(newRecord);
            }

            return confList;
        }
    }
}
