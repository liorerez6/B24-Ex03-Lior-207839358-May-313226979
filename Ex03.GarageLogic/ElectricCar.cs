using System;
using System.Collections.Generic;

namespace Ex03.GameLogic
{
    internal class ElectricCar : Vehicle
    {
        private const int k_NumberOfWheels = 5;
        private const int k_MaxTiresPressure = 31;
        private const float k_MaxTimeEngine = 3.5F;
        private List<Wheel> m_Wheels = new List<Wheel>(k_NumberOfWheels);
        private ECarColors m_CarColor;
        private int m_NumberOfDoors;
        private float m_BatteryTimeLeft;       

        //METHODS
        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
                m_Wheels.Add(wheel);
            }

            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Number of doors"], "Number of doors", 2, 5);
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Battery time left"], "Battery time left", 0, k_MaxTimeEngine);

            m_CarColor = (ECarColors)Enum.Parse(typeof(ECarColors), i_GetAttributes["Car color"]);
            m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_BatteryTimeLeft = int.Parse(i_GetAttributes["Battery time left"]);
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
        {
            "Car color",
            "Battery time left",
            "Number of doors",
            "Current air pressure",  
            "Manufacturer name"
        };
            return i_Attributes;
        }

        //maybe should find 
        public override void InflatingWheel()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = k_MaxTiresPressure;
            }
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

            details.Add("Car color", m_CarColor.ToString());
            details.Add("Numbers of doors", m_NumberOfDoors.ToString());
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

    }

}
