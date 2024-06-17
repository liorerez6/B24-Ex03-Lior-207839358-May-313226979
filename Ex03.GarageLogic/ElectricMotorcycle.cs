using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GameLogic
{
    internal class ElectricMotorcycle : Vehicle
    {
        private const int k_MaxTiresPressure = 33;
        private const float k_MaxTimeEngine = 2.5F;
        private const int k_NumberOfWheels = 2;
        private List<Wheel> m_Wheels = new List<Wheel>();
        private float m_BatteryTimeLeft;
        private int m_VolumeOfEngine;
        private ETypeOfMotorcycleLicense m_License;

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
                m_Wheels.Add(wheel);
            }

            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Battery time left"], "Battery time left", 0, k_MaxTimeEngine);

            m_License = (ETypeOfMotorcycleLicense)Enum.Parse(typeof(ETypeOfMotorcycleLicense), i_GetAttributes["License type"]);
            m_VolumeOfEngine = int.Parse(i_GetAttributes["Engine Volume"]);
            m_BatteryTimeLeft = int.Parse(i_GetAttributes["Battery time left"]);                      
        }

        public override void FuelVehicle(string i_FuelType, string i_FualAmount)
        {
            throw new Exception("Can't insert fuel to an electric car!");
        }

        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            float newTimeAmount = m_BatteryTimeLeft + float.Parse(i_TimeAmount);

            if (newTimeAmount <= k_MaxTimeEngine)
            {
                m_BatteryTimeLeft = newTimeAmount;
            }
            else 
            {
                throw new ValueOutOfRangeException(0, k_MaxTimeEngine - m_BatteryTimeLeft, "Can't charge the requested amount");
            }
        }

        public override Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = base.DisplayDetails();

            details.Add("License type", m_License.ToString());
            details.Add("Engine Volume", m_VolumeOfEngine.ToString());
            details.Add("Battery time left", m_BatteryTimeLeft.ToString());
            details.Add("Manufacture name", m_Wheels[0].ManufactureName);
            details.Add("Maximun air pressure by manufacture", m_Wheels[0].MaxAirPressure.ToString());
            
            char numOfWheel = '1';

            foreach (Wheel wheel in m_Wheels)
            {
                details.Add(numOfWheel + " wheel air pressure", wheel.CurrentAirPressure.ToString());
                numOfWheel++;
            }

            return details;
        }

        public override void InflatingWheel()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = k_MaxTiresPressure;
            }
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
        {
            "License type",
            "Battery time left",
            "Engine Volume",
            "Current air pressure",
            "Manufacturer name"
        };
            return i_Attributes;
        }

    }
}



