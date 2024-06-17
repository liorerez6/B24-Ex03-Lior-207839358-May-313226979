using System;
using System.Collections.Generic;

namespace Ex03.GameLogic
{
    internal class ElectricCar : Vehicle
    {
        private const int k_NumberOfWheels = 5;
        private const int k_MaxTiresPressure = 31;
        private const float k_MaxTimeEngine = 3.5F;
        private ECarColors m_CarColor;
        private int m_NumberOfDoors;
        private float m_BatteryTimeLeft;

        public ElectricCar() : base(k_NumberOfWheels, k_MaxTiresPressure) { }

        //METHODS
        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Number of doors"], "Number of doors", 2, 5);
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Battery time left"], "Battery time left", 0, k_MaxTimeEngine);

            m_CarColor = (ECarColors)Enum.Parse(typeof(ECarColors), i_GetAttributes["Car color"]);
            m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_BatteryTimeLeft = float.Parse(i_GetAttributes["Battery time left"]);
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> attributes = new List<string>()
            {
            "Car color",
            "Battery time left",
            "Number of doors",
            };

            return attributes;
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

        public override List<string> DisplayDetails()
        {
            List<string> details = base.DisplayDetails();

            details.Add("Car color " +m_CarColor.ToString());
            details.Add("Numbers of doors " + m_NumberOfDoors.ToString());
            details.Add("Battery time left " + m_BatteryTimeLeft.ToString());
            details.Add("Maximun air pressure by manufacture " + k_MaxTiresPressure.ToString());

            return details;
        }
    }
}
