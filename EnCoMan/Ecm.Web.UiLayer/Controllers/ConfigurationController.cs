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
    }
}
