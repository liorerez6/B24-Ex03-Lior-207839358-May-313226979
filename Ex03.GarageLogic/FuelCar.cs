using System;
using System.Collections.Generic;

namespace Ex03.GameLogic
{
    internal class FuelCar : Vehicle
    {
        private const int k_NumberOfWheels = 5;
        private const int k_MaxTiresPressure = 31;
        private const float k_MaxFuelTank = 45F;
        private const ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Octan95;
        private ECarColors m_CarColor;
        private int m_NumberOfDoors;
        private float m_CurrentFuelAmount;

        public FuelCar() : base(k_NumberOfWheels, k_MaxTiresPressure) { }

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
                    throw new ValueOutOfRangeException(0, k_MaxFuelTank - m_CurrentFuelAmount, "Can't fuel car with the requested amount");
                }
            }
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
        {
            "Car color",
            "Current Fuel Amount",
            "Number of doors",
        };
            return i_Attributes;
        }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Number of doors"], "Number of doors", 2, 5);
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Current Fuel Amount"], "Current Fuel Amount", 0, k_MaxFuelTank);

            m_CarColor = (ECarColors)Enum.Parse(typeof(ECarColors), i_GetAttributes["Car color"]);
            m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_CurrentFuelAmount = float.Parse(i_GetAttributes["Current Fuel Amount"]);
        }

        public override List<string> DisplayDetails()
        {
            List<string> details = base.DisplayDetails();

            details.Add("Car color " + m_CarColor.ToString());
            details.Add("Numbers of doors " + m_NumberOfDoors.ToString());
            details.Add("Current Fuel Amount " + m_CurrentFuelAmount.ToString());
      
            return details;
        }
        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            throw new Exception("Can't charge fueled car with electricity!");
        }
    }
}