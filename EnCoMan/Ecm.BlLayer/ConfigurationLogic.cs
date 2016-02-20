using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecm.Common.Dto;
using Ecm.DbLayer;

namespace Ecm.BlLayer
{
    public class ConfigurationLogic
    {
        public static ICollection<ConfigurationDto> GetConfigurationList(int userId)
        {
            return AutoMapper.Instance.Map<List<ConfigurationDto>>(
                DbConfigurationManager.GetConfigurations(userId)); 
        }

        public static ConfigurationDto GetConfiguration(int configurationId)
        {
            return AutoMapper.Instance.Map<ConfigurationDto>(
                DbConfigurationManager.GetConfiguration(configurationId));
        }

        public static void UpdateConfiguration(ConfigurationDto configuration)
        {
            DbConfigurationManager.UpdateConfiguration(
                AutoMapper.Instance.Map<Configuration>(configuration));
        }

        public static void DeleteConfiguration(int configurationId)
        {
            DbConfigurationManager.DeleteConfiguration(configurationId);
        }

        public static ConfigurationDto CreateConfiguration(ConfigurationDto configuration)
        {
            var newConf = DbConfigurationManager.CreateConfiguration(
                AutoMapper.Instance.Map<Configuration>(configuration));

            return AutoMapper.Instance.Map<ConfigurationDto>(newConf);
        }

        public static void ResetDatabaseData()
        {
            DbStoredProcedureManager.ResetDatabaseData();
        }
    }
}

