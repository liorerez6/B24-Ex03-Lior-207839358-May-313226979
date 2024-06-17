using System;
using System.Collections.Generic;

namespace Ex03.GameLogic
{
    internal class FuelMotorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private ETypeOfMotorcycleLicense m_License;
        private ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Octan98;
        private const int k_MaxTiresPressure = 33;
        private const float k_MaxFuelTank = 5.5F;
        private float m_CurrentFuelAmount;
        private int m_VolumeOfEngine;

        public FuelMotorcycle() : base(k_NumberOfWheels, k_MaxTiresPressure) { }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {

            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Current Fuel Amount"], "Current Fuel Amount", 0, k_MaxFuelTank);

            m_License = (ETypeOfMotorcycleLicense)Enum.Parse(typeof(ETypeOfMotorcycleLicense), i_GetAttributes["License type"]);
            m_VolumeOfEngine = int.Parse(i_GetAttributes["Engine Volume"]);
            m_CurrentFuelAmount = float.Parse(i_GetAttributes["Current Fuel Amount"]);
        }

        public override void FuelVehicle(string i_FuelType, string i_FualAmount)
        {
            ETypeOfFuel fuelType = (ETypeOfFuel)Enum.Parse(typeof(ETypeOfFuel), i_FuelType);

            if (fuelType == k_TypeOfFuel)
            {
                float newFuelAmount = m_CurrentFuelAmount + float.Parse(i_FualAmount);

                if (newFuelAmount <= k_MaxFuelTank)
                {
                    m_CurrentFuelAmount = newFuelAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, k_MaxFuelTank - m_CurrentFuelAmount, "Can't fuel motorcycle with the requested amount");
                }
            }
        }

        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            throw new Exception("Can't charge fueled motorcycle with electricity!");
        }

        public override List<string> DisplayDetails()
        {
            List<string> details = base.DisplayDetails();

            details.Add("License type " + m_License.ToString());
            details.Add("Engine Volume " + m_VolumeOfEngine.ToString());
            details.Add("Current Fuel Amount " + m_CurrentFuelAmount.ToString());

            return details;
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
            {
                "License type",
                "Current Fuel Amount",
                "Engine Volume"
            };

            return i_Attributes;
        }
    }
}