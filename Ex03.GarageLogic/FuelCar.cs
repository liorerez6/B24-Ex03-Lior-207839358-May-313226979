using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

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
        private List<Wheel> m_Wheels = new List<Wheel>();
        private float m_CurrentFuelAmount;


        //METHODS:
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
            "Current air pressure",
            "Manufacturer name"
        };
            return i_Attributes;
        }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
                m_Wheels.Add(wheel);
            }

            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Number of doors"], "Number of doors", 2, 5);
            LogicInputValidationCheck.IsInputIncludesDigitsInSpecificRange(i_GetAttributes["Current Fuel Amount"], "Current Fuel Amount", 0, k_MaxFuelTank);

            m_CarColor = (ECarColors)Enum.Parse(typeof(ECarColors), i_GetAttributes["Car color"]);
            m_NumberOfDoors = int.Parse(i_GetAttributes["Number of doors"]);
            m_CurrentFuelAmount = int.Parse(i_GetAttributes["Current Fuel Amount"]);
        }

        public override void InflatingWheel()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = k_MaxTiresPressure;
            }
        }

        public override Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = base.DisplayDetails();

            details.Add("Car color", m_CarColor.ToString());
            details.Add("Numbers of doors", m_NumberOfDoors.ToString());
            details.Add("Current Fuel Amount", m_CurrentFuelAmount.ToString());
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
        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            throw new Exception("Can't charge fueled car with electricity!");
        }

        //public enum ETypeOfFuel
        //{
        //    Soler,
        //    Octan95,
        //    Octan96,
        //    Octan98
        //}
    }
}