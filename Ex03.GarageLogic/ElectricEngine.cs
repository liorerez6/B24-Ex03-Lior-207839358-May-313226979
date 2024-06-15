using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        List<string> m_RequiredAttributesForElectricEngine = new List<string>()
        {
            "Battery Time Left",
        };


        public List<string> GetRequiredData()
        {
            return m_RequiredAttributesForElectricEngine;

        }

        public void ChargeBattery(float i_Hours) // TO DO
        {
            m_BatteryTimeLeft += i_Hours;
        }
    }
}
