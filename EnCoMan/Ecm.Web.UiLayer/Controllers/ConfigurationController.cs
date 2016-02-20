using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ecm.BlLayer;
using Ecm.Common.Dto;

namespace Ecm.Web.UiLayer.Controllers
{
    public class ConfigurationController : ApiController
    {
        [Route("Api/Configuration/GetConfigurations")]
        public IEnumerable<ConfigurationDto> GetConfigurations()
        {
            return ConfigurationLogic.GetConfigurationList();
        }

        [Route("Api/Configuration/GetConfiguration")]
        public ConfigurationDto GetConfiguration(int configurationId)
        {
            return ConfigurationLogic.GetConfiguration(configurationId);
        }

        [Route("Api/Configuration/UpdateConfiguration")]
        public void UpdateConfiguration(ConfigurationDto configuration)
        {
            ConfigurationLogic.UpdateConfiguration(configuration);
        }

        [Route("Api/Configuration/DeleteConfiguration")]
        public void DeleteConfiguration(int configurationId)
        {
            ConfigurationLogic.DeleteConfiguration(configurationId);
        }

        [Route("Api/Configuration/CreateConfiguration")]
        public ConfigurationDto CreateConfiguration(ConfigurationDto configuration)
        {
            return ConfigurationLogic.CreateConfiguration(configuration);
        }

        [Route("Api/ResetDatabaseData")]
        public void ResetDatabaseData()
        {
            ConfigurationLogic.ResetDatabaseData();
        }


    }
}
