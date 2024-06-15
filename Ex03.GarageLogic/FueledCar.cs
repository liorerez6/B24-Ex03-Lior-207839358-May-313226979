using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FueledCar : Vehicle
    {
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount = 45;

        List<string> m_RequiredAttributesForFueledCar = new List<string>()
        {
            "Current Fuel Amount",
            "Fuel Type",
            "Car Color",
            "Number Of Doors",
            "Wheel 1 Manufactor:",
            "Wheel 1 Tyre Pressure:",
            "Wheel 2 Manufactor:",
            "Wheel 2 Tyre Pressure:",
            "Wheel 3 Manufactor:",
            "Wheel 3 Tyre Pressure:",
            "Wheel 4 Manufactor:",
            "Wheel 4 Tyre Pressure:",
        };
        public void Refuel(float i_Amount, FuelType i_FuelType) // TO DO
        {
            m_CurrentFuelAmount += i_Amount;
        }

        public override List<string> GetRequiredData()
        {
            List<string> requiredData = base.GetRequiredData();
            List<string> dataForFuledEngine = m_RequiredAttributesForFueledCar;
            requiredData.AddRange(dataForFuledEngine);

            return requiredData;
        }
        public override void UpdateAttributes(Dictionary<string, string> i_Attributes)
        {
            base.UpdateAttributes(i_Attributes);
        }
    }
}
