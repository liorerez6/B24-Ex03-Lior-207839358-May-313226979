using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Vehicle
    {
        
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime = 3.5f;
        int m_NumberOfDoors;

        List<string> m_RequiredAttributesForElectricCar = new List<string>()
        {
            "Battery Time Left",
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

        public void ChargeBattery(float i_Hours) // TO DO
        {
            m_BatteryTimeLeft += i_Hours;
        }

        public override List<string> GetRequiredData()
        {
            List<string> requiredData = base.GetRequiredData();
            requiredData.AddRange(m_RequiredAttributesForElectricCar);

            return requiredData;
        }

        public override void UpdateAttributes(Dictionary<string, string> i_Attributes)
        {
            base.UpdateAttributes(i_Attributes);
        }
    }
}
