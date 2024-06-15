using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine
    {
        private FuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;


        List<string> m_RequiredAttributesForFueledEngine = new List<string>()
        {
            "Current Fuel Amount",
            "Fuel Type"
        };


        public List<string> GetRequiredData()
        {
            return m_RequiredAttributesForFueledEngine;

        }

        public void Refuel(float i_Amount, FuelType i_FuelType) // TO DO
        {
            m_CurrentFuelAmount += i_Amount;
        }
    }
}
