using System;
using System.Collections.Generic;

namespace Ex03.GameLogic
{
    internal class Truck : Vehicle
    {
        private const ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Soler;
        private const int k_NumberOfWheels = 12;
        private const int k_MaxTiresPressure = 28;
        private const float k_MaxFuelTank = 120F;
        private bool r_IsCarringToxicSubstances;
        private float m_CargoCapacity;
        private float m_CurrentFuelAmount;

        public Truck() : base(k_NumberOfWheels, k_MaxTiresPressure){ }

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
                    throw new ValueOutOfRangeException(0, k_MaxFuelTank - m_CurrentFuelAmount, "Can't fuel truck with the requested amount");
                }
            }
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
            {
                "Cargo Capacity",
                "Current Fuel Amount",
                "Is carring Toxic Substances",
            };

            return i_Attributes;
        }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            LogicInputValidationCheck.CompareInputToStrings(i_GetAttributes["Is carring Toxic Substances"], "Is carring Toxic Substances", "yes", "no");

            m_CargoCapacity = float.Parse(i_GetAttributes["Cargo Capacity"]);
            r_IsCarringToxicSubstances = (i_GetAttributes["Is carring Toxic Substances"]).ToLower().Equals("yes");
            m_CurrentFuelAmount = float.Parse(i_GetAttributes["Current Fuel Amount"]);
        }

        public override List<string> DisplayDetails()
        {
            List<string> details = base.DisplayDetails();

            details.Add("Cargo Capacity " + m_CargoCapacity.ToString());
            details.Add("Carring Toxic Substances " + r_IsCarringToxicSubstances.ToString());
            details.Add("Current Fuel Amount " + m_CurrentFuelAmount.ToString());

            return details;
        }

        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            throw new Exception("Can't charge truck with electricity!");
        }
    }
}