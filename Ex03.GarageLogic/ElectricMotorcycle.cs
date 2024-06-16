using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GameLogic
{
    internal class ElectricMotorcycle : Vehicle
    {
        private List<Wheel> m_Wheels = new List<Wheel>();
        private float m_BatteryTimeLeft;
        private Enums.ETypeOfMotorcycleLicense m_License;
        private const int k_MaxTiresPressure = 33;
        private const float k_MaxTimeEngine = 2.5F;
        private int volumeOfEngine;


        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel); // need to corret because now every wheell have refernce to the same wheel. changing tire pressure in one
                                 // will change it in all of them
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel);

            //m_CarColor = (Enums.ECarColors)Enum.Parse(typeof(Enums.ECarColors), i_GetAttributes["Car color"]);
            //m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_BatteryTimeLeft = int.Parse(i_GetAttributes["Battery time left"]);
        }

        public override void FuelVehicle(string i_FuelType, string i_FualAmount)
        {
            //throw exception
        }

        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            float newTimeAmount = m_BatteryTimeLeft + float.Parse(i_TimeAmount);

            if (newTimeAmount <= k_MaxTimeEngine)
            {
                m_BatteryTimeLeft = newTimeAmount;
            }
        }

        public override Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = base.DisplayDetails();

            details.Add("License type", m_License.ToString());
            //details.Add("Numbers of doors", m_NumberOfDoors.ToString());
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



