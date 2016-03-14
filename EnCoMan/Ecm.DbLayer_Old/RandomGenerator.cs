using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecm.DbLayer_Old
{
    public class RandomGenerator
    {
        private readonly Random _termperatureRandom = new Random(1);
        private readonly Random _watterRandom       = new Random(2);
        private readonly Random _gasRandom          = new Random(3);
        private readonly Random _electricityRandom  = new Random(4);

        private int _watterValue      = 0;
        private int _gasValue         = 0;
        private int _electricityValue = 0;

        public int NextTemperature()
        {
            return _termperatureRandom.Next(-10, 40);
        }

        public int NextWatter()
        {
            _watterValue += _watterRandom.Next(0, 30);
            return _watterValue;
        }

        public int NextGas()
        {
            _gasValue += _gasRandom.Next(0, 20);
            return _gasValue;
        }

        public int NextElectricity()
        {
            _electricityValue += _electricityRandom.Next(0, 25);
            return _electricityValue;
        }
    }
}
