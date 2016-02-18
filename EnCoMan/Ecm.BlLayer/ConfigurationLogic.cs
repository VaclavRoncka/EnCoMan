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
        public static ICollection<ConfigurationDto> GetConfigurationList()
        {
            var confList = DbManager.GetConfigurations(1);
            return AutoMapper.Instance.Map<List<ConfigurationDto>>(confList); 
        }
    }
}

