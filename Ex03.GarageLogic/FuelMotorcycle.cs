using System;
using System.Collections.Generic;
using static Ex03.GameLogic.Enums;

namespace Ex03.GameLogic
{
    internal class FuelMotorcycle : Vehicle
    {
        private Enums.ETypeOfMotorcycleLicense m_License;
        private Enums.ETypeOfFuel k_TypeOfFuel = Enums.ETypeOfFuel.Octan98;
        private const int k_MaxTiresPressure = 33;
        private const float k_MaxFuelTank = 5.5F;
        private float m_CurrentFuelAmount;
        private int m_VolumeOfEngine;
        private List<Wheel> m_Wheels = new List<Wheel>();


        public override void InitializeAttributesOfVehicle(Dictionary<string, string> i_GetAttributes)
        {
            Wheel wheel = new Wheel(i_GetAttributes["Manufacturer name"], k_MaxTiresPressure, i_GetAttributes["Current air pressure"]);
            m_Wheels.Add(wheel);
            m_Wheels.Add(wheel); // need to corret because now every wheell have refernce to the same wheel. changing tire pressure in one
                                 // will change it in all of them
             
            m_License = (Enums.ETypeOfMotorcycleLicense)Enum.Parse(typeof(Enums.ETypeOfMotorcycleLicense), i_GetAttributes["License type"]);
            m_VolumeOfEngine = int.Parse(i_GetAttributes["Engine Volume"]);
            m_CurrentFuelAmount = int.Parse(i_GetAttributes["Current Fuel Amount"]);
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
            }
        }

        public override void ChargeElectricVehicle(string i_TimeAmount)
        {
            // throw exepction
        }

        public override Dictionary<string, string> DisplayDetails()
        {
            Dictionary<string, string> details = base.DisplayDetails();

            details.Add("License type", m_License.ToString());
            details.Add("Engine Volume", m_VolumeOfEngine.ToString());
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
            "Current Fuel Amount",
            "Engine Volume",
            "Current air pressure",
            "Manufacturer name"
        };
            return i_Attributes;
        }

    }

    

}