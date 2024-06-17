using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

namespace Ex03.GameLogic
{
    internal class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private bool r_IsCarringToxicSubstances;
        private float m_CargoCapacity;
        private List<Wheel> m_Wheels = new List<Wheel>(k_NumberOfWheels);
        const ETypeOfFuel k_TypeOfFuel = ETypeOfFuel.Soler;

        private const int k_MaxTiresPressure = 28;
        private const float k_MaxFuelTank = 120F;
        private float m_CurrentFuelAmount;

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
            }
        }

        public override List<string> InitializeAttrubuteList()
        {
            List<string> i_Attributes = new List<string>()
        {
            "Cargo Capacity",
            "Current Fuel Amount",
            "Carring Toxic Substances",
            "Current air pressure",
            "Manufacturer name"
        };
            return i_Attributes;
        }

        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            for(int i =0; i < k_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
                m_Wheels.Add(wheel);
            }

            m_CargoCapacity = int.Parse(i_GetAttributes["Cargo Capacity"]);
            r_IsCarringToxicSubstances = bool.Parse(i_GetAttributes["Carring Toxic Substances"]); // 
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

            details.Add("Cargo Capacity", m_CargoCapacity.ToString());
            details.Add("Carring Toxic Substances", r_IsCarringToxicSubstances.ToString());
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
            //throw exception
        }

        public enum ETypeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}